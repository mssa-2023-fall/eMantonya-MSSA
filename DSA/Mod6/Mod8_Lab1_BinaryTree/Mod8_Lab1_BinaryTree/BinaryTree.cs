using System.Reflection.Metadata.Ecma335;

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

        public static BinaryTree<T> BuildTree(T[] arr)
        {
            //add the midpoint value of the array to the root using the constructor
            //root must be midpoint value or tree will be unbalanced
            var result = new BinaryTree<T>(arr[arr.Length / 2]);
            for (int i = 0; i < arr.Length; i++)
            {
                result.Insert(arr[i]);
            }
            return result;
        }

        public Node<T> GetNode(Node<T> n, T value)
        {
            //n starts as root node, if its null, the tree is empty
            if (n == null) { return null; }
            //if the value is found, return that node and break out of the recursive call
            //if (n.value == value) { return n; } //change this to be able to compare generics
            if (n.value.Equals(value)) { return n; }
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
            //create a new node with the argument value
            Node<T> n = new Node<T>(value);
            //if root is null, tree is empty, add the value to the root.
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
                        //current node's left child is already assigned, move current node pointer to the left child and add to the level counter then try again
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
            //define the breakoutcase for the recursion method
            //the max number will be the rightmost point of the tree
            //if there is no longer a right child for the current node, the end of the tree is reached.
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

