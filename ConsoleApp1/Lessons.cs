using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Lessons
    {
        static int[] values = new int[5];
        static int count;

        private static int TapeEquilibrum(int[] A)
        {
            int min = int.MaxValue;
            int left = A[0];
            int right = A.Sum() - left;

            for (int i = 1; i < A.Length; i++)
            {
                int x = A[i];
                left += x;
                right -= x;
                var val = Math.Abs(left - right);
                if (val < min)
                {
                    min = val;
                    // Early exit condition:
                    if (min == 0)
                    {
                        break;
                    }
                }

            }
            return min;
        }
        private static int PermMissingElement(int[] A)
        {
            int N = A.Length + 1;
            var sumAll = (N * (N + 1)) / 2;
            var sumArray = 0;
            foreach (var i in A)
                sumArray += i;

            var diff = sumAll - sumArray;
            return diff;
        }

        private static int GetOddOccurence(int[] input)
        {
            if (input.Length % 2 == 0) return 0;
            int store = 0;
            var temp = new List<int>();
            foreach (var i in input)
            {
                if (temp.Contains(i))
                {
                    store -= i;
                    temp.Remove(i);
                }
                else
                {
                    store += i;
                    temp.Add(i);
                }
            }

            return store;
        }
        private static int GetSmallestPositive(int[] A)
        {
            var N = A.Length;
            var set = new HashSet<int>();
            foreach (var a in A)
                set.Add(a);

            for (int i = 1; i <= N; i++)
            {
                if (!set.Contains(i))
                    return i;
            }
            return N + 1;
        }


        private static int[] Rotate(int[] input)
        {
            //if (k <= 0) return input;
            //if (input.Length == k) return input;

            int[] temp = new int[input.Length];
            int last = input[input.Length - 1];
            temp[0] = last;
            for (int i = 0; i < input.Length - 1; i++)
            {
                temp[i + 1] = input[i];
            }
            return temp;

        }

        private static void Calu()
        {
            Console.WriteLine("Enter value");
            var input = int.Parse(Console.ReadLine());

            var binaryStr = GetBinary(input);
            Console.WriteLine(binaryStr);

            var result = GetMaxBinaryGap(binaryStr);
            Console.WriteLine(result);
            Calu();
        }

        public static int GetMaxBinaryGap(string input)
        {
            char zero = '0';
            int longestGap = 0;
            List<int> temp = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == zero) continue;
                temp.Add(i);
            }

            for (int j = 0; j < temp.Count - 1; j++)
            {
                var diff = (temp[j + 1] - temp[j]) - 1;
                if ((diff - longestGap) > 0)
                {
                    longestGap = diff;
                }
            }

            return longestGap;
        }
        public static string GetBinary(int n)
        {
            if (n < 2) return n.ToString();

            var divisor = n / 2;
            var remainder = n % 2;

            return GetBinary(divisor) + remainder;
            //  return Convert.ToString(input, 2);
        }
        //METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public static int[] cellCompete(int[] states, int days)
        {
            // INSERT YOUR CODE HERE
            var n = states.Length;
            var d = 1;
            var temp = new bool[n];
            for (var i = 0; i < n; i++)
            {
                temp[i] = Convert.ToBoolean(states[i]);
            }
            while (d <= days)
            {
                temp[0] = false ^ Convert.ToBoolean(states[1]);
                temp[n - 1] = Convert.ToBoolean(states[n - 2]) ^ false;

                for (var i = 1; i < n - 2; i++)
                {
                    temp[i] = Convert.ToBoolean(states[i - 1]) ^ Convert.ToBoolean(states[i + 1]);
                }

                for (var i = 0; i < n; i++)
                {
                    states[i] = Convert.ToInt16(temp[i]);
                }
                d++;
            }

            return states;
        }
        // METHOD SIGNATURE ENDS

        private static int factorial(int n)
        {
            var result = 1;
            for (var i = n; i > 1; i--)
            {
                result *= i;
            }

            return result;
        }

        private static int factorialRecursive(int n)
        {
            if (n == 0) return 1;
            return n * factorialRecursive(n - 1);
        }


        private static void PrintArray()
        {
            foreach (int i in values)
            {
                Console.WriteLine(i);

            }
        }



        private static void Insert(int item)
        {
            //if array is full, resize it 
            if (values.Length == count)
            {
                int[] newValues = new int[count * 2];
                //copt all items in old array to new array
                for (int i = 0; i < count; i++)
                {
                    newValues[i] = values[i];
                }

                values = newValues;
            }

            values[count++] = item;

        }
        private static int[] RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < count; i++)
            {
                values[i] = values[i + 1];

            }
            count--;


            return values;
        }


       

    }
}

