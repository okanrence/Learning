using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;

namespace DataStructuresAndAlgos
{
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode next { get; set; }

        public TreeNode(int x)
        {
            val = x;
            left = right = next = null;
        }


    }
    public class TreeExercises
    {

        public static void Insert()
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            List<List<int>> result = BfTraversal(root);
            System.Console.WriteLine("Level order traversal: " + result);
        }





        public static List<List<int>> BfTraversal(TreeNode root)
        {
            //insert root into a queue
            //wwhile queue is not empty
            //get current size of queue. That will represent our level size. use the level size to pop the queue and insert into the level list
            List<List<int>> result = new List<List<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>(levelSize);
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);

                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
                result.Add(currentLevel);
            }

            return result;
        }

        public static List<List<int>> ZigzagTraverse(TreeNode root)
        {
            //insert root into a queue
            //wwhile queue is not empty
            //get current size of queue. That will represent our level size. use the level size to pop the queue and insert into the level list
            List<List<int>> result = new List<List<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            bool leftRight = true;
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>(levelSize);
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    if (leftRight)
                        currentLevel.Add(currentNode.val);
                    else
                        currentLevel.Insert(0, currentNode.val);

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);

                }
                leftRight = !leftRight;
                result.Add(currentLevel);
            }

            return result;
        }



        public static List<List<int>> traverseReverse(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                List<int> currentLevel = new List<int>(levelSize);
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();
                    currentLevel.Add(currentNode.val);

                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
                result.Insert(0, currentLevel);
            }

            return result;
        }

        public static List<double> findLevelAverages(TreeNode root)
        {
            List<double> result = new List<double>();
            if (root == null)
                return result;

            var queue = new Queue<TreeNode>();


            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;
                double levelSum = 0;

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


        public static int findDepth(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            int minDepth = 0;

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                minDepth++;
                int levelSize = 0;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    if (currentNode.left == null && currentNode.right == null) return minDepth;

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);

                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);
                }


            }
            return minDepth;
        }

        public static int findMaxDepth(TreeNode root)
        {
            var maxDepth = 0;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                maxDepth++;
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    var currentNode = queue.Dequeue();

                    if (currentNode.left != null)
                        queue.Enqueue(currentNode.left);
                    if (currentNode.right != null)
                        queue.Enqueue(currentNode.right);


                }

            }

            return maxDepth;

        }

        public static TreeNode findSuccessor(TreeNode root, int key)
        {
            if (root == null || (root.left == null && root.right == null)) return null;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);

                if (currentNode.val == key) break;
            }

            return queue.Peek();
        }




        public static bool HasPath(TreeNode root, int sum)
        {
            if (root == null) return true;

            if (root.left == null && root.right == null && root.val == sum) return true;

            return HasPath(root.left, sum - root.val) || HasPath(root.right, sum - root.val);
        }

        //public static bool HasPathRecursive(TreeNode root, int sum)
        //{
        //    if (root == null) return true;

        //    while(root.left !=null && root.right != null)
        //    {
        //        if (root.val == sum) return true;


        //    }

        //    if (root.left == null && root.right == null && root.val == sum) return true;

        //    return hasPath(root.left, sum - root.val) || hasPath(root.right, sum - root.val);
        //}

        //public static bool AllPathsWithSum(TreeNode root, int sum)
        //{
        //    if (root == null) return true;

        //    if (root.left == null && root.right == null && root.val == sum) return true;

        //    return hasPath(root.left, sum - root.val) || hasPath(root.right, sum - root.val);
        //}

    }
}

