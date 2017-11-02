namespace akka_dot_net.Message
{
    public class NowPlayingMessage
    {
        public NowPlayingMessage(string currentlyPlaying)
        {
            CurrentlyPlaying = currentlyPlaying;
        }

        public string CurrentlyPlaying { get; }
    }
}