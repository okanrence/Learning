using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgos.Patterns
{
    public class DFS
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

        public static bool hasPath(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            if (root.val == sum && root.left == null && root.right == null) return true;

            return hasPath(root.left, sum - root.val) || hasPath(root.right, sum - root.val);
        }

        public static List<List<int>> findPaths(TreeNode root, int sum)
        {
            var allPaths = new List<List<int>>();
            var currentPath = new List<int>();
            findPaths(root, sum, allPaths, currentPath);
            return allPaths;
        }

        private static void findPaths(TreeNode currentNode, int sum, List<List<int>> allPaths, List<int> currentPath)
        {
            if (currentNode == null)
                return;

            if (currentNode.val == sum && currentNode.left == null && currentNode.right == null)
            {
                allPaths.Add(currentPath);
            }
            else
            {
                findPaths(currentNode.left, sum - currentNode.val, allPaths, currentPath);
                findPaths(currentNode.right, sum - currentNode.val, allPaths, currentPath);
            }

            currentPath.Remove(currentPath.Count - 1);
        }

        public static int findSumOfPathNumbers(TreeNode root)
        {
            return PathSumRecursive(0, root);
        }

        private static int PathSumRecursive(int sum, TreeNode currentNode)
        {
            if (currentNode == null) return 0;

            sum += 10 * sum + currentNode.val;

            return PathSumRecursive(sum, currentNode.left) +
               PathSumRecursive(sum, currentNode.right);


        }


        public static bool findPath(TreeNode root, int[] sequence)
        {
            if (root == null) return sequence.Length == 0;
            return findPath(root, sequence, 0);
        }

        private static bool findPath(TreeNode currentNode, int[] sequence, int currentSequence)
        {
            if (currentNode == null) return false;

            if (currentSequence >= sequence.Length || currentNode.val != sequence[currentSequence]) return false;

            if (currentNode.left == null && currentNode.right == null && currentSequence == sequence.Length - 1) return true;

          return  findPath(currentNode.left, sequence, currentSequence + 1) || findPath(currentNode.right, sequence, currentSequence +1);
        }
    }
}
