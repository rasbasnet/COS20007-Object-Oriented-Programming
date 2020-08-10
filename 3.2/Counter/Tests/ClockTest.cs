using NUnit.Framework;
using System;
using Counter;

namespace Tests
{
    [TestFixture()]
    public class ClockTest
    {

        [Test()]
        public void testClockStartsZero()
        {
            Clock counterTest = new Clock();
            Assert.AreEqual(counterTest.ReadTime, "0:0:0");
        }

        //testing whether calling Tick() increments the Seconds
        [Test()]
        public void testClockTicks()
        {
            Clock counterTest = new Clock();
            for (int i = 0;i < 12;i++)
            {
                counterTest.Tick();
            }
            Assert.AreEqual(counterTest.ReadTime, "0:0:12");
        }

        //testing that after ticking 60 times it increments minutes by 1 and resets seconds
        [Test()]
        public void testClockMinutes()
        {
            Clock counterTest = new Clock();
            for (int i = 0; i < 60; i++)
            {
                counterTest.Tick();
            }
            Assert.AreEqual(counterTest.ReadTime, "0:1:0");
        }

        //testing that after ticking 60*60 times it increments hour by 1 and resets minutes and seconds
        [Test()]
        public void testClockHours()
        {
            Clock counterTest = new Clock();
            for (int i = 0; i < 60*60; i++)
            {
                counterTest.Tick();
            }

            Assert.AreEqual(counterTest.ReadTime, "1:0:0");
        }

        //testing that after ticking for 24 hours it will reset
        [Test()]
        public void test24Hours()
        {
            Clock counterTest = new Clock();
            //                   60 * 60 * 24 == 24 hours + 1 second
            for (int i = 0; i < 60 * 60 * 24 + 1; i++)
            {
                counterTest.Tick();
            }

            Assert.AreEqual(counterTest.ReadTime, "0:0:1");
        }

        //testing reset
        [Test()]
        public void testReset()
        {
            Clock counterTest = new Clock();
            for (int i = 0; i < 50; i++)
            {
                counterTest.Tick();
            }
            counterTest.Reset();

            Assert.AreEqual(counterTest.ReadTime, "0:0:0");
        }

    }
}
