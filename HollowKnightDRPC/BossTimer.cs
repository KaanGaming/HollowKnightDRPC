using System;
using Modding;
using UnityEngine;
using HutongGames.PlayMaker;

namespace HollowKnightDRPC
{
    public partial class HollowKnightDRPC
    {
        float bossTimer = 0.0f;
        GameObject knight = null;
        
        public void TimerUpdate()
        {
            if (bosses.Count > 0)
            {
                bossTimer += Time.deltaTime;
                if (knight == null) GameObject.Find("Knight");
                PlayMakerFSM roarLock = null;
                foreach (PlayMakerFSM fsm in knight.GetComponents<PlayMakerFSM>())
                {
                    if (fsm.FsmName == "Roar Lock")
                    {
                        roarLock = fsm;
                        break;
                    }
                }
                if (roarLock == null) return;
                
            }
        }
    }
}