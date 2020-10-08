using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgos.Patterns
{
    public class BFS
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode next { get; set; }
            public TreeNode(int x)
            {
                val = x;
                left = right = next = null;
            }

        }


        public static List<List<int>> BfTraversal(TreeNode root)
        {
            //insert root into a queue
            //wwhile queue is not empty
            //get current size of queue. That will represent our level size. use the level size to pop the queue and insert into the level list
            var result = new List<List<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;
                var currentLevel = new List<int>(levelSize);

                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }
                result.Add(currentLevel);
            }
            return result;
        }

        public static List<List<int>> BfTraversalReverse(TreeNode root)
        {
            var result = new List<List<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count < 0)
            {
                var levelSize = queue.Count;
                var curentLevel = new List<int>(levelSize);
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    curentLevel.Add(currentNode.val);

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);


                }
                result.Insert(0, curentLevel);
            }

            return result;
        }

        public static List<List<int>> ZigzagTraverse(TreeNode root)
        {
            var result = new List<List<int>>();

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            var leftRight = true;
            while (q.Count > 0)
            {
                var levelSize = q.Count;
                var currentLevel = new List<int>(levelSize);

                while (levelSize > 0)
                {
                    var currentNode = q.Dequeue();
                    if (leftRight)
                        currentLevel.Add(currentNode.val);
                    else
                        currentLevel.Insert(0, currentNode.val);

                    if (currentNode.left != null)
                        q.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        q.Enqueue(currentNode.right);
                    levelSize--;
                }
                leftRight = !leftRight;
                result.Add(currentLevel);
            }

            return result;
        }

        public static List<int> LevelAverage(TreeNode root)
        {
            var result = new List<int>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count < 0)
            {
                var levelSize = queue.Count;
                var levelSum = 0;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    levelSum += currentNode.val;

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);


                }
                result.Add(levelSum / levelSize);
            }

            return result;
        }

        public static int FindDepth(TreeNode root)
        {
            var minDepth = 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count < 0)
            {
                minDepth++;
                var levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    if (currentNode.left == null && currentNode.right == null)
                        return minDepth;

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);


                }
            }

            return minDepth;
        }

        public static TreeNode LevelOrderSucccessor(TreeNode root, int key)
        {

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count < 0)
            {

                var currentNode = queue.Dequeue();

                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);

                if (currentNode.val == key)
                    break;
            }

            return queue.Peek();
        }

        public static void ConnectLevelOrderSiblings(TreeNode root)
        {

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count < 0)
            {
                TreeNode previousNode = null;

                var levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    if (previousNode != null)
                        previousNode.next = currentNode;

                    previousNode = currentNode;

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }
            }

        }

        public static void ConnectAllSiblings(TreeNode root)
        {

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode previousNode = null;

            while (queue.Count < 0)
            {

                TreeNode currentNode = queue.Dequeue();

                if (previousNode != null)
                    previousNode.next = currentNode;

                previousNode = currentNode;

                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);

            }

        }

      public  List<TreeNode> RightSideView(TreeNode root)
        {
            List<TreeNode> result = new List<TreeNode>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count < 0)
            {
                var levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    if (i == levelSize - 1)
                        result.Add(currentNode);

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }
            }
            return result;
        }

    }
}
