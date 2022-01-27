using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HollowKnightDRPC
{
    public static class PantheonUtil
    {
        public static bool InPantheon { get => BossSequenceController.IsInSequence; }

        public static int? PantheonID { get
            {
                BossSequenceController.BossSequenceData seq = null;

                try
                {
                    seq = (BossSequenceController.BossSequenceData)
                    typeof(BossSequenceController).GetField("currentData", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
                }
                catch (FieldAccessException e)
                {
                    HollowKnightDRPC.Instance.LogError("FieldAccessException: " + e.Message);
                }
                catch (Exception e)
                {
                    HollowKnightDRPC.Instance.LogError(e.Message);
                }

                int result = -1;

                if (seq != null)
                {
                    int.TryParse(seq.bossSequenceName.Split(' ')[3], out result);
                }

                return result < 0 ? null : result;
            } }
        public static string PantheonName
        {
            get
            {
                if (!PantheonID.HasValue)
                    return "";
                
                switch (PantheonID.Value)
                {
                    case 1:
                        return "of the Master";
                    case 2:
                        return "of the Artist";
                    case 3:
                        return "of the Sage";
                    case 4:
                        return "of the Knight";
                    case 5:
                        return "of Hallownest";
                    default:
                        return "of the Unknown";
                }
            }
        }

        public static int RealCBoss { get => BossSequenceController.BossIndex; }
        /// <summary>
        /// if -1 then it's bench<br/>
        /// if -2 then it's godhome scene<br/>
        /// if -3 then it's pantheon ending<br/>
        /// if -4 then it's unsupported
        /// </summary>
        public static int CurrentBoss
        {
            get
            {
                if (!PantheonID.HasValue)
                    return BossSequenceController.BossIndex;
                int pid = PantheonID.Value;
                int bi = BossSequenceController.BossIndex;

                string roomid = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                bool isspa() => roomid == "GG_Spa";
                bool isggbreak() => roomid == "GG_Engine" || roomid == "GG_Engine_Root" || roomid == "GG_Unn" || roomid == "GG_Wyrm";
                bool isending() => roomid == "GG_End_Sequence";

                if (isspa())
                    return -1;
                if (isggbreak())
                    return -2;
                if (isending())
                    return -3;

                int nbi = bi;

                if (pid > 0 && pid < 5)
                {
                    if (nbi > 4)
                        bi--;
                    if (nbi > 9)
                        bi--;
                }
                if (pid == 5)
                {
                    if (nbi > 6)
                        bi--;
                    if (nbi >= 12)
                        bi--;
                    if (nbi >= 18)
                        bi--;
                    if (nbi >= 24)
                        bi--;
                    if (nbi >= 31)
                        bi -= 2;
                    if (nbi >= 37)
                        bi--;
                    if (nbi >= 44)
                        bi -= 2;
                    if (nbi >= 51)
                        bi -= 2;
                }

                return bi + 1;
            }
        }
        public static int BossCount
        {
            get
            {
                if (!PantheonID.HasValue) return 0;
                int pid = PantheonID.Value;
                if (pid > 0 && pid < 5)
                {
                    return 10;
                }
                if (pid == 5)
                {
                    return 42;
                }
                return BossSequenceController.BossCount;
            }
        }
        public static int RealBossCount { get => BossSequenceController.BossCount; }
        public static int MaxHP { get => ShellBind ? BossSequenceController.BoundMaxHealth : PlayerData.instance.maxHealth; }

        public static bool CharmBind { get => BossSequenceController.BoundCharms; }
        public static bool ShellBind { get => BossSequenceController.BoundShell; }
        public static bool SoulBind { get => BossSequenceController.BoundSoul; }
        public static bool NailBind { get => BossSequenceController.BoundNail; }
        public static bool AllBind { get => CharmBind && ShellBind && SoulBind && NailBind; }
        public static bool AnyBind { get => CharmBind || ShellBind || SoulBind || NailBind; }
    }

    public static class HoGUtil
    {
        public static bool InHoGBoss { get => BossSceneController.IsBossScene && !PantheonUtil.InPantheon; }
        public static bool InBoss { get => BossSceneController.IsBossScene; }

        /// <summary>
        /// if 0 then attuned<br/>
        /// if 1 then ascended<br/>
        /// if 2 then radiant<br/>
        /// </summary>
        public static int Difficulty { get => BossSceneController.Instance.BossLevel; }

        public static List<GGBoss> GGBosses
        {
            get
            {
                List<GGBoss> bosses = new List<GGBoss>();

                foreach (var b in BossSceneController.Instance.BossHealthLookup)
                {
                    GGBoss boss = new GGBoss();
                    boss.GOName = b.Key.gameObject.name;
                    boss.HP = (b.Key.hp, b.Value.adjustedHP);
                    bosses.Add(boss);
                }
                return bosses;
            }
        }
    }

    public struct GGBoss
    {
        public string GOName;
        public (int cur, int max) HP;
    }
}
