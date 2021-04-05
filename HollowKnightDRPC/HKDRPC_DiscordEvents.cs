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

        public void SetRPCPlaying()
        {
            GameMode gm = PlayerData.instance.permadeathMode > 0 ? GameMode.SteelSoul : PlayerData.instance.bossRushMode ? GameMode.Godseeker : GameMode.Normal;

            int masks = PlayerData.instance.maxHealth;
            int hp = PlayerData.instance.health;

            int soulvessels = PlayerData.instance.MPReserveMax / 33;

            int geo = PlayerData.instance.geo;
            SceneManager sm = new SceneManager();

            act.Details = "" + RoomNames.GetRoomName(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
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

            act.State = hp + "/" + masks + " Masks - ";
            if (soulvessels > 0) act.State += soulvessels + " Soul Vessels - ";
            act.State += geo + " Geo";

            rpc.UpdateActivity(act, res => { });
        }
    }
}
