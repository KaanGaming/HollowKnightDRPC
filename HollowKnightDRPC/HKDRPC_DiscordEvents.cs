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
        public enum GameMode
        {
            Normal,
            SteelSoul,
            Godseeker
        }

        public void PlayerRPC()
        {
            GameMode gm = PlayerData.instance.permadeathMode > 0 ? GameMode.SteelSoul : PlayerData.instance.bossRushMode ? GameMode.Godseeker : GameMode.Normal;

            int masks = PlayerData.instance.maxHealth;
            int hp = PlayerData.instance.health;

            int soulvessels = PlayerData.instance.MPReserveMax / 33;

            int geo = PlayerData.instance.geo;
            SceneManager sm = new SceneManager();
            act.Details = RoomNames.GetRoomName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            TimeSpan t = gamestart - new DateTime(1970, 1, 1);
            act.Timestamps.Start = (long)t.TotalSeconds;
            switch (gm)
            {
                case GameMode.Normal:
                    act.Assets.LargeText = "Discord RPC " + GetVersion() + " by @KaanGaming#7447";
                    act.Assets.LargeImage = "normal";
                    break;
                case GameMode.SteelSoul:
                    act.Assets.LargeImage = "steelsoul";
                    act.Assets.LargeText = "Steel Soul - Discord RPC " + GetVersion() + " by @KaanGaming#7447";
                    break;
                case GameMode.Godseeker:
                    act.Assets.LargeImage = "godseeker";
                    act.Assets.LargeText = "Godseeker - Discord RPC " + GetVersion() + " by @KaanGaming#7447";
                    break;
            }

            Assetz small = RoomNames.GetSmallAsset(RoomNames.GetRoomName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name));

            if (small.Image != "") act.Assets.SmallImage = small.Image;
            if (small.Text != "") act.Assets.SmallText = small.Text;

            if (!PlayerData.instance.equippedCharm_27)
                act.State = (hp + PlayerData.instance.healthBlue) + "/" + masks + " Masks - ";
            else
                act.State = (hp + PlayerData.instance.healthBlue) + " Joni Masks - ";
            if (soulvessels > 0) act.State += soulvessels + " Soul Vessels - ";
            act.State += geo + " Geo";
        }

        public void MenuRPC()
        {
            act.Details = "In Menu";
            act.Assets.LargeImage = "normal";
            act.Assets.LargeText = "Discord RPC " + GetVersion() + " by @KaanGaming#7447";
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
