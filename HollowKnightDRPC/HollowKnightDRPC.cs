using Modding;
using UnityEngine;
using System.Net;
using System.Reflection;
using System.IO;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace HollowKnightDRPC
{
    public partial class HollowKnightDRPC : Mod
    {
        public HollowKnightDRPC() : base("Hollow Knight Discord RPC")
        {
            
        }

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain,
                                      SslPolicyErrors sslPolicyErrors)
        {
            return true;;
        }

        public Discord.Discord discord = null;

        public string currentScene = "";

        public ActivityManager rpc = null;

        public Activity act = new Activity();

        public long id = 827571383080845322;

        public DateTime gamestart = DateTime.UtcNow;

        public GameObject ooobject;

        public override string GetVersion()
        {
            return "1.1.3 Beta";
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

        public override void Initialize()
        {
            Log("Mod initializing");
            ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;

            if (!File.Exists(".\\NO SDK CHECK.drpc"))
            {
                if (!Directory.Exists(".\\hollow_knight_Data\\Plugins\\x86") || !Directory.Exists(".\\hollow_knight_Data\\Plugins\\x86_64")) {
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

                    if (!Directory.Exists(".\\hollow_knight_Data\\Plugins\\x86"))
                        Directory.CreateDirectory(".\\hollow_knight_Data\\Plugins\\x86");
                    if (!Directory.Exists(".\\hollow_knight_Data\\Plugins\\x86_64"))
                        Directory.CreateDirectory(".\\hollow_knight_Data\\Plugins\\x86_64");

                    if (!File.Exists(".\\hollow_knight_Data\\Plugins\\x86\\discord_game_sdk.dll")) File.WriteAllBytes(".\\hollow_knight_Data\\Plugins\\x86\\discord_game_sdk.dll", GetEmbeddedResource(sdk86dll));
                    if (!File.Exists(".\\hollow_knight_Data\\Plugins\\x86\\discord_game_sdk.dll.lib")) File.WriteAllBytes(".\\hollow_knight_Data\\Plugins\\x86\\discord_game_sdk.dll.lib", GetEmbeddedResource(sdk86lib));
                    if (!File.Exists(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.dll")) File.WriteAllBytes(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.dll", GetEmbeddedResource(sdkdll));
                    if (!File.Exists(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.dll.lib")) File.WriteAllBytes(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.dll.lib", GetEmbeddedResource(sdklib));
                    if (!File.Exists(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.bundle")) File.WriteAllBytes(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.bundle", GetEmbeddedResource(sdkbundle));
                    if (!File.Exists(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.dylib")) File.WriteAllBytes(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.dylib", GetEmbeddedResource(sdkdylib));
                    if (!File.Exists(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.so")) File.WriteAllBytes(".\\hollow_knight_Data\\Plugins\\x86_64\\discord_game_sdk.so", GetEmbeddedResource(sdkso));
                }
            }

            // DEPENDENCY CODE
            // ---------------------------------------------------------------------------------
            // DISCORD CODE

            discord = new Discord.Discord(id, (ulong)CreateFlags.NoRequireDiscord);

            ooobject = new GameObject("rpcstufflmao");

            ooobject.AddComponent<FunnyUpdate>();

            EventNode.Node1 += Update;
            ModHooks.SavegameLoadHook += LoadGame;
            ModHooks.SceneChanged += Locate;

            rpc = discord.GetActivityManager();

            discord.SetLogHook(Discord.LogLevel.Error, (lv, log) =>
            {
                Log((int)lv + " - " + log);
            });

            act = new Activity()
            {
                Details = "In Menus",
                State = "Doing stuff lolz",
                Assets =
                {
                    LargeImage = "normal",
                    LargeText = "Discord RPC " + GetVersion() + " by @KaanGaming#7447"
                }
            };

            rpc.UpdateActivity(act, res => { });
        }

        private void LoadGame(int id)
        {
            gamestart = DateTime.UtcNow;
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
}
