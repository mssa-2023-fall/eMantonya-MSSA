
using Mod5_Lab1_Stack;

namespace StackTests
{
    [TestClass]
    public class UnitTest1
    {        
        Stack<Person> people = new Stack<Person>(5);

        [TestMethod]
        public void TestPush()
        {
            people.Push(new Person("Bob", 28));
            Assert.IsFalse(people.Peek() == null);
            Assert.AreEqual(1, people.Count());           
        }
        [TestMethod]
        public void TestPeek()
        {
            people.Push(new Person("Bob", 28));
            
            Assert.IsNotNull(people.Peek());
            Assert.IsTrue(people.Peek() is Person);
        }
        [TestMethod]
        public void TestPop()
        {
            people.Push(new Person("Bob", 28));
            var result = people.Pop();
            Assert.IsNotNull(result);
        }
    }
}
