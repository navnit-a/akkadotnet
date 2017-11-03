using System.Collections.Generic;
using System.Collections.ObjectModel;
using akka_dot_net.Actor;
using akka_dot_net.Message;
using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit2;
using Xunit;

namespace UnitTestProject
{
    public class NetflixActorTests : TestKit
    {
        // Direct Test
        [Fact]
        public void ShouldHaveInitialValue()
        {
            // Arrange
            var actor = new NetflixActor();

            // Assert
            Assert.Null(actor.PlayCounts);
        }

        // Direct Test
        [Fact]
        public void ShouldSetInitialPlayCount()
        {
            // Act 
            var actor = new NetflixActor();
            var initialStats = new Dictionary<string, int> {{"Iron Man", 10}};

            // Arrange
            actor.HandleTheMessage(new NetflixMessage(new ReadOnlyDictionary<string, int>(initialStats)));

            Assert.Equal(10, actor.PlayCounts["Iron Man"]);
        }

        // Unit Test
        [Fact]
        public void ShouldReceiveStatisticMessage()
        {
            // Act
            //IActorRef actorRef = Sys.ActorOf<NetflixActor>();
            TestActorRef<NetflixActor> actorRef = ActorOfAsTestActorRef<NetflixActor>();

            // Arrange
            var initialStats = new Dictionary<string, int> { { "Iron Man", 10 } };
            actorRef.Tell(new NetflixMessage(new ReadOnlyDictionary<string, int>(initialStats)));

            // Assert
            //Assert.Equal(10, actorRef.PlayCounts["Iron Man"]);
            Assert.Equal(10, actorRef.UnderlyingActor.PlayCounts["Iron Man"]);
        }
    }
}