namespace Mod8_Lab1_BinaryTree
{
    public class BinaryTree<T>
    {
        //min number
        //max number
        //root
        //GetNodesAtLevel(int level)
        //insert()
        public Node<T>? root;
        public int maxVal;
        public int minVal;
        public int NodeCount;

        
        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T init)
        {
            root = new Node<T>(init);
        }

        public Node<T> GetNode(Node<T> n, T value)
        {
            //n starts as root node, if its null, the tree is empty
            if (n == null) { return null; }
            //if the value is found, return that node and break out of the recursive call
            //if (n.value == value) { return n; } //change this to be able to compare generics
            if(n.value.Equals(value)) { return n; }
            //if the current nodes value is greater than the target value, recursively call GetNode on the current nodes left child
            //if (n.value > value) //change this to be able to compare generics
            if (Comparer<T>.Default.Compare(n.value, value) > 0)
            {
                return GetNode(n.leftChild, value);
            }
            //same as above but right child
            else
            {
                return GetNode(n.rightChild, value);
            }
        }

        public void Insert(T value)
        {
            Node<T> n = new Node<T>(value);
            if (root == null)
            {
                root = n;
                this.NodeCount++;
                root.treeLevel = 0;
                return;
            }
            //create node pointer to keep track of current node
            Node<T> current = root;
            int levelCounter = 1;

            while (true)
            { //loop through tree structure, starting at root
                //if new node "n" is less than current node, traverse down until current Node left child is null then add there
                //if (value < current.value) //change this to be able to compare generics
                if (Comparer<T>.Default.Compare(value, current.value) < 0)
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
                //if (value >= current.value) //change this to be able to compare generics
                if (Comparer<T>.Default.Compare(value, current.value) > 0 || Comparer<T>.Default.Compare(value, current.value) == 0)
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

        public T GetMax(Node<T> n)
        {
            if(n.rightChild == null)
            {
                return n.value;
            }
            return GetMax(n.rightChild);
        }

        public T GetMin(Node<T> n)
        {
            if(n.leftChild == null)
            {
                return n.value;
            }
            return GetMin(n.leftChild);
        }          
        

    }
}

