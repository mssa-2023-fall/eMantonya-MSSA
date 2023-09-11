

using System;

namespace StackTest
{
    [TestClass]
    public class UnitTest1
    {
        Stack<string> people = new Stack<string>(5);

        [TestMethod]
        public void TestPush()
        {
            people.Push("Bob");
            Assert.IsFalse(people.Peek() == null);
            Assert.AreEqual(1, people.Count());
        }
        [TestMethod]
        public void TestPeek()
        {
            people.Push("Bob");

            Assert.IsNotNull(people.Peek());
            Assert.AreEqual("Bob", people.Peek());
        }
        [TestMethod]
        public void TestPop()
        {
            people.Push("Bob");
            var result = people.Pop();
            Assert.IsNotNull(result);
        }
    }
}
