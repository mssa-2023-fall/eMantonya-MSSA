namespace Mod8_Lab1_BinaryTree
{
    public class BinaryTree
    {
        //min number
        //max number
        //root
        //GetNodesAtLevel(int level)
        //insert()
        public Node? root;
        public int maxNum;
        public int minNum;
        public int NodeCount;


        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(int init)
        {
            root = new Node(init);
        }

        public Node GetNode(Node n, int value)
        {
            //n starts as root node, if its null, the tree is empty
            if (n == null) { return null; }
            //if the value is found, return that node and break out of the recursive call
            if (n.value == value) { return n; }
            //if the current nodes value is greater than the target value, recursively call GetNode on the current nodes left child
            if (n.value > value)
            {
                return GetNode(n.leftChild, value);
            }
            //same as above but right child
            else
            {
                return GetNode(n.rightChild, value);
            }
        }

        public void Insert(int value)
        {
            Node n = new Node(value);
            if (root == null)
            {
                root = n;
                this.NodeCount++;
                root.treeLevel = 0;
                return;
            }
            //create node pointer to keep track of current node and parent node
            Node current = root;
            Node parent = root;
            int levelCounter = 1;

            while (true)
            { //loop through tree structure, starting at root
                //if new node "n" is less than current node, traverse down until current Node left child is null then add there
                if (value < current.value)
                {
                    //if left child is null, add new node here
                     if (current.leftChild == null)
                    {
                        n.treeLevel = levelCounter;
                        n.parent = current;
                        this.NodeCount++;
                        current.leftChild = n;
                        return;
                    }
                     else
                    {
                        //current node's left child is already assigned, move current node pointer to the left child and add to the level counter
                        current = current.leftChild;
                        levelCounter++;
                    }
                }

                //same process as above, expect the value is higher than root so its added to the right
                if (value >= current.value)
                {
                    if (current.rightChild == null)
                    {
                        n.treeLevel = levelCounter;
                        n.parent = current;
                        this.NodeCount++;
                        current.rightChild = n;
                        return;
                    }
                    else
                    {
                        current = current.rightChild;
                        levelCounter++;
                    }
                }
            } 
            
        }
    }
}

