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
            /*
             * Finds the subsequnce of elements whose sum equals the given one.
             * 
             * The subsequence is started with the first element of the given list.
             * Operations with the subsequence are implemented in a cycle. Each
             * iteration of the cycle means a single element is added to or distracted
             * from the subsequnce, then the sum of the elements is compared to the 
             * required value.
             * 
             * If the sum is less than needed, then the subsequence grows rightwards -
             * that means, the next element of the initial list is added. If the end index
             * reaches the list size, the cycle is interrupted.
             * 
             * If the sum becomes greater than needed, the subsequence shrinks from the
             * left edge - that means, the first element of the subsequence is removed, then
             * the second, and so on. In this case, we check the subsequence size: if its
             * start index is less by 1 then its end index, that means no elements left. Then
             * there are two possible scenarios: if the end index equals the list size - we
             * ran out of the initial list and the cycle is interrupted, if not - we make 
             * "a jump", i.e. start a new subsequence with list[end] element as its first one.
             * 
             * Alexander V. Korostelin, 2022 https://www.linkedin.com/in/akorostelin/ 
             */

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
            
            //init subsequence with a starting element
            ulong temp_sum = list[start];
            end++;

            for (; ;)
            {
                if (temp_sum == sum)
                {
                    //the match found
                    return;
                }
                else if (temp_sum < sum)
                {
                    if (end == max)
                    {
                        //the end of the list is reached - exit
                        break;
                    }
                    else
                    {
                        //grow subsequence rightward, i.e. add a next element from the list
                        temp_sum += list[end++];
                    }
                }
                else if (temp_sum > sum)
                {
                    if (start + 1 == end)
                    {
                        //the subsequence is empty
                        if (end == max)
                        {
                            //the end of the list is reached - exit
                            break;
                        }
                        else
                        {
                            //make jump to the right part of the list
                            start = end;
                            temp_sum = list[start];
                            end++;
                        }
                    }
                    else
                    {
                        //trim subsequence left, i.e. remove its first element
                        temp_sum -= list[start++];
                    }
                }
            }
            //no match found, reset indices
            start = 0;
            end = 0;
        }
    }
}
