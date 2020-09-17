using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgos.Patterns
{
    public class DynamicProgramming
    {
        public static int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    var profit = prices[j] - prices[i];
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }

            return maxProfit;
        }
    }
}
