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
        public void ShouldHaveInitialState()
        {
            TestActorRef<UserActor> actor = ActorOfAsTestActorRef<UserActor>();

            Assert.Null(actor.UnderlyingActor.CurrentlyPlaying);
        }

        [Fact]
        public void ShouldUpdateCurrentlyPlayingState()
        {
            TestActorRef<UserActor> actor = ActorOfAsTestActorRef<UserActor>();

            actor.Tell(new PlayMovieMessage("The Matrix", 12));
            
            Assert.Equal("The Matrix", actor.UnderlyingActor.CurrentlyPlaying);
        }

        [Fact]
        public void ShouldPlayMovie()
        {
            // Act
            IActorRef actor = ActorOf<UserActor>();

            // Arrange
            actor.Tell(new PlayMovieMessage("Hulk", 123));

            // Assert
            var messageReceived = ExpectMsgFrom<NowPlayingMessage>(actor, message => message.CurrentlyPlaying == "Hulk");

            // Assert 2
            Assert.Equal("Hulk", messageReceived.CurrentlyPlaying);
        }
    }
}
