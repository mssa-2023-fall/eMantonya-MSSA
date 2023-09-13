using Mod8_Lab1_BinaryTree;

namespace TreeTest
{
    [TestClass]
    public class UnitTest1 
    {
        //===================Testing Integers==================//
        [TestMethod]
        public void DefaultTreeConstructorShouldReturnNullRoot()
        {
            var tree = new BinaryTree<int>();

            Assert.IsNull(tree.root);
        }

        [TestMethod]
        public void InsertNodeInEmptyTreeFillsRootProperty()
        {
            var tree = new BinaryTree<int>();
            
            tree.Insert(3);

            Assert.AreEqual(3, tree.root.value);
        }

        [TestMethod]
        public void CallingTreeConstructorWithValueParamSetsRootNode()
        {
            var tree = new BinaryTree<int>(3);

            Assert.AreEqual(3, tree.root.value);
        }

        [TestMethod]
        public void RootsChilderenAreAssignedCorrectly()
        {
            var tree = new BinaryTree<int>(5);
            tree.Insert(3);
            tree.Insert(7);

            Assert.AreEqual(3, tree.root.leftChild.value);
            Assert.AreEqual(1, tree.root.leftChild.treeLevel);
            Assert.AreEqual(7, tree.root.rightChild.value);
            Assert.AreEqual(1, tree.root.rightChild.treeLevel);
        }

        [TestMethod]
        public void MultipleInsertsWorkCorrectly()
        {
            var tree = new BinaryTree<int>();
            for (int i = 0; i < 100; i += 3)
            {
                tree.Insert(i);
            }
            Assert.AreEqual(34, tree.NodeCount);
        }

        [TestMethod]
        public void GetNodeWorks()
        {
            var tree = new BinaryTree<int>(8);
            for (int i = 0; i < 50; i += 3)
            {
                tree.Insert(i);
            }

            var result = tree.GetNode(tree.root, 45);

            Assert.AreEqual(result.value, 45);
        }

        [TestMethod]
        public void GetNodeReturnsNullIfNotFound()
        {
            var tree = new BinaryTree<int>();
            for (int i = 0; i < 50; i += 3)
            {
                tree.Insert(i);
            }

            var result = tree.GetNode(tree.root, 22);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetMaxWorks()
        {
            var tree = new BinaryTree<int>(8);
            for (int i = 0; i < 50; i += 3)
            {
                tree.Insert(i);
            }
            int result = tree.GetMax(tree.root);
            Assert.AreEqual(48, result);
        }

        [TestMethod]
        public void GetMinWorks()
        {
            var tree = new BinaryTree<int>(3);
            for (int i = 10; i < 60; i += 3)
            {
                tree.Insert(i);
            }
            int result = tree.GetMin(tree.root);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NodeParentValueIsAssignedCorrectly()
        {
            var tree = new BinaryTree<int>(8);
            tree.Insert(7);
            var n = tree.GetNode(tree.root, 7);

            Assert.AreEqual(tree.root.value, n.parent.value);
        }


        //=================Testing Strings=================// 
        [TestMethod]
        public void StringsAreInsertedCorrectly()
        {
            var tree = new BinaryTree<string>("banana");
            tree.Insert("apple");
            tree.Insert("carrot");

            Assert.AreEqual(tree.root.value, "banana");
            Assert.AreEqual(tree.root.leftChild.value, "apple");
            Assert.AreEqual(tree.root.rightChild.value, "carrot");
        }
        [TestMethod]
        public void GetNodeWorksWithStrings()
        {
            var tree = new BinaryTree<string>("f");
            tree.Insert("a");
            tree.Insert("b");
            tree.Insert("c");
            tree.Insert("d");
            tree.Insert("e");
            tree.Insert("g");
            tree.Insert("h");
            tree.Insert("i");
            tree.Insert("j");
            tree.Insert("k");


            var result = tree.GetNode(tree.root, "j");
            Assert.IsNotNull(result);
            Assert.AreEqual(result.value, "j");
        }
        [TestMethod]
        public void GetMaxAndMinWorksWithStrings()
        {
            var tree = new BinaryTree<string>("f");
            tree.Insert("a");
            tree.Insert("b");
            tree.Insert("c");
            tree.Insert("d");
            tree.Insert("e");
            tree.Insert("g");
            tree.Insert("h");
            tree.Insert("i");
            tree.Insert("j");
            tree.Insert("k");

            var max = tree.GetMax(tree.root);
            var min = tree.GetMin(tree.root);

            Assert.IsNotNull(max);
            Assert.IsNotNull(min);
            Assert.AreEqual(max, "k");
            Assert.AreEqual(min, "a");
        }
    }
}
