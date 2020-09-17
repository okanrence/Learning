using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgos.Patterns
{
    public class SlidingWindow
    {
        /// <summary>
        /// Given an array of positive numbers and a positive number ‘S’, find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’. Return 0, if no such subarray exists.
        /// </summary>
        /// <param name="S"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMinSubArray(int S, int[] arr)
        {
            //Sum up values in the array
            //Once the some is more than or equal to S, keep shrinking the window while taking note of the min window length
            int windowEnd;
            int windowStart = 0;
            int sum = 0;
            int minLength = int.MaxValue;
            for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                sum += arr[windowEnd]; // add next element in array

                while (sum >= S)
                {
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1); //determine the smallest length so far
                    sum -= arr[windowStart++]; // subtract the value of the start of the current window
                }

            }

            return minLength == int.MaxValue ? 0 : minLength;
        }

        /// <summary>
        /// Given an array of positive numbers and a positive number ‘k’, find the maximum sum of any contiguous subarray of size ‘k’.
        /// Example 1:Input: [2, 1, 5, 1, 3, 2], k=3; Output: 9;Explanation: Subarray with maximum sum is [5, 1, 3].
        /// Example 2:Input: [2, 3, 4, 1, 5], k=2; Output: 7; Explanation: Subarray with maximum sum is [3, 4].
        /// </summary>
        /// <param name="S"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMaxSumSubArray(int k, int[] arr)
        {
            int windowSum = 0;
            int max = int.MinValue;
            int windowStart = 0;
            int windowEnd;

            for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                windowSum += arr[windowEnd]; // add next element in array

                if (windowEnd >= k - 1) // slide the window 
                {
                    max = max > windowSum ? max : windowSum;
                    windowSum -= arr[windowStart++]; // subtract the element going out from the running sum
                }
            }

            return max;
        }

        /// <summary>
        /// Given a string, find the length of the longest substring in it with no more than K distinct characters. This is also the fruots in a basket problem : k will be the number of distinct fruits to be picked
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindLength(string str, int k)
        {
            if (string.IsNullOrEmpty(str) || str.Length < k) throw new InvalidOperationException();

            /*loop through chars
            add each char to a dictionary, if it already exists, increment the key by 1, 
            until we have k distinct characters in the dictionary. This will represent our current sliding window 
            And current max length will be the difference between the start of the window and the end.
            check if total lenth of dictionary is more than k, then decrement the sliding window while adding a new char to the dictionary
            and update the max length each time 
             */

            Dictionary<char, int> result = new Dictionary<char, int>();
            int windowStart = 0; int max = 0;
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                char currentChar = str[windowEnd];
                if (result.ContainsKey(currentChar))
                    result[currentChar]++;
                else
                    result.Add(currentChar, 1);

                while (result.Count > k)
                {
                    var leftmostChar = str[windowStart++];
                    result[leftmostChar]--;
                    if (result[leftmostChar] == 0) result.Remove(leftmostChar);
                }
                max = Math.Max(max, windowEnd - windowStart + 1);
            }
            return max;
        }

        /// <summary>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int FindLength(string str)
        {
            if (string.IsNullOrEmpty(str)) throw new InvalidOperationException();

            int windowStart = 0;
            var dict = new Dictionary<char, int>();
            int windowEnd;
            for (windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var currentChar = str[windowEnd];
                if (dict.ContainsKey(currentChar))
                    dict[currentChar] += 1;
                else
                    dict.Add(currentChar, 1);

                while (dict.Count > windowEnd)
                {
                    var firstChar = str[windowStart++];
                    dict[firstChar] -= 1;
                    if (dict[firstChar] == 0) dict.Remove(firstChar);
                }
            }
            return windowEnd - windowStart + 1;
        }


        /// <summary>
        /// Given a string and a pattern, find out if the string contains any permutation of the pattern.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool FindPermutation(string str, string pattern)
        {
            //if the frequency is 0, then that char is completely matched.
            //if the matched counter is equal to the number of distinct chars in dict (dict.length) then we have found our required permutation
            //however, if the window is now greater than the lent of the pattern then we havent found the right permutation so we need to slide the window
            // when sliding, if the char we are sliding out is contained in the dict, then we need to add it back and decrement our counter

            if ((pattern.Length > str.Length) || string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern)) return false;

            //add all chars in pattern into a dictionary and track frequencies of repeated chars
            var dict = new Dictionary<char, int>();
            foreach (var chr in pattern)
            {
                if (dict.ContainsKey(chr))
                    dict[chr]++;
                else
                    dict.Add(chr, 1);
            }

            int windowStart = 0; int windowEnd; int matched = 0;
            //if a char in the str exists in the dict, decrement the frequency and increment the matched counter.
            for (windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var currentChar = str[windowEnd];
                if (dict.ContainsKey(currentChar))
                {
                    dict[currentChar]--;
                    if (dict[currentChar] == 0)
                        matched++;
                }

                if (matched == dict.Count())
                    return true;

                if (windowEnd >= pattern.Length - 1)
                {
                    var leftChar = str[windowStart++];
                    if (dict.ContainsKey(leftChar))
                    {
                        if (dict[leftChar] == 0)
                            matched--;

                        dict[leftChar]++;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Given a string with lowercase letters only, if you are allowed to replace no more than ‘k’ letters with any letter, find the length of the longest substring having the same letters after replacement
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int CharacterReplacement(string str, int k)
        {
            int windowEnd;
            int windowStart = 0; int maxlegth = 0; int windowMaxLegth = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (windowEnd = 0; windowEnd < str.Length;)
            {
                var currentChar = str[windowEnd];
                if (dict.ContainsKey(currentChar))
                    dict[currentChar]++;
                else
                    dict.Add(currentChar, 1);


                windowMaxLegth = Math.Max(windowMaxLegth, dict[currentChar]);

                // current window size is from windowStart to windowEnd, overall we have a letter which is
                // repeating 'maxRepeatLetterCount' times, this means we can have a window which has one letter 
                // repeating 'maxRepeatLetterCount' times and the remaining letters we should replace.
                // if the remaining letters are more than 'k', it is the time to shrink the window as we
                // are not allowed to replace more than 'k' letters

                if (windowEnd - windowStart + 1 - windowMaxLegth > k)
                {
                    var leftChar = str[windowStart++];
                    dict[leftChar]--;
                }

                maxlegth = Math.Max(maxlegth, windowEnd - windowStart + 1);
            }
            return maxlegth;

        }

        /// <summary>
        /// Given an array of 0s and 1s, if you are allowed to replace no more than ‘k’ 0s with 1s, find the length of the longest contiguous subarray having all 1s.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int LongestOnesAfterReplacement(int[] arr, int k)
        {
            int windowEnd;
            int windowStart = 0; int maxlegth = 0; int maxOnes = 0;

            for (windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                if (arr[windowEnd] == 1) maxOnes++;
                if (windowEnd - windowStart + 1 - maxOnes > k)
                {
                    if (arr[windowEnd] == 1) maxOnes--;

                    windowStart++;
                }
                maxlegth = Math.Max(maxlegth, windowEnd - windowStart + 1);
            }
            return maxlegth;

        }

        /// <summary>
        /// Given a string and a pattern, return the start indices of every occurence of the pattern and its palindrome.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int[] FindPermutation2(string str, string pattern)
        {
            var output = new List<int>();

            int windowEnd, windowStart = 0; int matched = 0;

            var dict = new Dictionary<char, int>(pattern.Length);

            foreach (var ch in pattern)
            {
                if (dict.ContainsKey(ch))
                    dict[ch]++;
                else
                    dict.Add(ch, 1);
            }



            for (windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                var currentChar = str[windowEnd];

                if (dict.ContainsKey(currentChar))
                {
                    dict[currentChar]--;
                    if (dict[currentChar] == 0) matched++;
                }

                if (matched == dict.Count())
                    output.Add(windowStart);

                if (windowEnd >= pattern.Length - 1)
                {
                    var leftChar = str[windowStart++];
                    if (dict.ContainsKey(leftChar))
                    {
                        if (dict[leftChar] == 0)
                            matched--;

                        dict[leftChar]++;
                    }
                }
            }

            return output.ToArray();
        }


        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }

            }

            return i + 1;
        }


        public static IList<IList<string>> groupAnagrams(string[] strs)
        {

            if (strs.Length == 0) return new List<IList<string>>();

            var dict = new Dictionary<string, IList<string>>();

            foreach (var item in strs)
            {
                var chs = item.ToCharArray();
                Array.Sort(chs);
                var key = new string(chs);


                if (!dict.ContainsKey(key))
                    dict.Add(key, new List<string>());

                dict[key].Add(item);

            }


            return new List<IList<string>>(dict.Values);
        }


        //public static string MinWindow(string s, string t)
        //{

        //    if (t.Length > s.Length || string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

        //    int windowEnd;
        //    int windowStart = 0;
        //    int matches = 0;

        //    var dict = new Dictionary<char, int>(t.Length);

        //    foreach (var ch in t)
        //    {
        //        if (!dict.ContainsKey(ch))
        //            dict.Add(ch, 1);
        //        else
        //            dict[ch]++;
        //    }

        //    for (windowEnd = 0; windowEnd < s.Length; windowEnd++)
        //    {
        //        var currentChar = s[windowEnd];

        //        if (dict.ContainsKey(currentChar))
        //        {
        //            dict[currentChar]--;
        //            if (dict[currentChar] == 0)
        //                matches++;
        //        }

        //        if (matches == dict.Count())
        //        {
        //            var ds = s.Substring(windowStart, (windowEnd - windowStart) + 1);
        //            return ds;
        //        }

        //        if (windowEnd - windowStart + 1 >= t.Length)
        //        {
        //            var leftChar = s[windowStart++];
        //            if (dict.ContainsKey(leftChar))
        //            {
        //                if (dict[leftChar] == 0)
        //                    matches--;

        //                dict[leftChar]++;
        //            }
        //        }

        //    }
        //    return "";
        //}

        public static string MinWindow(string s, string t)
        {

            if (t.Length > s.Length || string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";

            int windowEnd, windowStart = 0, matches = 0, minWindowStart = -1, minWindowEnd = 0;

            var dict = new Dictionary<char, int>(t.Length);

            foreach (var ch in t)
            {
                if (!dict.ContainsKey(ch))
                    dict.Add(ch, 1);
                else
                    dict[ch]++;
            }

            for (windowEnd = 0; windowEnd < s.Length; windowEnd++)
            {
                var currentChar = s[windowEnd];

                if (dict.ContainsKey(currentChar))
                {
                    dict[currentChar]--;
                    if (dict[currentChar] == 0)
                        matches++;
                }

                if (windowEnd >= 12)
                {

                }

                while (matches >= dict.Count())
                {
                    minWindowStart = Math.Max(minWindowStart, windowStart);
                    minWindowEnd = Math.Max(minWindowEnd, windowEnd);

                    var leftChar = s[windowStart++];
                    if (dict.ContainsKey(leftChar))
                    {
                        if (dict[leftChar] == 0)
                            matches--;

                        dict[leftChar]++;
                    }

                }

            }
            var result = minWindowStart == -1 ? "" : s.Substring(minWindowStart, minWindowEnd - minWindowStart + 1);
            return result;
        }

        private static int Read4(char[] buf4)
        {
            return buf4.Length;
        }

        public static int read(char[] buf, int n)
        {
            int copiedChars = 0, readChars = 4;
            char[] buf4 = new char[4];

            while (copiedChars < n && readChars == 4)
            {
                readChars = Read4(buf4);

                for (int i = 0; i < readChars; ++i)
                {
                    if (copiedChars == n) return copiedChars;
                    buf[copiedChars] = buf4[i];
                    ++copiedChars;
                }
            }
            return copiedChars;
        }

        public static bool isPalindrome(string s)
        {
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                while (i < j && !char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (i < j && char.ToLower(s[i]) != char.ToLower(s[j]))
                    return false;
            }

            return true;
        }

    }
}


//"cabwefgewcwaefgcf"
//"cae"
//
//01,234567,8
//aa,bbaacd,e

/*a 2
 *b 2
 * c 1
 * d 1
 * e 1
 * wmx 4
 * mx  6
*/

