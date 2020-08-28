using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgos
{
   public class QuickSort
    {
        public int[] sort(int[] array)
        {

        }
        

        public int partition(int [] array)
        {
            int pivot = array.Length - 1;
            int boundry = -1;

           for(int i=0; i<array.Length; i++)
            {
                if(array[i]<= boundry)
                {
                    boundry++;
                    //swap the item in current index with boundry
                }
            }

            return boundry;
        }
    }
}
