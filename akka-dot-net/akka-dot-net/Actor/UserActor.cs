using akka_dot_net.Message;
using Akka.Actor;

namespace akka_dot_net.Actor
{
    public class UserActor : ReceiveActor
    {
        public UserActor()
        {
            Receive<PlayMovieMessage>(message =>
                {
                    CurrentlyPlaying = message.MovieTitle;
                    Sender.Tell(new NowPlayingMessage(CurrentlyPlaying));
                });
        }

        public string CurrentlyPlaying { get; private set; }
    }
}