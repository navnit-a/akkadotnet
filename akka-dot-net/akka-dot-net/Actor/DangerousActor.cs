using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Pattern;

namespace akka_dot_net.Actor
{
    public class DangerousActor : ReceiveActor
    {
        public DangerousActor()
        {
            var breaker = new CircuitBreaker(
                    maxFailures: 1,
                    callTimeout: TimeSpan.FromSeconds(2),
                    resetTimeout: TimeSpan.FromSeconds(3))
                .OnOpen(NotifyMeOnOpen);

            var dangerousCall = "This really isn't that dangerous of a call after all";

            Receive<string>(message => message.Contains("blocked"), message =>
            {
                Sender.Tell(breaker.WithSyncCircuitBreaker(() => dangerousCall));
            });

            Receive<string>(msg =>
            {
                breaker.WithCircuitBreaker(() => Task.FromResult(dangerousCall)).PipeTo(Sender);
            });
            //Receive<string>(s => HandleMessage(s));
        }

        private void HandleMessage(string s)
        {
            Sender.Tell("Received");
        }

        private void NotifyMeOnOpen()
        {
            Console.WriteLine("My CircuitBreaker is now open, and will not close for one minute");
        }
    }
}
