using Akka.Actor;
using Akka.Cluster.Tools.PublishSubscribe;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var system = ActorSystem.Create("world");

            var pingActor = system.ActorOf(Props.Create(() => new PingActor()), "pingActor");
            var pongActor = system.ActorOf(Props.Create(() => new PongActor()));


            while (true)
            {
                Console.ReadLine();
                var rootActor = await system.ActorSelection("/").ResolveOne(1000.Milliseconds());

                PrintChildrenPath(rootActor as ActorRefWithCell);
            }

            
        }

        private static void PrintChildrenPath(ActorRefWithCell actor)
        {
            foreach (var item in actor.Children)
            {
                
                Console.WriteLine(item.Path);
                PrintChildrenPath(item as ActorRefWithCell);
            }
        }
    }
}
