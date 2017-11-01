using System;
using Akka.Actor;

namespace akka_dot_net.Actor
{
    public class PlaybackActor : UntypedActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a PlaybackActor");
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case string _:
                    Console.WriteLine("String message ::: " + message);
                    break;
                case int _:
                    Console.WriteLine("My Int Message ::: " + message);
                    break;
                default:
                    Unhandled(message);
                    break;
            }
        }
    }
}