using System.Collections.Generic;
using akka_dot_net.Message;
using Akka.Actor;

namespace akka_dot_net.Actor
{
    public class NetflixActor : ReceiveActor
    {
        public Dictionary<string, int> PlayCounts { get; set; }

        public NetflixActor()
        {
            Receive<NetflixMessage>(message => HandleTheMessage(message));
        }

        public void HandleTheMessage(NetflixMessage message)
        {
            PlayCounts = new Dictionary<string, int>(message.PlayCounts);
        }
    }
}