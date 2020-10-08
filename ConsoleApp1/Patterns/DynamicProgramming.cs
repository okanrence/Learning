using ConsoleApp1;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgos.Patterns
{
    public class DynamicProgramming
    {
        public static int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                var profit = prices[i] - minPrice;
                maxProfit = Math.Max(maxProfit, profit);
            }

            return maxProfit;
        }

        public static string RestoreString(string s, int[] indices)
        {
            char[] t = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                t[indices[i]] = s[i];
            }


            return new string(t);
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            var index = new int[26];
            for (int i = 0; i < index.Length; ++i)
            {
                var chAt = order[i] - 'a';
                index[chAt] = i;
            }



            // Search:
            for (int i = 0; i < words.Length - 1; ++i)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                int length = Math.Min(word1.Length, word2.Length);
                bool flag = false;

                for (int j = 0; j < length; ++j)
                {
                    if (word1[j] != word2[j])
                    {
                        var chrAtWord1 = index[word1[j] - 'a'];
                        var chrAtWord2 = index[word2[j] - 'a'];
                        if (chrAtWord1 > chrAtWord2)
                        {
                            return false;
                        }
                        flag = true;
                        break;
                    }
                }
                if (flag) continue;

                if (word1.Length > word2.Length)
                    return false;
            }
            return true;

        }

        public string minRemoveToMakeValid(String s)
        {
            var indiciesToRemove = new HashSet<int>();
            var stack = new Stack<int>(s.Length);
            var output = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else if (s[i] == ')')
                {
                    if (stack.Count < 1)
                    {
                        indiciesToRemove.Add(i);
                    }
                }
            }

            while (stack.Count > 0) indiciesToRemove.Add(stack.Pop());

            for (int i = 0; i < s.Length; ++i)
            {
                if (!indiciesToRemove.Contains(i))
                {
                    output.Append(s[i]);
                }
            }

            return output.ToString();
        }

        public static bool ValidPalindrome(string s)
        {
            int start = 0, end = s.Length - 1;

            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return IsPalindromeRange(s, start + 1, end) || IsPalindromeRange(s, start, end - 1);
                }
                start++; end--;
            }

            return true;
        }

        private static bool IsPalindromeRange(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end]) { return false; }
                start++; end--;
            }
            return true;
        }

        public string AddStrings(string num1, string num2)
        {
            StringBuilder str = new StringBuilder();
            var stack = new Stack<int>();
            int p1 = num1.Length - 1;
            int p2 = num2.Length - 1;
            int carry = 0;
            while (p1 >= 0 || p2 >= 0)
            {
                int x1 = p1 > 0 ? num1[p1] - '0' : 0;
                int x2 = p2 > 0 ? num2[p2] - '0' : 0;


                int value = (x1 + x2 + carry) % 10;
                carry = (x1 + x2 + carry) / 10;

                stack.Push(value);
                p1--; p2--;
            }

            if (carry != 0)
            {
                stack.Push(carry);
            }

            foreach (var d in stack)
            {
                str.Append(d);
            }
            return str.ToString();
        }

        public static int solveKnapsack(int[] profits, int[] weights, int capacity)
        {
            return knapsackRecursive(profits, weights, capacity, 0);
        }

        private static int knapsackRecursive(int[] profits, int[] weights, int capacity, int currentIndex)
        {
            if (capacity < 0 || currentIndex >= profits.Length) return 0;

            int profit1 = 0;
            if(weights[currentIndex]<= capacity)
            {
                profit1 = profits[currentIndex] + knapsackRecursive(profits, weights, capacity - weights[currentIndex], currentIndex + 1);
            }

            var profit2 = knapsackRecursive(profits, weights, capacity, currentIndex + 1);

            return Math.Max(profit1, profit2);

            var car = Heap()
        }
    }
}
