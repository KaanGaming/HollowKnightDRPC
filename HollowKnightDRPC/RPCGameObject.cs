#pragma warning disable IDE0051 // Remove unused private members
using UnityEngine;

namespace HollowKnightDRPC
{
    /* Instead of using ModHooks.Instance.HeroUpdateHook, I've decided to create
     * a Game Object that will not be destroyed and runs a function continuously
     * so the RPC works everywhere, instead of only scenes that have The Knight.
     */
    public class RPCGameObject : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            EventNode.RaiseNode(1, this);
        }
    }
}