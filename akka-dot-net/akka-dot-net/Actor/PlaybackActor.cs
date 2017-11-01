using System;
using akka_dot_net.Message;
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
                case PlayMovieMessage _:
                {
                    if (message is PlayMovieMessage outputMessage)
                    {
                        Console.WriteLine("Playback Actor Title ::: " + outputMessage.MovieTitle);
                        Console.WriteLine("Playback Actor OD ::: " + outputMessage.UserId);
                    }
                }
                    break;
                default:
                    Unhandled(message);
                    break;
            }
        }
    }
}