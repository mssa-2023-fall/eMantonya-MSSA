using Mod8_Lab1_BinaryTree;

namespace TreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefaultTreeConstructorShouldReturnNullRoot()
        {
            BinaryTree tree = new BinaryTree();

            Assert.IsNull(tree.root);
        }
        [TestMethod]
        public void InsertNodeInEmptyTreeFillsRootProperty()
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(3);

            Assert.AreEqual(3, tree.root.value);
        }
        [TestMethod]
        public void CallingTreeConstructorWithValueParamSetsRootNode()
        {
            BinaryTree tree = new BinaryTree(3);

            Assert.AreEqual(3, tree.root.value);
        }
        [TestMethod]
        public void RootsLeftChildisAssignedCorrectly()
        {
            BinaryTree tree = new BinaryTree(5);
            tree.Insert(3);

            Assert.AreEqual(3, tree.root.leftChild.value);
            Assert.AreEqual(1, tree.root.leftChild.treeLevel);
        }
        [TestMethod]
        public void MultipleInsertsWorkCorrectly()
        {
            BinaryTree tree = new BinaryTree();
            for (int i = 0; i < 100; i += 3)
            {
                tree.Insert(i);
            }
            Assert.AreEqual(34, tree.NodeCount);
        }


        [TestMethod]
        public void GetNodeWorks()
        {
            BinaryTree tree = new BinaryTree(8);
            for (int i = 0; i < 50; i += 3)
            {
                tree.Insert(i);
            }

            var result = tree.GetNode(tree.root, 45);

            Assert.AreEqual(result.value, 45);
        }

        [TestMethod]
        public void GetMaxWorks()
        {
            BinaryTree tree = new BinaryTree(8);
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
            BinaryTree tree = new BinaryTree(3);
            for (int i = 10; i < 60; i += 3)
            {
                tree.Insert(i);
            }
            int result = tree.GetMin(tree.root);
            Assert.AreEqual(3, result);
        }

    }
}
