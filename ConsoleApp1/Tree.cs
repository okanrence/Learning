using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Tree
    {

        private Node root;

        private class Node
        {
            public int value;
            public Node leftChild;
            public Node rightChild;
            public Node(int value)
            {
                this.value = value;
            }

        }

        public int size()
        {
            return size(root);
        }
        private int size(Node root)
        {
            if (root == null) return 0;

            if (isLeaf(root)) return 1;

            return 1 + size(root.leftChild) + size(root.rightChild);
        }

        public int countLeaves()
        {
            return countLeaves(root);
        }
        private int countLeaves(Node root)
        {
            if (root == null) return 0;

            if (isLeaf(root)) return 2;



            return countLeaves(root.leftChild) + countLeaves(root.rightChild);
            //return res;
        }
        public bool find(int value)
        {
            var current = root;

            while (current != null)
            {
                if (value < current.value)
                {
                    current = current.leftChild;
                }
                else if (value > current.value)
                {
                    current = current.rightChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Traverse(TraverseOrder traverseOrder)
        {
            if (traverseOrder == TraverseOrder.PreOrder)
                TraversePreOrder(root);
            else if (traverseOrder == TraverseOrder.InOrder)
                TraverseInOrder(root);
            else if (traverseOrder == TraverseOrder.PostOrder)
                TraversePostOrder(root);
        }
        private bool isLeaf(Node root)
        {
            return root.leftChild == null && root.rightChild == null;
        }

        public int height()
        {
            return height(root);
        }
        private int height(Node root)
        {
            if (root == null) return -1;
            if (isLeaf(root)) return 0;

            return 1 + Math.Max(height(root.leftChild), height(root.rightChild));

        }
        public int min()
        {
            return min(root);
        }
        private int min(Node root)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            var current = root;
            var last = current;

            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }

            return last.value;
        }

        public void NodeAtKthDistance(int K)
        {
            NodeAtKthDistance(root, K);
        }

        private void NodeAtKthDistance(Node root, int K)
        {
            if (root == null) return;

            if (K == 0)
            {
                Console.WriteLine(root.value);
            }

            NodeAtKthDistance(root.leftChild, K - 1);
            NodeAtKthDistance(root.rightChild, K - 1);
        }
        public void swapRoot()
        {
            var temp = root.rightChild;
            root.leftChild = root.rightChild;
            root.rightChild = temp;
        }
        public bool isBSTree()
        {
            return isBSTree(root, int.MinValue, int.MaxValue);
        }

        private bool isBSTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.value < min || root.value > max)
                return false;

            return isBSTree(root.leftChild, min, root.value - 1) && isBSTree(root.rightChild, root.value + 1, max);
        }
        public bool Equals(Tree other)
        {
            return Equals(root, other.root);
        }

        private bool Equals(Node firstNode, Node secondNode)
        {
            if (firstNode == null && secondNode == null)
                return true;

            if (firstNode != null && secondNode != null)
                return firstNode.value == secondNode.value
                    && Equals(firstNode.leftChild, secondNode.leftChild)
                    && Equals(firstNode.rightChild, secondNode.rightChild);

            return false;
        }
        public int max()
        {
            return max(root);
        }

        private int max(Node root)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            var current = root;
            var last = current;

            while (current != null)
            {
                last = current;
                current = current.rightChild;
            }

            return last.value;
        }


        public enum TraverseOrder
        {
            PreOrder,
            InOrder,
            PostOrder,

        }
        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.value);
            TraversePreOrder(root.leftChild);
            TraversePreOrder(root.rightChild);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            TraverseInOrder(root.rightChild);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }
        public void Insert(int value)
        {
            var node = new Node(value);
            if (root == null)
            {
                root = node;
                return;
            }
            var current = root;
            while (true)
            {
                if (value < current.value)
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = node;
                        break;
                    }
                    current = current.leftChild;
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = node;
                        break;
                    }
                    current = current.rightChild;
                }
            }
        }
        public void InsertRecursive(int value)
        { 
        
        }


    }


}
