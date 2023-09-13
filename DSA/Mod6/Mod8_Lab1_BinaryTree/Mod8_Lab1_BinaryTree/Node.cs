using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Mod8_Lab1_BinaryTree
{
    public class Node<T>
    {
        //value
        //parent node (reference variable)
        //level indicator
        //left child (reference variable)
        //right child (reference variable)
        public T value;
        public Node<T>? parent;
        public Node<T>? leftChild;
        public Node<T>? rightChild;
        public int treeLevel = 0;

        public Node(T init)
        {
            value = init;
            leftChild = null;
            rightChild = null;
            treeLevel = 0;
            parent = null;
            
        }
    }
}
