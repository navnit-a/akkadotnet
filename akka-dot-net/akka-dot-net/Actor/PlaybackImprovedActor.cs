using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using akka_dot_net.Message;
using Akka.Actor;

namespace akka_dot_net.Actor
{
    public class PlaybackImprovedActor : ReceiveActor
    {
        public PlaybackImprovedActor()
        {
            Console.WriteLine("Creating an Improved Actor");

            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message));
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            Console.WriteLine("Improved Message : " + message.MovieTitle);
            Console.WriteLine("Improved Message : " + message.UserId);
        }
    }
}
