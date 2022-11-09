using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSearch
{
    public class Searcher
    {
        public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            if (list is null)
            {
                throw new ArgumentNullException();
            }
            
            //init indices
            start = 0;
            end = 0;
            
            //find the right boundary
            int max = list.Count;
            if (max == 0) return;   //list is emply, nothing to search for
            
            //temporary sum of a fragment of the list
            ulong temp_sum = 0;

            for (; ;)
            {
                if (temp_sum == sum)
                {
                    if (start == end)
                    {
                        //starting calculation for a fragment
                        temp_sum = list[start];
                        end++;
                        if (end == max) break; //TODO make the end condition check not so ugly
                    }
                    else
                    {
                        //the match found
                        return;
                    }
                }
                else if (temp_sum < sum)
                {
                    //grow right = add next element & mind the right boundary
                    if (end < max)
                    {
                        temp_sum += list[end++];
                    }
                    else
                    {
                        //the right boundary is reached and the sum is still not found - exit
                        break; //TODO make the end condition check not so ugly
                    }
                }
                else if (temp_sum > sum)
                {
                    //trim left = remove first element & mind the end position
                    if (start < end)
                    {
                        temp_sum -= list[start++];
                    }
                    //eventually start will become equal to end, sum will be 0 at the time,
                    //then we'll move rightward to a next fragment of the list
                }
            }
            //there was no match found, reset indices
            start = 0;
            end = 0;
        }
    }
}
