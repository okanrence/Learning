using DataStructuresAndAlgos;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Transcription;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ConsoleApp1.Tree;

namespace ConsoleApp1
{
    class Program
    {

        static void greet(string anything, string anthing2)
        {
            var message = "a";
            Console.WriteLine(message);
            Console.WriteLine(anything);
            Console.WriteLine(anthing2);
        }

        static void greet2(string anything)
        {
            var message = "jhgkjh,bkhb";
            Console.WriteLine(message);
            Console.WriteLine(anything);
        }

        public static int[] HeapSort(int[] array)
        {
            var heap = new Heap(array.Length);
            for (var i = 0; i < array.Length; i++)
            {
                heap.Insert(array[i]);
            }

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = heap.Remove();
            }

            return array;

        }

        public static void Heapify(int[] items)
        {
            int lastParentIndex = items.Length / 2 - 1;
            for (int i = lastParentIndex; i >= 0; i--)
            {
                Heapify(items, i);
            }
        }

        private static void Heapify(int[] array, int index)
        {
            int largerIndex = index;

            int leftIndex = index * 2 + 1;
            if (leftIndex < array.Length && array[leftIndex] > array[largerIndex])
                largerIndex = leftIndex;

            int rightIndex = index * 2 + 2;
            if (rightIndex < array.Length && array[rightIndex] > array[largerIndex])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);
            Heapify(array, largerIndex);
        }

        private static void Swap(int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        public static int[] PlusOne(int[] digits)
        {
            digits[^1]++;
            return digits;
        }

        public static int Atoi(string str)
        {
            long num = 0;
            bool signFound = false;
            bool digitFound = false;
            bool isNegative = false;

            foreach (var c in str)
            {
                if (c == ' ')
                {
                    if (digitFound || signFound)
                        break;
                    else continue;
                }

                if ((c == '+' || c == '-' || Char.IsDigit(c)))
                {
                    if (c == '+' || c == '-')
                    {
                        if (!signFound && !digitFound)
                        {
                            signFound = true;
                            if (c == '-') isNegative = true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (Char.IsDigit(c))
                    {
                        int value = c - '0';
                        if (value > 9) break;
                        num = num * 10 + value;
                        digitFound = true;

                    }
                    else
                    {
                        if (digitFound) break;

                    }
                }
                else
                {
                    if (digitFound)
                    {
                        break;
                    }
                    else
                    {
                        return 0;
                    }

                }
            }

            if (digitFound)
            {
                if (isNegative)
                    num *= -1;
                else if (!isNegative && num < 0)
                    return int.MaxValue;

                if (num >= int.MaxValue)
                    return int.MaxValue;
                else if (num <= int.MinValue)
                    return int.MinValue;
                else
                {
                    int result = (int)num;
                    return result;
                }
            }
            else
                return 0;
        }

        public static int findMinSubArray(int S, int[] arr)
        {
            int windowEnd;
            int windowStart = 0;
            int sum = 0;


            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= S)
                {
                    return 1;
                }
            }

            for (int k = 2; k < arr.Length - 1; k++)
            {
                for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
                {
                    sum += arr[windowEnd];

                    if (windowEnd >= k - 1)
                    {

                        if (sum >= S)
                        {
                            return k;
                        }

                        sum -= arr[windowStart++];

                    }
                }

                sum = 0;
            }

            return 0;
        }

        public static int findMinSubArray2(int S, int[] arr)
        {
            int windowEnd;
            int windowStart = 0;
            int sum = 0;
            int minLength = int.MaxValue;
            for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                sum += arr[windowEnd];

                while (sum >= S)
                {
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1);
                    sum -= arr[windowStart++];
                }

            }

            return minLength == int.MaxValue ? 0 : minLength;
        }

        public static int findLength(char[] arr)
        {
            /*loop through chars
             add each char to a dictionary, if it already exists, increment the key by 1, 
             until we have k distinct characters in the dictionary. This will represent our current sliding window 
             And current max length will be the diffrence between the syart of the window and the end.
             check if total lenth of dictionary is more than k, then decrement the sliding window while adding a new char to the dictionary
             and update the max length each time 
              */

            Dictionary<char, int> dict = new Dictionary<char, int>();
            int windowStart = 0;
            int maxlength = 0;
            int k = 2;
            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                char currentChar = arr[windowEnd];
                if (dict.ContainsKey(currentChar))
                    dict[currentChar] = dict[currentChar] + 1;
                else
                    dict.Add(currentChar, 1);


                while(dict.Count > k)
                {
                    char firstChar = arr[windowStart++];
                    dict[firstChar] = dict[firstChar] - 1;
                    if (dict[firstChar] == 0) dict.Remove(firstChar);
                }

                maxlength = Math.Max(maxlength, windowEnd - windowStart + 1);

                
            }
            return maxlength;
        }
        public static int findLength(String str, int k)
        {
            if (string.IsNullOrEmpty(str) || str.Length < k) throw new InvalidOperationException();

            /*loop through chars
            add each char to a dictionary, if it already exists, increment the key by 1, 
            until we have k distinct characters in the dictionary. This will represent our current sliding window 
            And current max length will be the diffrence between the syart of the window and the end.
            check if total lenth of dictionary is more than k, then decrement the sliding window while adding a new char to the dictionary
            and update the max length each time 
             */

            Dictionary<char, int> result = new Dictionary<char, int>();
            int windowStart =0; int max = 0;
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char currentChar = str[windowEnd];
                if (result.ContainsKey(currentChar))
                    result[currentChar] = result[currentChar] + 1;
                else
                    result[currentChar] = 1;

                while (result.Count > k)
                {
                    var leftmostChar = str[windowStart++];
                    result[leftmostChar] = result[leftmostChar] - 1;
                    if (result[leftmostChar] == 0) result.Remove(leftmostChar);
                }
                max = Math.Max(max, windowEnd - windowStart + 1);

            }
            return max;
        }

        public static int findMaxSumSubArray(int k, int[] arr)
        {

            int windowSum = 0;
            int max = int.MinValue;
            int windowStart = 0;
            int windowEnd = 0;

            for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                windowSum += arr[windowEnd];

                if (windowEnd >= k - 1)
                {
                    max = max > windowSum ? max : windowSum;
                    windowSum -= arr[windowStart++];
                }
            }

            return max;
        }


        public static int findLength(String str)
        {
            // find the length of the longest substring which has no repeating characters.


            if (string.IsNullOrEmpty(str)) throw new InvalidOperationException();

            int windowStart = 0; int windowEnd = 0;
            var keyValuePairs = new Dictionary<char, int>();
            for( windowEnd = 0; windowEnd< str.Length; windowEnd++)
            {
                var currentChar = str[windowEnd];
                if (keyValuePairs.ContainsKey(currentChar))
                    keyValuePairs[currentChar] += 1;
                else
                    keyValuePairs.Add(currentChar, 1);


                while(keyValuePairs.Count < windowEnd)
                {
                    var firstChar = str[windowStart++];
                    keyValuePairs[firstChar] -= 1;
                    if (keyValuePairs[firstChar] == 0) keyValuePairs.Remove(firstChar);


                }

               
                    
            }
            return windowEnd - windowStart + 1; 
        }
        static void Main(string[] args)
        {

            int[] arr1 = new int[] { 2, 1, 5, 2, 8 };

            int k1 = 2;

            string str = "aabccbb";
            var max = findLength(str);
           // var da = findMinSubArray(8, arr1);
            // var max = findMaxSumSubArray(k1, arr1);



            double windowSum = 0;
            int windowStart = 0;
            int windowEnd = 0;
            double[] result1 = new double[arr1.Length - k1 + 1];

            for (windowEnd = 0; windowEnd < arr1.Length; windowEnd++)
            {
                windowSum += arr1[windowEnd];

                if (windowEnd >= k1 - 1)
                {
                    result1[windowStart] = windowSum / 5;
                    windowSum -= arr1[windowStart++];
                }
            };



            //  for(int i=0; i<= arr.Length)

            //string str = "- 234";

            //var atoi = Atoi(str);

            List<string> result = new List<string>();

            string[] dictionary = { "water", "big", "apple", "watch", "banana", "york", "amsterdam", "orange", "macintosh", "bottle", "book" };
            string[] userInput = { "paris", "applewatch", "ipod", "amsterdam", "bigbook", "orange", "waterbottle", "orangeapple", "bigwater", "waterbig" };

            var hashSet = new HashSet<string>();
            var resultSet = new HashSet<string>();
            foreach (var item in dictionary)
            {
                hashSet.Add(item);
            }

            //var str = new StringBuilder();
            var word = new StringBuilder();

            foreach (var item in userInput)
            {
                // bool wordFound = false;

                int i = 0;
                //int j = 1;

                //while (j < item.Length)
                //{
                //    if (hashSet.Contains(item.Substring(i,j)))
                //    {
                //        word.Append(item.Substring(i,j));
                //        i = j;
                //    }
                //    j++;
                //}


                for (int j = 1; j < item.Length - i; j++)
                {
                    if (hashSet.Contains(item.Substring(i, j)))
                    {
                        word.Append(item.Substring(i, j));
                        i = j;

                    }
                }

                if (word.Length > 0)
                    resultSet.Add(word.ToString());



                //str.Clear();
                //word.Clear();
            }

            //foreach (var item in userInput)
            //{
            //    bool wordFound = false;
            //    for (int i = 0; i < item.Length; i++)
            //    {
            //        str.Append(item[i]);

            //        if (hashSet.Contains(str.ToString()) && wordFound)
            //        {
            //            word.Append(str);
            //            resultSet.Add(word.ToString());
            //        }
            //        else if (hashSet.Contains(str.ToString()))
            //        {
            //            wordFound = true;
            //            word.Append(str);
            //            str.Clear();
            //        }
            //    }

            //    str.Clear();
            //    word.Clear();
            //}


            for (int i = 0; i < dictionary.Length; i++)
            {
                for (int j = i + 1; j < dictionary.Length; j++)
                {
                    if (userInput.Contains($"{dictionary[i]}{dictionary[j]}"))
                    {
                        result.Add($"{dictionary[i]}{dictionary[j]}");
                    }

                    if (userInput.Contains($"{dictionary[j]}{dictionary[i]}"))
                    {
                        result.Add($"{dictionary[j]}{dictionary[i]}");

                    }
                }
            }







            int[] arr = { 1, 0, 0 };

            var ffsd = PlusOne(arr);
            var fsfs = ffsd;
            //  var tries = new Tries.Tries();
            // // tries.Insert("card");
            //  tries.Insert("car");
            // // tries.Insert("dog");
            ////  tries.Insert("cartty");

            //  var fd = tries.FindWords("fa");
            //  var count = tries.CountWords();
            //  var pre = tries.LongestCommentPrefix();
            ////  tries.Remove("car");
            //  //var r = tries.Contains("ca");
            // var t = tries.Contains("carf");
            //var y = tries.Contains("cay");

            //tries.Traverse();
            //var fsfs = "SN1530130130102000054579";

            //var br = fsfs.Substring(5, 5);


            //var fs = isPalindrome("ABBA");
            //var s = AreAnangrams("DCBA", "ABDC");


            //int[] arr = { 4, 8, 1, 6, 100, 7, 2, -1 };
            //var d = SelectionSort(arr);

            var serv = new OutputMap.TestService();
            var data = serv.GetData();
            var svs = serv.BuildObject(data);
            var dss = svs;

            //var jsonObject = new JsonObject();
            //var serviceList = new Servicelist();
            //serviceList.InternalModuleID = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.IsActive = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.MaxAmount= new string[] { "1000", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.MinAmount = new string[] { "2000", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ModuleName = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceCode = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceDenominationID = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceIconMob = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceIconWeb = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceID = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceImage = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceName = new string[] { "name", "dgcj","oida","name2","oahd","yhda","oujdaad","odaba"};
            //serviceList.ServiceType = new string[] { "abcd", "dgcj","oida","jdao","oahd","yhda","oujdaad","odaba"};

            //var serv = new TestService();
            //var result = serv.BuildObject(serviceList);

            var graph = new Graph.Graph();
            graph.AddNode("X");
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("P");

            graph.AddEdge("X", "A");
            graph.AddEdge("X", "B");
            graph.AddEdge("A", "P");
            graph.AddEdge("B", "P");
            //graph.AddNode("A");
            //graph.AddNode("B");
            //graph.AddNode("C");
            //graph.AddNode("D");

            //graph.AddEdge("A", "B");
            //graph.AddEdge("B", "D");
            //graph.AddEdge("D", "C");
            //graph.AddEdge("A", "C");
            // graph.RemoveEdge("A", "C");
            //var result = graph.TopologicalSort();

            int k = 2;
            //var sample = new int[] { 5, 3, 8, 4, 1, 2 };

            ////Heapify(sample);
            //var result = HeapSort(sample);
            //if(k<1 || k > sample.Length)
            //{
            //    throw new Exception("Invalid Operation");
            //}

            //int kthLargest = result[k - 1];

            //var heap = new MinHeap(10);
            //heap.Insert(10);
            //heap.Insert(5);
            //heap.Insert(17);
            //heap.Insert(4);
            //heap.Insert(32);
            //heap.Insert(20);
            //heap.Insert(15);
            //heap.Insert(42);

            //var item = heap.Remove();


            //var heap = new MinHeap(100);
            //heap.Insert(new Node(10, "Ten"));
            //heap.Insert(new Node(5, "Five"));
            //heap.Insert(new Node(17, "Seventeen"));
            //heap.Insert(new Node(4, "Four"));
            //heap.Insert(new Node(32, "Thirty-Two"));
            //heap.Insert(new Node(20, "Twenty"));
            //heap.Insert(new Node(15, "Fifteen"));
            //heap.Insert(new Node(42, "Fourty-Two"));
            //var item = heap.Remove();
            //Console.WriteLine("Hello word");

            //  string str = "3";
            // var finder = new Finders();
            //var result = finder.findFirstNonRepeating(str);
            // Console.WriteLine(result);
            //var s = new Stacker();
            //var result = s.isBalanced(str);

            //var hfsv = new HashSet<int>();

            //hfsv.Add(9);
            //hfsv.Add(9);
            //hfsv.Add(9);

            //var list = new LinkedList();
            // list.AddLast(10);
            // list.AddLast(20);
            // list.AddLast(30);
            // list.AddLast(40);
            // list.AddLast(50);
            // list.AddLast(60);
            //var k = list.GetKthNodeFromTheEnd(3);
            // list.Reverse();
            //  values[0] = 1;
            //  values[1] = 2;
            //  values[2] = 3;
            //  count = 3;
            //  Insert(7);
            //  Insert(9);
            //  Insert(9);
            //  Insert(9);
            ////  RemoveAt(1);
            //  PrintArray();
            //  Console.ReadLine();

            // var u = factorial(4);=
            //var states = new int[] { 1, 1, 1, 0, 1, 1, 1, 1};

            //cellCompete(states, 2);

            //var dhskf = "27-01-2020 10:36:19";
            //var dd = DateTime.ParseExact(dhskf, "dd-MM-yyyy HH:mm:ss", null);
            // var d = Convert.ToDateTime(dhskf);

            //var fd = new MyNewClass();
            //fd.run();

            //  ServiceReference1.IService d = new ServiceReference1.ServiceClient(ServiceReference1.ServiceClient.EndpointConfiguration.BasicHttpBinding_IService);
            //var f =   d.GetSchemeChargesAsync("ROnline", 1000).Result;
            //  Calu();

            //int k = 1;
            //var input = new int[] { 2, -1000 };

            ////if (k <= 0) return input;
            ////if (input.Length == k) return input;
            //for (var i = 1; i <= k; i++)
            //{
            //    input = Rotate(input);

            //}
            //var d = input;


            //  int[] A = { -1000, 1000 };

            //int result = TapeEquilibrum(A);
            // int result = PermMissingElement(A);
            //int result = GetOddOccurence(A);
            //int result = 0;
            //foreach (var i in A)
            //    result = result ^ i;

            //Tree tree = new Tree();
            //tree.Insert(7);
            //tree.Insert(8);
            //tree.Insert(1);
            //tree.Insert(9);
            //tree.Insert(2);
            //tree.Insert(55);
            //tree.Insert(15);
            //tree.Insert(52);
            //tree.Insert(4);
            //tree.Insert(5);
            //tree.Insert(90);

            //Tree tree = new Tree();
            //tree.Insert(3);
            //tree.Insert(1);
            //tree.Insert(4);
            //tree.Insert(5);
            //tree.Insert(2);
            //tree.Insert(6);


            // tree.swapRoot();
            //   tree.NodeAtKthDistance(2);
            // Console.WriteLine(tree.countLeaves().ToString());

            //Tree tree2 = new Tree();
            //tree2.Insert(7);
            //tree2.Insert(8);
            //tree2.Insert(1);
            //tree2.Insert(9);
            //tree2.Insert(2);
            //tree2.Insert(55);
            //tree2.Insert(15);
            //tree2.Insert(52);
            //tree2.Insert(4);
            //tree2.Insert(5);

            //Console.WriteLine(tree.Equals(tree2).ToString());

            //   tree.Traverse(TraverseOrder.PostOrder);

            //Console.WriteLine(tree.min().ToString());
            //Console.WriteLine(tree.max().ToString());
            //Console.WriteLine(tree.find(9).ToString());
            //  Console.WriteLine(tree.ToString());
            //Console.ReadLine();
            // 7

            //int a = 1;
            //do
            //{
            //    a++;
            //    if (a != 2)
            //    {
            //        continue;
            //    }
            //    Console.WriteLine(a);

            //} while (a < 6);

            // Dictionary<string, object> items = new Dictionary<string, object>();

            //int[] myArray = { 1, 2, 3 };

            //var fd = from item in myArray 
            //         let d = myArray.Max() 
            //         select item * d into newlIST 
            //         select newlIST;
            //Console.WriteLine(fd);

            // var q = new Queue();
            // var myQueue = new Queue<int>();
            // myQueue.Enqueue(1);
            // myQueue.Enqueue(2);
            // myQueue.Enqueue(3);
            // myQueue.Enqueue(4);

            //var r =  q.reverse(myQueue);


            //var res = factorial(4);
            //Console.WriteLine(res.ToString());

            //var rese = factorialRecursive(4);
            //Console.WriteLine(rese.ToString());

            //Console.ReadLine();

            //  SynthesisToSpeakerAsync().Wait();
            // Console.WriteLine("Press any key to exit...");
            //  Console.ReadKey();

            //int[] A = { 4, -2, 4, -5, 7, 1, 9, -39 };
            //var d = find_min(A);

            //Console.WriteLine(d.ToString());

            //var f = GetMinMoves(-11);
            //var d =   find_min(f);
            // var f = solution(18, 2);
            //  KthPrime(100);
            // Console.WriteLine(f.ToString());
        }



        public static int[] BubbleSort(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }

            return arr;
        }

        public static int[] InsertionSort(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }

            return arr;
        }

        private static void swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;

        }
        public static int[] SelectionSort(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                for (int j = i; j < arr.Length; j++)
                {

                    if (arr[j] < arr[min])
                    {
                        min = j;
                        swap(arr, min, i);
                    }

                }

            }

            return arr;
        }

        public static int solution(int N, int K)
        {
            var count = 1;

            if (K < 1) return N - 1;

            for (int i = 1; i <= K; i++)
            {
                N /= 2;
                if (N <= 0)
                {
                    return count;
                }
                count++;

            }
            return count;


        }
        public static int GetMinMoves(int N)
        {
            int movesCount = 0;

            var L = 0;
            var R = 1;

            int absoluteN;

            if (N <= 0)
            {
                absoluteN = -N;
            }
            else
            {
                absoluteN = N--;
            }

            if (N <= 0)
                while (absoluteN != 0)
                {
                    if ((absoluteN & 1) == 1)
                    {
                        L = 2 * L - R;
                        movesCount++;
                    }
                    else
                    {
                        R = 2 * R - L;
                        movesCount++;
                    }

                    absoluteN >>= 1;
                }
            else
                while (absoluteN != 0)
                {
                    if ((absoluteN & 1) == 1)
                    {
                        R = 2 * R - L;
                        movesCount++;
                    }

                    else
                    {
                        L = 2 * L - R;
                        movesCount++;
                    }
                    absoluteN >>= 1;
                }

            return movesCount;
        }

        static void Prime(int k)
        {
            bool isPrime = true;
            int count = 0;
            Console.WriteLine("Prime Numbers : ");
            for (int i = 2; i <= int.MaxValue; i++)
            {
                for (int j = 2; j <= i; j++)
                {

                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                }
                if (isPrime)
                {
                    count++;
                    if (count == k)
                    {
                        Console.Write("\t" + i);
                        return;
                    }

                }
                isPrime = true;
            }
            Console.ReadKey();
        }

        public static void KthPrime(int k)
        {
            bool isPrime = true;
            int count = 0;
            for (int i = 2; i <= int.MaxValue; i++)
            {
                for (int j = 2; j <= i; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime && ++count == k)
                {
                    Console.Write("\t" + i);
                    return;
                }
                isPrime = true;
            }
        }
        static int[] GeneratePIntergers(int N)
        {
            var random = new Random();
            int[] result = new int[N];
            for (int i = 0; i <= N - 1; i++)
            {
                result[i] = random.Next(0, int.MaxValue);
            };
            return result;
        }

        static int find_min(int[] A)
        {
            int ans = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (ans > A[i])
                {
                    ans = A[i];
                }
            }
            return ans;
        }

        public static bool AreAnangrams(string a, string b)
        {
            var array1 = a.ToCharArray();
            Array.Sort(array1);

            var array2 = b.ToCharArray();
            Array.Sort(array2);

            if (Array.Equals(array1, array2))
            {
                return true;
            }

            return false;
        }

        public static bool isPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (word[left++] != word[right--]) return false;

            }
            return true;
        }


        public static async Task SynthesisToSpeakerAsync()
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription("87d32dcf6954483f81a4db09359feeed", "eastus");

            // Creates a speech synthesizer using the default speaker as audio output.
            using var synthesizer = new SpeechSynthesizer(config);
            // Receive a text from console input and synthesize it to speaker.
            Console.WriteLine("Type some text that you want to speak...");
            Console.Write("> ");
            string text = Console.ReadLine();

            using (var result = await synthesizer.SpeakTextAsync(text))
            {
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    Console.WriteLine($"Speech synthesized to speaker for text [{text}]");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }

            SynthesisToSpeakerAsync().Wait();
        }

        private static int factorial(int n)
        {
            var result = 1;
            for (var i = n; i > 1; i--)
            {
                result = result * i;
            }

            return result;
        }

        private static int FactorialRecursive(int n)
        {
            if (n == 0) return 1;
            return n * FactorialRecursive(n - 1);
        }


    }
}






