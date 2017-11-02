using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace akka_dot_net.Message
{
    public class NetflixMessage
    {
        public NetflixMessage(ReadOnlyDictionary<string, int> playCounts)
        {
            PlayCounts = playCounts;
        }

        public ReadOnlyDictionary<string, int> PlayCounts { get; }
    }
}