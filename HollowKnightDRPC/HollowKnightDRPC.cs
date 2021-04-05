using Modding;
using UnityEngine;
using System.Net;
using System.Reflection;
using System.IO;
using System.IO.Compression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;

namespace HollowKnightDRPC
{
    public partial class HollowKnightDRPC : Mod
    {
        public HollowKnightDRPC() : base("Hollow Knight Discord RPC (CHECK README!)")
        {
            
        }

        public Discord.Discord discord = null;

        public string currentScene = "";

        public ActivityManager rpc = null;

        public Activity act = new Activity();

        public long id = 827571383080845322;

        public DateTime gamestart = DateTime.UtcNow;

        public override string GetVersion()
        {
            return "1.1.0 Beta";
        }

        public override void Initialize()
        {
            Log("Establishing Discord RPC...");
                discord = new Discord.Discord(id, (ulong)CreateFlags.Default);

                ModHooks.Instance.HeroUpdateHook += Update;
                ModHooks.Instance.SavegameLoadHook += LoadGame;
                ModHooks.Instance.SceneChanged += Locate;

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
            

            ModHooks.Instance.ApplicationQuitHook += GameClosing;
        }

        private void LoadGame(int id)
        {
            gamestart = DateTime.UtcNow;
        }

        private void Locate(string targetScene)
        {
            currentScene = targetScene;
        }

        private void Update()
        {
            SetRPCPlaying();
            discord.RunCallbacks();
        }

        private void GameClosing()
        {

        }
    }
}
