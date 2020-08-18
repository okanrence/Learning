using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Graph
{
    public class Node
    {
        public Node(string label)
        {
            this.Label = label;
        }
        public string Label { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }

    public class Graph
    {
        private IDictionary<string, Node> nodes = new Dictionary<string, Node>();
        private IDictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();
        public void AddNode(string label)
        {
            var node = new Node(label);
            nodes.TryAdd(label, node);
            adjacencyList.Add(node, new List<Node>());
        }
        public void AddEdge(string from, string to)
        {

            nodes.TryGetValue(from, out var fromNode);
            if (fromNode == null) { throw new Exception("Invalid from Node"); }

            nodes.TryGetValue(to, out var toNode);
            if (toNode == null) { throw new Exception("Invalid To Node"); }

            adjacencyList[fromNode].Add(toNode);
        }

        public void RemoveNode(string label)
        {
            nodes.TryGetValue(label, out var node);
            if (node == null) return;

            foreach (var key in adjacencyList.Keys)
                adjacencyList[key].Remove(node);

            adjacencyList.Remove(node);
            nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            nodes.TryGetValue(from, out var fromNode);
            nodes.TryGetValue(to, out var toNode);

            if (toNode == null || fromNode == null) return;

            adjacencyList[fromNode].Remove(toNode);

        }


        public void BFTraversal(string root)
        {
            var queue = new Queue<Node>();
            var visited = new HashSet<Node>();
            var nodeExists = nodes.TryGetValue(root, out var node);
            if (!nodeExists) return;

            queue.Enqueue(node);

            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                if (visited.Contains(currentNode))
                    continue;

                Console.WriteLine(currentNode);
                visited.Add(currentNode);

                foreach (var nextNode in adjacencyList[currentNode])
                {
                    if (!visited.Contains(nextNode))
                        queue.Enqueue(nextNode);
                }
            }

        }


        public void DFTraversal(string root)
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();
            var nodeExists = nodes.TryGetValue(root, out var node);
            if (!nodeExists) return;

            stack.Push(node);

            while (stack.Any())
            {
                var currentNode = stack.Pop();

                if (visited.Contains(currentNode))
                    continue;

                Console.WriteLine(currentNode);
                visited.Add(currentNode);

                foreach (var nextNode in adjacencyList[currentNode])
                {
                    if (!visited.Contains(nextNode))
                        stack.Push(nextNode);
                }
            }

        }
        public static void BubbleSort()
        {
            int[] arr = { 4, 8, 1, 6, 7, 2 };
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }


        public void DFTraversalRec(string root)
        {
            var nodeExists = nodes.TryGetValue(root, out var node);
            if (nodeExists)
                DFTraversalRec(node, new HashSet<Node>());
        }

        private void DFTraversalRec(Node root, ICollection<Node> visited)
        {
            Console.WriteLine(root);
            visited.Add(root);

            foreach (var node in adjacencyList[root])
            {
                if (!visited.Contains(node))
                    DFTraversalRec(node, visited);
            }
        }

        public static int isAnagram(string str)
        {
            var dict = new Dictionary<char, int>();
            foreach (var ch in str)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch]++;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }

            var duplicatesExists = dict.Values.Any(x => x > 1);
            if (!duplicatesExists) return 0;

            return 1; //incomplete code
        }

        public List<string> TopologicalSort()
        {
            var sorted = new List<string>();
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();
            foreach (var node in nodes.Values)
                TopologicalSort(node, visited, stack);

            while (stack.Any())
            {
                sorted.Add(stack.Pop().Label);
            }

            return sorted;
        }
        private void TopologicalSort(Node root, ICollection<Node> visited, Stack<Node> stack)
        {
            //Console.WriteLine(root);
            if (visited.Contains(root)) return;
            visited.Add(root);

            foreach (var node in adjacencyList[root])
                TopologicalSort(node, visited, stack);

            stack.Push(root);
        }

        public void Print()
        {
            foreach (var source in adjacencyList.Keys)
            {
                var targets = adjacencyList[source];
                if (targets.Count > 0)
                {
                    Console.WriteLine($"{source.ToString()} is connected to {targets.Select(x => x.ToString())}");
                }

            }
        }
    }
}
