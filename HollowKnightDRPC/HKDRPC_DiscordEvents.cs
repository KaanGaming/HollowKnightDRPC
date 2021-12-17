using Discord;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HollowKnightDRPC
{
    public partial class HollowKnightDRPC
    {
        Stopwatch bosstimer;

        byte ticksuntilcheck = 60;
        bool displayBossHPText = true;

        byte oromato_phase = 0;

        int watchknight_maxhp = 0;
        bool watchknight_maxhp_done = false;
        int watchknights = 0;

        int soulmaster_maxhp = 0;
        bool soulmaster_maxhp_done = false;
        int soulmasters = 0;

        int soultyrant_maxhp = 0;
        bool soultyrant_maxhp_done = false;
        int soultyrants = 0;

        int oblobble_maxhp = 0;
        bool oblobble_maxhp_done = false;
        int oblobbles = 0;

        int vking_maxhp = 0;
        bool vking_maxhp_done = false;
        int vkings = 0;

        int mlord_maxhp = 0;
        bool mlord_maxhp_done = false;
        int mlords = 0;

        public enum GameMode
        {
            Normal,
            SteelSoul,
            Godseeker
        }

        bool lostctrl = false;
        bool waslostctrl = false;
        public void PlayerRPC()
        {
            TimeSpan timeplayed = new TimeSpan(0, 0, Convert.ToInt32(GameManager.instance.PlayTime));

            GameMode gm = PlayerData.instance.permadeathMode > 0 ? GameMode.SteelSoul :
                PlayerData.instance.bossRushMode ? GameMode.Godseeker : GameMode.Normal;

            bool bossperc = Settings.BossHPShowPercentage;

            if (Settings.CountTakenHits)
            {
                if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.LeftAlt))
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        takenTotalHits = 0;
                        takenHits = 0;
                    }
                }
            }

            int masks = PlayerData.instance.maxHealth;
            int hp = PlayerData.instance.health;

            bool paused = GameManager.instance.IsGamePaused();

            int geo = PlayerData.instance.geo;
            if (!Settings.HideEverything)
            {
                act.Details =
                (paused ? "(Paused) " : "") +
                ((Settings.ShowTotalSaveTime && !paused) ? $"({Math.Floor(timeplayed.TotalHours).ToString().PadLeft(2, '0')}:{timeplayed.Minutes.ToString().PadLeft(2, '0')}) " : "")
                + (Settings.HideLocation ? "" : RoomNames.GetRoomName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name));
            }
            else
            {
                act.Details = paused ? "(Paused)" : "";
            }

            TimeSpan t = gamestart - new DateTime(1970, 1, 1);
            act.Timestamps.Start = (long)t.TotalSeconds;
            switch (gm)
            {
                case GameMode.Normal:
                    act.Assets.LargeText = "Mod version " + GetVersion();
                    act.Assets.LargeImage = "normal";
                    break;
                case GameMode.SteelSoul:
                    act.Assets.LargeImage = Settings.HideEverything ? "normal" : "steelsoul";
                    act.Assets.LargeText = Settings.HideEverything ?
                        "Mod version " + GetVersion()
                        : "Steel Soul (Mod version " + GetVersion() + ")";
                    break;
                case GameMode.Godseeker:
                    act.Assets.LargeImage = Settings.HideEverything ? "normal" : "godseeker";
                    act.Assets.LargeText = Settings.HideEverything ?
                        "Mod version " + GetVersion()
                        : "Godseeker (Mod version " + GetVersion() + ")";
                    break;
            }

            RPCAssets small = RoomNames.GetSmallAsset(RoomNames.GetRoomName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name));

            if (small.Image != "" && (!Settings.HideEverything || !Settings.HideLocation)) act.Assets.SmallImage = small.Image;
            if (small.Text != "" && (!Settings.HideEverything || !Settings.HideLocation)) act.Assets.SmallText = small.Text;
            if (Settings.HideEverything || Settings.HideLocation) { act.Assets.SmallText = ""; act.Assets.SmallImage = ""; }

            if (!Settings.HideEverything && !Settings.HideStats)
            {
                if (Settings.CountTakenHits)
                {
                    act.State = $"{takenHits} hits ({takenTotalHits})" + (displayBossHP ? " - " : "");
                }
                else
                {
                    act.State = GetStatById(Settings.StatsRow1, displayBossHP ? (byte)2 : (byte)0);
                }
            }
            else
            {
                act.State = "";
            }

            ticksuntilcheck -= 1;



            if (ticksuntilcheck == 0)
            {
                ticksuntilcheck = 2;
                if (bosses.Count > 0)
                {
                    displayBossHP = true;
                    List<(GameObject boss, int bmaxhp)> newblist = new List<(GameObject boss, int bmaxhp)>();
                    foreach ((GameObject boss, int bmaxhp) in bosses)
                    {
                        if (boss == null) continue;

                        if (boss.name == "Oro" || boss.name == "Mato") displayBossHPText = false;
                        if (boss.name == "Lobster" || boss.name == "Lancer") displayBossHPText = false;

                        var hm = boss.GetComponent<HealthManager>();
                        if (hm == null) continue;

                        if (!hm.isDead) newblist.Add((boss, bmaxhp));
                    }
                    bosses = newblist;
                }

                if (bosses.Count < 1)
                {
                    displayBossHP = false;
                }
            }



            if (displayBossHP && !Settings.HideEverything)
            {
                #region displayBossHP
                act.State += displayBossHPText ? "Boss HP:" : "";
                // Multibossstate can be different values, meaning different things:
                // 0: show all boss health individually
                // 1: add boss health together (mantis lords, watcher knights, oblobbles)
                // 2: show all boss health individually together with a plus icon (god tamer)
                // 3: show all boss health individually with name (oro & mato)
                byte multibossstate = 0;
                int mbs2 = -1;
                bool mbs_decided = false;
                bool first = true;
                bool wait = false;
                // for some strange reason, mantis lords come up twice in the bosses array so i put this here to prevent any
                // duplicate bosses from showing
                List<string> existingBosses = new List<string>();
                int combinehp = 0;
                int combinemaxhp = 0;
                string scenename = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                foreach ((GameObject boss, int bmaxhp) in bosses)
                {
                    if (boss == null) continue;

                    if (existingBosses.Exists(a => a == boss.name)) continue;
                    existingBosses.Add(boss.name);

                    var hm = boss.GetComponent<HealthManager>();

                    if (hm == null) continue;

                    if (boss.name == "Oro" && hm.hp < 0) oromato_phase = 1;

                    if ((boss.name == "Oro" || boss.name == "Mato") && !mbs_decided) { mbs_decided = true; multibossstate = 3; mbs2 = 4; }
                    if ((boss.name == "Lancer" || boss.name == "Lobster") && !mbs_decided) { mbs_decided = true; multibossstate = 3; mbs2 = 7; }
                    if (scenename == "GG_Soul_Master" || scenename == "GG_Soul_Tyrant") multibossstate = 1;
                    if (boss.name.StartsWith("Black Knight") && !mbs_decided) { wait = true; mbs_decided = true; multibossstate = 1; mbs2 = 0; }
                    if (boss.name.StartsWith("Mantis Lord S") && !mbs_decided) { wait = false; mbs_decided = true; multibossstate = 1; mbs2 = 1; }
                    if (boss.name.StartsWith("Giant Buzzer Col") && scenename == "GG_Vengefly_V" && !mbs_decided) { wait = true; mbs_decided = true; multibossstate = 1; mbs2 = 2; }
                    if (boss.name.StartsWith("Mega Fat Bee") && !mbs_decided) { wait = true; mbs_decided = true; multibossstate = 1; mbs2 = 3; }
                    if (boss.name.StartsWith("Dream Mage Lord") && !mbs_decided) { wait = true; mbs_decided = true; multibossstate = 1; mbs2 = 5; }
                    if (boss.name.StartsWith("Mage Lord") && !mbs_decided) { wait = true; mbs_decided = true; multibossstate = 1; mbs2 = 6; }

                    if (boss.name.StartsWith("Black Knight") && !watchknight_maxhp_done) { watchknight_maxhp += bmaxhp; watchknights++; }
                    if (boss.name.StartsWith("Mantis Lord S") && !mlord_maxhp_done) { mlord_maxhp += bmaxhp; mlords++; }
                    if (boss.name.StartsWith("Mega Fat Bee") && !oblobble_maxhp_done) { oblobble_maxhp += bmaxhp; oblobbles++; }
                    if (boss.name.StartsWith("Giant Buzzer Col") && scenename == "GG_Vengefly_V" && !vking_maxhp_done) { vking_maxhp += bmaxhp; vkings++; }
                    if (boss.name.StartsWith("Dream Mage Lord") && !soultyrant_maxhp_done) { soultyrant_maxhp += bmaxhp; soultyrants++; }
                    if (boss.name.StartsWith("Mage Lord") && !soulmaster_maxhp_done) { soulmaster_maxhp += bmaxhp; soulmasters++; }
                    if (watchknights >= 6) { watchknight_maxhp_done = true; wait = false; }
                    if (oblobbles >= 2) { oblobble_maxhp_done = true; wait = false; }
                    if (vkings >= 2 && scenename == "GG_Vengefly_V") { vking_maxhp_done = true; wait = false; }
                    if (mlords >= 2 && scenename == "GG_Mantis_Lords") { mlord_maxhp_done = true; wait = false; }
                    if (mlords >= 3 && scenename == "GG_Mantis_Lords_V") { mlord_maxhp_done = true; wait = false; }
                    if (soulmasters >= 2) { soulmaster_maxhp_done = true; wait = false; }
                    if (soultyrants >= 2) { soultyrant_maxhp_done = true; wait = false; }

                    if (hm.hp < 0.001) continue;

                    combinehp += hm.hp;
                    if (mbs2 == 0) combinemaxhp = watchknight_maxhp;
                    if (mbs2 == 1) combinemaxhp = mlord_maxhp;
                    if (mbs2 == 2) combinemaxhp = vking_maxhp;
                    if (mbs2 == 3) combinemaxhp = oblobble_maxhp;
                    if (mbs2 == 5) combinemaxhp = soultyrant_maxhp;
                    if (mbs2 == 6) combinemaxhp = soulmaster_maxhp;

                    if (!wait)
                    {
                        if (mbs2 == 4)
                        {
                            if (boss.name == "Oro") act.State += !bossperc ? $" Oro {hm.hp}/{bmaxhp}" : $" Oro {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                            if (boss.name == "Mato" && oromato_phase == 1) act.State += !bossperc ? $" Mato {hm.hp}/{bmaxhp}" : $" Mato {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                        }
                        else if (mbs2 == 7)
                        {
                            if (boss.name == "Lobster") act.State += !bossperc ? $" Beast {hm.hp}/{bmaxhp}" : $" Beast {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                            if (boss.name == "Lancer") act.State += !bossperc ? $" Tmr {hm.hp}/{bmaxhp}" : $" Tmr {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                        }
                        else
                        {
                            if (multibossstate == 0) act.State += !bossperc ? $" {hm.hp}/{bmaxhp}" : $" {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";

                            if (multibossstate == 2) act.State += first ? (!bossperc ? $" {hm.hp}/{bmaxhp}" : $" {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}") : !bossperc ? $"+{hm.hp}/{bmaxhp}" : $"+{Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                            if (multibossstate == 3) act.State += !bossperc ? $" {boss.name} {hm.hp}/{bmaxhp}" : $" {boss.name} {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                            first = false;
                        }
                    }
                }
                if (multibossstate == 1) act.State += (!bossperc ? $" {combinehp}/{combinemaxhp}" : $" {Math.Floor((float)combinehp / combinemaxhp * 1000) / 10}%") + $" ({existingBosses.Count})";
                #endregion
            }
            else if (!Settings.HideEverything && !Settings.HideStats)
            {
                act.State += GetStatById(Settings.StatsRow2, 1);

                act.State += GetStatById(Settings.StatsRow3, 1);
            }
        }

        public void MenuRPC()
        {
            act.Details = "In Menu";
            act.Assets.LargeImage = "normal";
            act.Assets.LargeText = "Rich Presence Mod " + GetVersion();
            act.Assets.SmallImage = null;
            act.State = null;
            act.Timestamps = new ActivityTimestamps();
        }

        public void NothingRPC()
        {
            act.Details = "";
            act.Assets.LargeImage = "normal";
            act.Assets.LargeText = "Rich Presence Mod " + GetVersion();
            act.Assets.SmallImage = null;
            act.State = null;
            act.Timestamps = new ActivityTimestamps
            {
                
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDash">0: don't include dash<br/>1: include dash before the string<br/>2: include dash after string</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public string GetStatById(int id, byte includeDash)
        {
            #region GetStatById

            var wjournals = PlayerData.instance.trinket1;
            var hseals = PlayerData.instance.trinket2;
            var kidols = PlayerData.instance.trinket3;
            var æggs = PlayerData.instance.trinket4;

            var hp = PlayerData.instance.health;
            var masks = PlayerData.instance.maxHealth;
            if (id == 0) /* NONE */ return "";
            else if (id == 1) // HP
            {
                if (!PlayerData.instance.equippedCharm_27)
                    return (includeDash == 1 ? " - " : "") + (hp + PlayerData.instance.healthBlue) + "/" + masks + " HP" + (includeDash == 2 ? " - " : "");
                else
                    return (includeDash == 1 ? " - " : "") + (hp + PlayerData.instance.healthBlue) + " HP" + (includeDash == 2 ? " - " : "");
            }
            else if (id == 2) /* GEO */ return (includeDash == 1 ? " - " : "") + PlayerData.instance.geo + " Geo" + (includeDash == 2 ? " - " : "");
            else if (id == 3) // COMPLETION
            {
                if (!PlayerData.instance.unlockedCompletionRate && !Settings.AlwaysShowCompletion) return "";
                return (includeDash == 1 ? " - " : "") + PlayerData.instance.completionPercentage + "%" + (includeDash == 2 ? " - " : "");
            }
            else if (id == 4) // SOUL
            {
                float soul = PlayerData.instance.MPCharge + PlayerData.instance.MPReserve;
                int percentage = (int)Math.Floor(soul / 99 * 100);
                return (includeDash == 1 ? " - " : "") + percentage + "% SOUL" + (includeDash == 2 ? " - " : "");
            }
            else if (id == 5) /* Journal Entry Count */ return (includeDash == 1 ? " - " : "") + PlayerData.instance.journalEntriesCompleted + " Entries" + (includeDash == 2 ? " - " : "");
            else if (id == 6) // All Relics
            {
                return (includeDash == 1 ? " - " : "") + (wjournals + hseals + kidols + æggs) + " Relics" + (includeDash == 2 ? " - " : "");
            }
            else if (id == 7) /* Grubs */ return (includeDash == 1 ? " - " : "") + PlayerData.instance.grubsCollected + " Grubs" + (includeDash == 2 ? " - " : "");
            else if (id == 8) /* Simple Key */ return (includeDash == 1 ? " - " : "") + PlayerData.instance.simpleKeys + " SimpleKeys" + (includeDash == 2 ? " - " : "");
            else if (id == 9) /* Elegant Key */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasWhiteKey ? "1 E.Key" : "0 E.Keys") + (includeDash == 2 ? " - " : "");
            else if (id == 10) /* Love Key */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasLoveKey ? "1 LoveKey" : "0 LoveKeys") + (includeDash == 2 ? " - " : "");
            else if (id == 11) /* Shopkeeper's Key */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasSlykey ? "1 S.K.Key" : "0 S.K.Keys") + (includeDash == 2 ? " - " : "");
            else if (id == 12) /* City Crest */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasCityKey ? 1 : 0) + " C.Crest" + (includeDash == 2 ? " - " : "");
            else if (id == 13) /* King's Brand */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasKingsBrand ? 1 : 0) + " K.Brand" + (includeDash == 2 ? " - " : "");
            else if (id == 14) /* Tram Pass */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasTramPass ? 1 : 0) + " T.Pass" + (includeDash == 2 ? " - " : "");
            else if (id == 15) /* Lumafly Lantern */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasLantern ? 1 : 0) + " Lantern" + (includeDash == 2 ? " - " : "");
            else if (id == 16) // Map & Quill
            {
                var hasmap = PlayerData.instance.hasMap;
                var hasquill = PlayerData.instance.hasQuill;
                bool hasall = hasmap && hasquill;
                if (hasall) return (includeDash == 1 ? " - " : "") + "1 Map&Quill" + (includeDash == 2 ? " - " : "");
                else
                {
                    if (hasmap) return (includeDash == 1 ? " - " : "") + "1 Map" + (includeDash == 2 ? " - " : "");
                    else if (hasquill) return (includeDash == 1 ? " - " : "") + "1 Quill" + (includeDash == 2 ? " - " : "");
                    return "";
                }
            }
            else if (id == 17) // Map Count (Map Zones)
            {
                int mapCount = (PlayerData.instance.mapCliffs ? 1 : 0)
                    + (PlayerData.instance.mapDirtmouth ? 1 : 0)
                    + (PlayerData.instance.mapCrossroads ? 1 : 0)
                    + (PlayerData.instance.mapGreenpath ? 1 : 0)
                    + (PlayerData.instance.mapFungalWastes ? 1 : 0)
                    + (PlayerData.instance.mapFogCanyon ? 1 : 0)
                    + (PlayerData.instance.mapMines ? 1 : 0)
                    + (PlayerData.instance.mapOutskirts ? 1 : 0)
                    + (PlayerData.instance.mapRestingGrounds ? 1 : 0)
                    + (PlayerData.instance.mapCity ? 1 : 0)
                    + (PlayerData.instance.mapDeepnest ? 1 : 0)
                    + (PlayerData.instance.mapWaterways ? 1 : 0)
                    + (PlayerData.instance.mapRoyalGardens ? 1 : 0)
                    + (PlayerData.instance.mapAbyss ? 1 : 0)
                    ;
                return (includeDash == 1 ? " - " : "") + mapCount + " Map Zones" + (includeDash == 2 ? " - " : "");
            }
            else if (id == 18) /* Hunter's Journal */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasJournal ? 1 : 0) + " H.Journal" + (includeDash == 2 ? " - " : "");
            else if (id == 19) /* Hunter's Mark */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasHuntersMark ? 1 : 0) + " H.Mark" + (includeDash == 2 ? " - " : "");
            else if (id == 20) // Delicate Flower / Ruined Flower
            {
                if (PlayerData.instance.xunFlowerBroken && PlayerData.instance.hasXunFlower) return (includeDash == 1 ? " - " : "") + "Ruined Flower" + (includeDash == 2 ? " - " : "");
                if (PlayerData.instance.hasXunFlower) return (includeDash == 1 ? " - " : "") + "Delicate Flower" + (includeDash == 2 ? " - " : "");
                return "";
            }
            else if (id == 21) /* Godtuner */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.hasGodfinder ? 1 : 0) + " Godtuner" + (includeDash == 2 ? " - " : "");
            else if (id == 22) /* Shard Count */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.heartPieces + (PlayerData.instance.maxHealthBase * 4)) + " Shards" + (includeDash == 2 ? " - " : "");
            else if (id == 23) /* Fragment Count */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.vesselFragments + (PlayerData.instance.MPReserveMax / 33 * 3)) + " Fragments" + (includeDash == 2 ? " - " : "");
            else if (id == 24) /* Soul Vessels */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.MPReserveMax / 33) + " S.Vessels" + (includeDash == 2 ? " - " : "");
            else if (id == 25) /* Salubra's Blessing */ return (includeDash == 1 ? " - " : "") + (PlayerData.instance.salubraBlessing ? 1 : 0) + " Blessing" + (includeDash == 2 ? " - " : "");
            else if (id == 26) /* Pale Ore */ return (includeDash == 1 ? " - " : "") + PlayerData.instance.ore + " Ores" + (includeDash == 2 ? " - " : "");
            else if (id == 27) /* Essence */ return (includeDash == 1 ? " - " : "") + PlayerData.instance.dreamOrbs + " Essence" + (includeDash == 2 ? " - " : "");
            else if (id == 28) /* Rancid Egg */ return (includeDash == 1 ? " - " : "") + PlayerData.instance.rancidEggs + " R.Eggs" + (includeDash == 2 ? " - " : "");
            else if (id == 29) /* Wanderer's Journal */ return (includeDash == 1 ? " - " : "") + wjournals + " W.Journals" + (includeDash == 2 ? " - " : "");
            else if (id == 30) /* Hallownest Seal */ return (includeDash == 1 ? " - " : "") + hseals + " H.Seals" + (includeDash == 2 ? " - " : "");
            else if (id == 31) /* King's Idol */ return (includeDash == 1 ? " - " : "") + kidols + " K.Idols" + (includeDash == 2 ? " - " : "");
            else if (id == 32) /* Arcane Egg */ return (includeDash == 1 ? " - " : "") + æggs + " A.Eggs" + (includeDash == 2 ? " - " : "");
            else throw new ArgumentOutOfRangeException("id", "ID must be under or equal to 32 and over or equal to 0.");
            #endregion
        }

        public void SetRPCPlaying()
        {
            if (Settings.HideAbsolutelyEverything) NothingRPC();

            if (HeroController.instance != null) PlayerRPC();
            else MenuRPC();

            rpc.UpdateActivity(act, res => { });
        }
    }
}