using Akka.Actor;

namespace ConsoleApp
{
    internal class PongActor : ReceiveActor
    {
        public PongActor() 
        {
            Context.System.EventStream.Publish("topic");
        }

        protected override void PreStart()
        {
            
            base.PreStart();
        }
    }
}