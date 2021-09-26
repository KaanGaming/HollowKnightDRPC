using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;
using Discord;
using Modding;
using System.Collections;
using UnityEngine;

namespace HollowKnightDRPC
{
    public partial class HollowKnightDRPC
    {
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

        public void PlayerRPC()
        {
            TimeSpan timeplayed = new TimeSpan(0, 0, Convert.ToInt32(GameManager.instance.PlayTime));

            GameMode gm = PlayerData.instance.permadeathMode > 0 ? GameMode.SteelSoul :
                PlayerData.instance.bossRushMode ? GameMode.Godseeker : GameMode.Normal;

            bool bossperc = Settings.BossHPShowPercentage;

            int masks = PlayerData.instance.maxHealth;
            int hp = PlayerData.instance.health;

            bool paused = GameManager.instance.IsGamePaused();

            int geo = PlayerData.instance.geo;
            act.Details =
                (paused ? "(Paused) " : "") +
                ((Settings.ShowTotalSaveTime && !paused) ? $"({Math.Floor(timeplayed.TotalHours).ToString().PadLeft(2, '0')}:{timeplayed.Minutes.ToString().PadLeft(2, '0')}) " : "")
                + RoomNames.GetRoomName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            TimeSpan t = gamestart - new DateTime(1970, 1, 1);
            act.Timestamps.Start = (long)t.TotalSeconds;
            switch (gm)
            {
                case GameMode.Normal:
                    act.Assets.LargeText = "Mod version " + GetVersion();
                    act.Assets.LargeImage = "normal";
                    break;
                case GameMode.SteelSoul:
                    act.Assets.LargeImage = "steelsoul";
                    act.Assets.LargeText = "Steel Soul (Mod version " + GetVersion() + ")";
                    break;
                case GameMode.Godseeker:
                    act.Assets.LargeImage = "godseeker";
                    act.Assets.LargeText = "Godseeker (Mod version " + GetVersion() + ")";
                    break;
            }

            RPCAssets small = RoomNames.GetSmallAsset(RoomNames.GetRoomName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name));

            if (small.Image != "") act.Assets.SmallImage = small.Image;
            if (small.Text != "") act.Assets.SmallText = small.Text;

            if (!PlayerData.instance.equippedCharm_27)
                act.State = hp + PlayerData.instance.healthBlue + "/" + masks + " HP - ";
            else
                act.State = hp + PlayerData.instance.healthBlue + " HP - ";

            ticksuntilcheck -= 1;

            

            if (ticksuntilcheck == 0)
            {
                ticksuntilcheck = 60;
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

                if (bosses.Count < 1) displayBossHP = false;
            }

            

            if (displayBossHP)
            {
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
                            if (boss.name == "Lobster") act.State += !bossperc ? $" God {hm.hp}/{bmaxhp}" : $" God {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                            if (boss.name == "Lancer" && oromato_phase == 1) act.State += !bossperc ? $" Tamer {hm.hp}/{bmaxhp}" : $" Tamer {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                        }
                        else
                        {
                            if (multibossstate == 0) act.State += !bossperc ? $" {hm.hp}/{bmaxhp}" : $" {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";

                            if (multibossstate == 2) act.State += first ? (!bossperc ? $" {hm.hp}/{bmaxhp}" : $" {Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}") : !bossperc ? $"+{hm.hp}/{bmaxhp}" : $"+{Math.Floor((float)hm.hp / bmaxhp * 1000) / 10}%";
                            if (multibossstate == 3) act.State += !bossperc ? $" {boss.name} {hm.hp}/{bmaxhp}" : $" {boss.name} {Math.Floor((float)hm.hp / bmaxhp * 1000) /10}%";
                            first = false;
                        }
                    }
                }
                if (multibossstate == 1) act.State += (!bossperc ? $" {combinehp}/{combinemaxhp}" : $" {Math.Floor((float)combinehp / combinemaxhp * 1000) / 10}%") + $" ({existingBosses.Count})";
            }
            else
            {
                act.State += geo + " Geo";

                if (PlayerData.instance.unlockedCompletionRate || Settings.AlwaysShowCompletion)
                    act.State += " - " + PlayerData.instance.completionPercentage + "%";
            }
        }

        public void MenuRPC()
        {
            act.Details = "In Menu";
            act.Assets.LargeImage = "normal";
            act.Assets.LargeText = "Discord RPC Mod " + GetVersion();
            act.Assets.SmallImage = null;
            act.State = null;
            act.Timestamps = new ActivityTimestamps();
        }

        public void SetRPCPlaying()
        {
            if (HeroController.instance != null) PlayerRPC();
            else MenuRPC();

            rpc.UpdateActivity(act, res => { });
        }
    }
}
