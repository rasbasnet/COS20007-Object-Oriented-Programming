using NUnit.Framework;
using System;
using Swin_Adventure;

namespace Tests
{
    [TestFixture()]
    public class IdentifiableObjectTest
    {
        [Test()]
        public void TestAreYou()
        {
            //tests if Are You works - correct answer
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fred"));
        }

        [Test()]
        public void TestNotAreYou()
        {
            //tests if Are You works - wrong answer
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsFalse(id.AreYou("wilma"));
        }

        [Test()]
        public void TestAreYouCaseSentitive()
        {
            //tests if Are You works with case sentivity- correct answer
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fReD"));
        }

        [Test()]
        public void TestFirstID()
        {
            //tests if FirstId works - correct answer (return first element)
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(id.FirstId(), "fred");
        }

        [Test()]
        public void TestAddID()
        {
            //tests if AddId works - correct answer (add an element)
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            id.AddIdentifier("wilma");
            Assert.IsTrue(id.AreYou("wilma"));
        }

    }
}
