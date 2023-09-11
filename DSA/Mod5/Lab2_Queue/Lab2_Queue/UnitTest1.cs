using Queue;

namespace Lab2_Queue
{
    [TestClass]
    public class UnitTest1
    {
        Queue<Caller> calls = new Queue<Caller>(6);
        [TestMethod]
        public void TestEnqueue()
        {
            calls.Enqueue(new Caller("Jim"));
            calls.Enqueue(new Caller("Bob"));
            calls.Enqueue(new Caller("Lisa"));

            Assert.AreEqual(3, calls.Count);
            Assert.AreEqual(6, calls.EnsureCapacity(0));
            Assert.AreEqual("Jim", calls.Peek().CallerID);
        }

        [TestMethod]
        public void TestDequeue()
        {
            calls.Enqueue(new Caller("Jim"));
            calls.Enqueue(new Caller("Bob"));
            calls.Enqueue(new Caller("Lisa"));

            Assert.AreEqual("Jim", calls.Dequeue().CallerID);
            Assert.AreEqual("Bob", calls.Dequeue().CallerID);
            Assert.AreEqual("Lisa", calls.Dequeue().CallerID);
        }

        [TestMethod]
        public void TestQueueIteration()
        {
            calls.Enqueue(new Caller("Jim"));
            calls.Enqueue(new Caller("Bob"));
            calls.Enqueue(new Caller("Lisa"));
            string[] names = { "Jim", "Bob", "Lisa" };
            int counter = 0;
            foreach (Caller caller in calls)
            {
                Assert.AreEqual(names[counter], caller.CallerID);
                counter++;
            }
        }
    }
}
