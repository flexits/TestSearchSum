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

            int max = list.Count;   //maximim allowed end variable value
            start = 0;
            end = 0;
            if (max == 0) return;   //list is emply, nothing to search for

            ulong temp_sum = 0;     //sum of elements between start and end

            for (; end < max;)
            {
                if (temp_sum == sum)
                {
                    //match found
                    return;
                }
                else if (temp_sum < sum)
                {
                    //grow right = add next element & mind the right boundary
                    temp_sum += list[end];
                    end++;
                    continue;
                }
                else if (temp_sum > sum)
                {
                    //trim left = remove first element
                    temp_sum -= list[start];
                    start++;
                    continue;
                }
            }

            start = 0;
            end = 0;
        }
    }
}
