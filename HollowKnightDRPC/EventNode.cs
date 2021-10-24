using System;

namespace HollowKnightDRPC
{
    public static class EventNode
    {
        public static event EventHandler Node1;
        public static event EventHandler Node2;
        public static event EventHandler Node3;
        public static event EventHandler Node4;
        public static event EventHandler Node5;

        public static FailureMessage? RaiseNode(byte id, object sender)
        {
            FailureMessage? message = null;

            switch (id)
            {
                case 1:
                    Node1(sender, new EventArgs());
                    break;
                case 2:
                    Node2(sender, new EventArgs());
                    break;
                case 3:
                    Node3(sender, new EventArgs());
                    break;
                case 4:
                    Node4(sender, new EventArgs());
                    break;
                case 5:
                    Node5(sender, new EventArgs());
                    break;
                default:
                    message = new FailureMessage { Message = "Invalid ID" };
                    break;
            }

            return message;
        }
    }

    public struct FailureMessage
    {
        public string Message { get; set; }
    }
}
