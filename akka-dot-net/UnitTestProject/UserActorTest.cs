using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using akka_dot_net.Actor;
using akka_dot_net.Message;
using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit2;
using Xunit;

namespace UnitTestProject
{
    public class UserActorTest : TestKit
    {
        [Fact]
        public void ShouldUpdateCurrentlyPlayingState()
        {
            IActorRef actor = Sys.ActorOf<UserActor>();
            //TestActorRef<UserActor> actor = ActorOfAsTestActorRef<UserActor>();

            actor.Tell(new PlayMovieMessage("The Matrix", 12));
            
            //Assert.Equal("The Matrix", actor.UnderlyingActor.CurrentlyPlaying);
            //Assert.Equal("The Matrix", actor.CurrentlyPlaying);
        }

        [Fact]
        public void ShouldPlayMovie()
        {
            // Act
            IActorRef actor = Sys.ActorOf<UserActor>(); 
            // We not trying to access properties of UserActor, rather asserting it's return value

            // Arrange
            actor.Tell(new PlayMovieMessage("Hulk", 123));

            // Assert 1
            //ExpectMsgFrom<NowPlayingMessage>(actor);

            // Assert 2
            NowPlayingMessage messageReceived = ExpectMsgFrom<NowPlayingMessage>(actor, message => message.CurrentlyPlaying == "Hulk", TimeSpan.FromSeconds(5));

            // Assert 3
            Assert.Equal("Hulk", messageReceived.CurrentlyPlaying);
        }
    }
}
