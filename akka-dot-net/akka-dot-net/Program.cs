﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using akka_dot_net.Actor;
using Akka.Actor;

namespace akka_dot_net
{
    public class Program
    {
        private static ActorSystem _movieStreamingActorSystem;

        static void Main(string[] args)
        {
            _movieStreamingActorSystem = ActorSystem.Create("MovieStreamingSystem");
            Console.WriteLine("Actor System Created!!");

            Props playbackActorProps = Props.Create<PlaybackActor>();

            IActorRef playbackActorRef = _movieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");

            // Send some messages
            playbackActorRef.Tell("New World Order");
            playbackActorRef.Tell(123);

            Console.ReadLine();

            _movieStreamingActorSystem.Terminate();
        }
    }
}