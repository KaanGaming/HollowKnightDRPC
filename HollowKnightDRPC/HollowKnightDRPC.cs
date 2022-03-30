using Discord;
using Modding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace HollowKnightDRPC
{
    public partial class HollowKnightDRPC : Mod, IGlobalSettings<RPCGlobalSettings>, IMenuMod
    {
        internal static HollowKnightDRPC Instance;

        public HollowKnightDRPC() : base("Hollow Knight Discord RPC")
        {
            Instance = this;
        }

        public int takenHits = 0;
        public int takenTotalHits = 0;

        private static readonly FieldInfo DEATH_FI = typeof(EnemyDeathEffects).GetField("enemyDeathType", BindingFlags.NonPublic | BindingFlags.Instance);

        bool displayBossHP = false;
        List<(GameObject bossobj, int maxhp)> bosses = new List<(GameObject bossobj, int maxhp)>();

        public Discord.Discord discord = null;

        private RPCGlobalSettings Settings = new RPCGlobalSettings();

        public void OnLoadGlobal(RPCGlobalSettings s) => Settings = s;
        public RPCGlobalSettings OnSaveGlobal() => Settings;

        public string currentScene = "";

        public ActivityManager rpc = null;
        public Activity act = new Activity();
        public long id = 827571383080845322;

        public DateTime gamestart = DateTime.UtcNow;

        public GameObject RPCobject;

        public override string GetVersion()
        {
            return "1.1.0";
        }

        byte[] GetEmbeddedResource(string resourceName)
        {
            byte[] returningval = new byte[] { };
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream s = assembly.GetManifestResourceStream(resourceName))
            {
                if (s != null)
                {
                    using (BinaryReader br = new BinaryReader(s))
                    {
                        returningval = br.ReadBytes((int)s.Length);
                        br.Close();
                    }
                    s.Close();
                    s.Dispose();
                }
            }

            return returningval;
        }

        public override int LoadPriority() => 10;

        #region Functions used inside Initialize()
        public bool CheckIntegrity()
        {
            bool integrity = true;

            string modp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().FullName);
            string plugins = $@"{modp}\..\..\Plugins";

            if (!File.Exists($"{plugins}\\x86\\discord_game_sdk.dll")) integrity = false;
            if (!File.Exists($"{plugins}\\x86\\discord_game_sdk.dll.lib")) integrity = false;
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.dll")) integrity = false;
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.dll.lib")) integrity = false;
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.bundle")) integrity = false;
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.dylib")) integrity = false;
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.so")) integrity = false;

            return integrity;
        }

        public void LoadDLLs()
        {
            string modp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().FullName);
            string plugins = $@"{modp}\..\..\Plugins";

            var assembly = Assembly.GetExecutingAssembly();
            string sdk86dll = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("discord_game_sdk_86.dll"));
            string sdk86lib = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("discord_game_sdk_86.dll.lib"));

            string sdkdll = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("discord_game_sdk.dll"));
            string sdkbundle = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("discord_game_sdk.bundle"));
            string sdklib = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("discord_game_sdk.dll.lib"));
            string sdkdylib = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("discord_game_sdk.dylib"));
            string sdkso = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("discord_game_sdk.so"));

            if (!Directory.Exists($"{plugins}\\x86"))
                Directory.CreateDirectory($"{plugins}\\x86");
            if (!Directory.Exists($"{plugins}\\x86_64"))
                Directory.CreateDirectory($"{plugins}\\x86_64");

            if (!File.Exists($"{plugins}\\x86\\discord_game_sdk.dll")) File.WriteAllBytes("{plugins}\\x86\\discord_game_sdk.dll", GetEmbeddedResource(sdk86dll));
            if (!File.Exists($"{plugins}\\x86\\discord_game_sdk.dll.lib")) File.WriteAllBytes("{plugins}\\x86\\discord_game_sdk.dll.lib", GetEmbeddedResource(sdk86lib));
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.dll")) File.WriteAllBytes("{plugins}\\x86_64\\discord_game_sdk.dll", GetEmbeddedResource(sdkdll));
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.dll.lib")) File.WriteAllBytes("{plugins}\\x86_64\\discord_game_sdk.dll.lib", GetEmbeddedResource(sdklib));
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.bundle")) File.WriteAllBytes("{plugins}\\x86_64\\discord_game_sdk.bundle", GetEmbeddedResource(sdkbundle));
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.dylib")) File.WriteAllBytes("{plugins}\\x86_64\\discord_game_sdk.dylib", GetEmbeddedResource(sdkdylib));
            if (!File.Exists($"{plugins}\\x86_64\\discord_game_sdk.so")) File.WriteAllBytes("{plugins}\\x86_64\\discord_game_sdk.so", GetEmbeddedResource(sdkso));
        }
        #endregion

        public override void Initialize()
        {
            Log("Mod initializing");

            if (!File.Exists(".\\NO SDK CHECK.drpc"))
            {
                if (!CheckIntegrity())
                {
                    LoadDLLs();
                }
            }

            // DEPENDENCY CODE
            // ---------------------------------------------------------------------------------
            // DISCORD CODE

            discord = new Discord.Discord(id, (ulong)CreateFlags.NoRequireDiscord);

            RPCobject = new GameObject("Discord RPC");

            RPCobject.AddComponent<RPCGameObject>();

            EventNode.Node1 += Update;
            ModHooks.SavegameLoadHook += LoadGame;
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += SceneChanged;
            ModHooks.SceneChanged += Locate;
            ModHooks.OnEnableEnemyHook += EnemySpawn;
            ModHooks.AfterTakeDamageHook += AfterTakeDamageHook;

            rpc = discord.GetActivityManager();

            discord.SetLogHook(Discord.LogLevel.Error, (lv, log) =>
            {
                Log((int)lv + " - " + log);
            });

            rpc.UpdateActivity(act, res => { });
        }

        private int AfterTakeDamageHook(int hazardType, int damageAmount)
        {
            takenHits++;
            takenTotalHits++;
            return damageAmount;
        }

        private void SceneChanged(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.Scene arg1)
        {
            bosses.Clear();
            takenHits = 0;
            displayBossHP = false;
            vkings = 0;
            vking_maxhp = 0;
            vking_maxhp_done = false;
            mlords = 0;
            mlord_maxhp = 0;
            mlord_maxhp_done = false;
            watchknights = 0;
            watchknight_maxhp = 0;
            watchknight_maxhp_done = false;
            oblobbles = 0;
            oblobble_maxhp = 0;
            oblobble_maxhp_done = false;
            soultyrants = 0;
            soultyrant_maxhp = 0;
            soultyrant_maxhp_done = false;
            soulmasters = 0;
            soulmaster_maxhp = 0;
            soulmaster_maxhp_done = false;
            oromato_phase = 0;
            displayBossHPText = true;
        }

        private bool EnemySpawn(GameObject enemy, bool isAlreadyDead)
        {
            if (isAlreadyDead) return true;

            var hm = enemy.GetComponent<HealthManager>();
            if (hm == null) return false;

            // most of the code here is from EnemyHPBar
            EnemyDeathEffects ede = enemy.GetComponent<EnemyDeathEffects>();
            EnemyDeathTypes? deathType = ede == null
                ? null
                : DEATH_FI?.GetValue(ede) as EnemyDeathTypes?;
            if (hm.hp >= 200 || deathType == EnemyDeathTypes.LargeInfected)
            {
                bosses.Add((enemy, hm.hp));
            }
            return false;
        }

        private void LoadGame(int id)
        {
            gamestart = DateTime.UtcNow;
            takenTotalHits = 0;
        }

        private void Locate(string targetScene)
        {
            currentScene = targetScene;
        }

        private void Update(object sender, EventArgs e)
        {
            SetRPCPlaying();
            discord.RunCallbacks();
        }
    }

    public class RPCGlobalSettings
    {
        public bool AlwaysShowCompletion = false;
        public bool ShowTotalSaveTime = false;
        public bool BossHPShowPercentage = true;

        public bool CountTakenHits = false;
        public bool ShowBossTimer = false;

        public int StatsRow1 = 1;
        public int StatsRow2 = 2;
        public int StatsRow3 = 3;

        public bool HideLocation = false;
        public bool HideStats = false;
        public bool HideEverything = false;
        public bool HideAbsolutelyEverything = false;
    }
}