using NUnit.Framework;
using System;
using Counter;

namespace Tests
{
    [TestFixture()]
    public class CounterTest
    {
        [Test()]
        public void testStartsZero()
        {
            Counter.Counter counterTest = new Counter.Counter("Zero?");
            Assert.AreEqual(counterTest.Count, 0);
        }

        [Test()]
        public void testIncrement()
        {
            Counter.Counter counterTest = new Counter.Counter("Zero?");
            counterTest.Increment();
            Assert.AreEqual(counterTest.Count, 1);
        }

        [Test()]
        public void testIncrementMultiple()
        {
            Counter.Counter counterTest = new Counter.Counter("Zero?");
            counterTest.Increment();
            counterTest.Increment();
            counterTest.Increment();
            counterTest.Increment();
            Assert.AreEqual(counterTest.Count, 4);
        }

        [Test()]
        public void testReset()
        {
            Counter.Counter counterTest = new Counter.Counter("Zero?");
            counterTest.Increment();
            counterTest.Increment();
            counterTest.Increment();
            counterTest.Reset();
            Assert.AreEqual(counterTest.Count, 0);
        }

    }
}
