using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgos.Patterns
{
    public class TopologicalSort
    {
        public static List<int> Sort(int vertices, int[][] edges)
        {
            var sortedOrder = new List<int>();

            if (vertices <= 0)
            {
                return sortedOrder;
            }

            var depth = new Dictionary<int, int>();

            var graph = new Dictionary<int, List<int>>();

            //intialize graph
            for (int i = 0; i < vertices; i++)
            {
                depth.Add(i, 0);
                graph.Add(i, new List<int>());
            }

            //build graph
            for (int i = 0; i < edges.Length; i++)
            {
                int parent = edges[i][0];
                int child = edges[i][1];

                graph[parent].Add(child);
                depth[child]++;
            }

            //get all sources
            var sources = new Queue<int>();
            foreach (var key in depth.Keys)
            {
                if (depth[key] == 0)
                {
                    sources.Enqueue(key);
                }
            }

            //traverse graph BFS
            while (sources.Count > 0)
            {
                var vertex = sources.Dequeue();
                sortedOrder.Add(vertex);
                var children = graph.GetValueOrDefault(vertex);

                foreach (var child in children)
                {
                    depth[child]--;
                    if (depth[child] == 0)
                    {
                        sources.Enqueue(child);
                    }
                }
            }

            if (vertices != sortedOrder.Count) return new List<int>();

            return sortedOrder;

        }

        public static String AlienDictionary(String[] words)
        { 
            if(words?.Length <= 0)
            {
                return "";
            }

            var sortedOrder = new StringBuilder();

            //intialize the graph

            var depth = new Dictionary<char, int>();
            var graph = new Dictionary<char, List<char>>();

            foreach(var word in words)
            {
                foreach(var ch in word)
                {
                    graph[ch] = new List<char>();
                    depth[ch]=  0;
                }
            }

            //build graph
            for(int i=0; i< words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];

                for(int j =0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    var parent = word1[j];
                    var child = word2[j];

                    if(parent != child)
                    {
                        graph[parent].Add(child);
                        depth[child]++;
                        break;
                    }
                }
            }



            var sources = new Queue<char>();
            //get all sources

            foreach (var key in depth.Keys)
            {
                if(depth[key] == 0)
                {
                    sources.Enqueue(key);
                }
            }


            while (sources.Count > 0)
            {
                var source = sources.Dequeue();
                sortedOrder.Append(source);

                var children = graph[source];

                foreach(var child in children)
                {
                    depth[child]--;
                    if(depth[child] == 0)
                    {
                        sources.Enqueue(child);
                    }
                }

            }

            if(depth.Count != sortedOrder.Length)
            {
                return "";
            }
            return sortedOrder.ToString();
        }


        public static string Multiply(string num1, string num2)
        {
            int m = num1.Length;
            int n = num2.Length;

            int[] ans = new int[m + n];

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    var iVal = num1[i] - '0';
                    var jVal = num2[j] - '0';
                    int multiply = (num1[i] - '0') * (num2[j] - '0');
                    int sum = multiply + ans[i + j + 1];
                    ans[i + j + 1] = sum % 10;
                    ans[i + j] += sum / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var p in ans)
            {
                if (!(p == 0 && sb.Length == 0))
                {
                    sb.Append(p);
                }
            }

            return (sb.Length == 0) ? "0" : sb.ToString();

        }
    }
}
