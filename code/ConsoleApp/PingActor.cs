using Akka.Actor;
using Akka.Cluster.Tools.PublishSubscribe;
using Akka.Event;
using FluentAssertions;
using System;

namespace ConsoleApp
{
    internal class PingActor : ReceiveActor
    {
        public PingActor()
        {
            Logger = Context.GetLogger();
            Context.System.EventStream.Subscribe(Self, typeof(string)).Should().BeTrue();
            Receive<string>(Handle);
            Logger.Info("Create PingActor");
        }

        public ILoggingAdapter Logger { get; private set; }

        private void Handle(string obj)
        {
            Logger.Info(obj);
        }
    }
}