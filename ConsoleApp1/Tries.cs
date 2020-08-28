using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Tries
{
    public class Node
    {

        public char Value { get; set; }
        public IDictionary<char, Node> Children { get; set; }
        public bool IsEnd { get; set; }
        public Node(char value)
        {
            this.Value = value;
            Children = new Dictionary<char, Node>();
        }

        public bool HasChild(char ch)
        {
            return Children.ContainsKey(ch);
        }

        public void AddChild(char ch)
        {
            Children.Add(ch, new Node(ch));
        }

        public void Remove(char ch)
        {
            Children.Remove(ch);
        }

        public Node GetChild(char ch)
        {
            _ = Children.TryGetValue(ch, out Node node);
            return node;
        }
        public Node[] GetChildren()
        {
            return Children.Values.ToArray();
        }
    }
    public class Tries
    {
        private Node root = new Node(' ');
        public void Insert(string word)
        {
            var current = root;
            foreach (char ch in word)
            {
                if (!current.HasChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }
            current.IsEnd = true;
        }
        public void Remove(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                Remove(root, word, 0);
            }

        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.IsEnd = false;
                return;
            };

            char ch = word[index];
            Node child = root.GetChild(ch);
            if (child == null) return;

            Remove(child, word, index + 1);

            if (child.GetChildren().Length == 0 && !child.IsEnd)
            {
                child.Remove(ch);
            }
        }

        public List<string> FindWords(string prefix)
        {
            Node lastNode = FindLastNodeOf(prefix);
            var words = new List<string>();
            FindWords(lastNode, prefix, words);

            return words;
        }

        private Node FindLastNodeOf(string prefix)
        {
            if (prefix == null)
                return null;

            Node current = root;

            foreach (var ch in prefix)
            {
                var child = current.GetChild(ch);
                if (child == null) return null;

                current = child;
            }
            return current;
        }

        public void FindWords(Node root, string prefix, List<string> words)
        {
            if (root == null)
            {
                return;
            }
            if (root.IsEnd)
            {
                words.Add(prefix);
            }
            foreach (var child in root.GetChildren())
            {
                FindWords(child, prefix + child.Value, words);

            }
        }


        public string LongestCommentPrefix()
        {
            StringBuilder prefix = new StringBuilder();
            LongestCommentPrefix(root, prefix);

            return prefix.ToString();
        }
        private void LongestCommentPrefix(Node root, StringBuilder prefix)
        {
            var current = root;

            var children = current.GetChildren();
            if (children.Length > 1)
            {
                return;
            }

            foreach(var child in children)
            {
                prefix.Append(child.Value);
                LongestCommentPrefix(child, prefix);
            }


        }
      

    
        public void Traverse()
        {
            Traverse(root);
        }
        private void Traverse(Node root)
        {
            var children = root.GetChildren();
            foreach (var item in children)
            {
                Traverse(item);
            }
            Console.WriteLine(root.Value);

        }

        public int CountWords()
        {
            List<char> count = new List<char>();
            CountWords(root, count);
            return count.Count;
        }

        private void CountWords(Node root, List<char> count)
        {
            if (root.IsEnd) { count.Add(root.Value); }

            var children = root.GetChildren();
            foreach (var item in children)
            {
                CountWords(item, count);
            }
        }
        public bool Contains(string word)
        {

            var current = root;
            foreach (char ch in word)
            {
                if (!current.HasChild(ch))
                    return false;

                current = current.GetChild(ch);
            }

            return current.IsEnd;
        }

        public bool ContainsRecursive(string word)
        {
            return ContainsRecursive(root, word, 0);
        }

        private bool ContainsRecursive(Node root, string word, int index)
        {
            if (index == word.Length && root.IsEnd) return true;
          //  if (root.IsEnd) return true;
            var ch = word[index];
            var child = root.GetChild(ch);
            if (child == null) return false;
           return ContainsRecursive(child, word, index +1);
        }
    }
}
