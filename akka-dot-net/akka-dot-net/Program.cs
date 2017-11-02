using System;
using System.Threading;
using akka_dot_net.Actor;
using akka_dot_net.Message;
using Akka.Actor;

namespace akka_dot_net
{
    public class Program
    {
        private static ActorSystem _movieStreamingActorSystem;

        private static void Main(string[] args)
        {
            CreateSystem();

            //FirstActor();

            //SecondActor();

            DangerousActor();

            Console.ReadKey();

            ShutDown();

            Console.ReadKey();
        }

        private static void CreateSystem()
        {
            _movieStreamingActorSystem = ActorSystem.Create("MovieStreamingSystem");
            Console.WriteLine("Actor System Created!!");
        }

        private static void ShutDown()
        {
            _movieStreamingActorSystem.Terminate();
            _movieStreamingActorSystem.WhenTerminated.Wait(1000);
            Console.WriteLine("System Shutdown");
        }

        private static void SecondActor()
        {
            // Custom type message
            var playbackActorImprovedProps = Props.Create<PlaybackImprovedActor>();
            var playbackActorImprovedRef = _movieStreamingActorSystem.ActorOf(playbackActorImprovedProps, "PlaybackImprovedActor");

            // Send improved message
            playbackActorImprovedRef.Tell(new PlayMovieMessage("Improved Movie Title", 1234));
            playbackActorImprovedRef.Tell(new PlayMovieMessage("My Poco Message", 123));
        }

        private static void FirstActor()
        {
            Props playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = _movieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");

            // Send some messages
            playbackActorRef.Tell("New World Order");
            playbackActorRef.Tell(123);
        }

        private static void DangerousActor()
        {
            var dangerousActorProps = Props.Create<DangerousActor>();
            var dangerounsActorRef = _movieStreamingActorSystem.ActorOf(dangerousActorProps, "DangerousActor");

            // Send some messages
            var ask = dangerounsActorRef.Ask<string>("OK Message..");
            Console.WriteLine(ask.Result);

            for (int i = 0; i < 10; i++)
            {
                DangerousCall(dangerounsActorRef);
                Thread.Sleep(1000);
            }
        }

        private static void DangerousCall(IActorRef dangerounsActorRef)
        {
            var task = dangerounsActorRef.Ask<string>("blocked aaa");
            Console.WriteLine(task.Result);
        }
    }
}