using System;
using UnityEngine;

namespace HollowKnightDRPC
{
    public class FunnyUpdate : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            EventNode.RaiseNode(1, this);
        }
    }
}