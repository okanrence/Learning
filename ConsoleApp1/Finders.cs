using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public  class Finders
    {
        public char findFirstNonRepeating(string str)
        {
            if(str.Length < 1)
                return char.MinValue;
            var maps = new Dictionary<char, int>();
            foreach(var item in str)
            {
                if (maps.ContainsKey(item))
                {

                    maps[item] = maps.GetValueOrDefault(item) + 1;
                }
                else
                {
                    maps.Add(item, 1);
                }
            }

            foreach(var item in str)
            {
                if (maps.GetValueOrDefault(item) == 1)
                    return item;
            }
            return char.MinValue;

        }
    }
}
