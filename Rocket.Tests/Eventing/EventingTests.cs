﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rocket.API;
using Rocket.API.Eventing;
using Rocket.Core.Eventing;

namespace Rocket.Tests.Eventing
{
    [TestClass]
    [TestCategory("Eventing")]
    public class EventingTests : RocketTestBase
    {
        [TestMethod]
        public void TestSyncEventingWithType()
        {
            var manager = GetEventManager();
            manager.Subscribe<TestEvent>(GetListener(), (@sender, @event) => @event.ValueChanged = true);

            var e = new TestEvent(EventExecutionTargetContext.Sync);
            EmitTestEvent(manager, e);

            Assert.AreEqual(true, e.ValueChanged, "The subscription callback did not get called");
        }

        [TestMethod]
        public void TestSyncEventingWithName()
        {
            var manager = GetEventManager();
            manager.Subscribe(GetListener(), "test", (@sender, @event) => ((TestEvent)@event).ValueChanged = true);

            var e = new TestEvent(EventExecutionTargetContext.Sync);
            EmitTestEvent(manager, e);

            Assert.AreEqual(true, e.ValueChanged, "The subscription callback did not get called");
        }

        [TestMethod]
        public void TestCancellationWithoutIgnore()
        {
            var manager = GetEventManager();
            manager.Subscribe<TestEvent>(GetListener(), (@sender, @event) => @event.ValueChanged = true);

            var e = new TestEvent(EventExecutionTargetContext.Sync) { IsCancelled = true };
            EmitTestEvent(manager, e);

            Assert.AreEqual(false, e.ValueChanged, "The subscription callback was called on a cancelled event when it shouldn't be");
        }

        [TestMethod]
        public void TestCancellationWithIgnore()
        {
            var manager = GetEventManager();
            manager.Subscribe<TestEvent>(GetListener(), CancelIgnoreEventHandler);

            var e = new TestEvent(EventExecutionTargetContext.Sync) { IsCancelled = true };
            EmitTestEvent(manager, e);

            Assert.AreEqual(true, e.ValueChanged, "The subscription callback was not called on a cancelled event but it has IgnoreCancelled set to true");
        }

        [EventHandler(IgnoreCancelled = true)]
        private void CancelIgnoreEventHandler(IEventEmitter sender, IEvent @event)
        {
            ((TestEvent)@event).ValueChanged = true;
        }

        private void EmitTestEvent(IEventManager manager, TestEvent @event)
        {
            manager.Emit(GetEmitter(), @event);

            while (!manager.HasFinished(@event))
                ;
        }

        public IEventEmitter GetEmitter()
        {
            return Runtime.Container.Get<IImplementation>();
        }
        public ILifecycleObject GetListener()
        {
            return Runtime.Container.Get<IRuntime>();
        }

        protected virtual IEventManager GetEventManager()
        {
            return Runtime.Container.Get<IEventManager>();
        }
    }
}