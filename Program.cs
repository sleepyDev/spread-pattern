using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeElements
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Test case: Sum of the values in arr should always be equal to the value of the first parameter in spreadPattern() */
            int[] arr = spreadPattern(12, 13);
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
                sum += arr[i];
            }
            Console.WriteLine(sum);
        }
        // method for creating an evenly spread array of values
        public static int[] spreadPattern(int SrcArrLen, int DestArrLen)
        {
            // store the spread pattern in this array
            int[] resultArr = new int[DestArrLen];

            // variables to remember how many values per element
            double perElement = (double)SrcArrLen / (double)DestArrLen;
            double copy = perElement; // this is needed when we iterate the result array
            
            int extraElements = 0;
            if (perElement >= 1 && perElement % 1 != 0) // if there's more elements than one and they have a remainder from being divided by 1
            {
                // store the amount of extra elements
                extraElements = SrcArrLen - DestArrLen;
            }
            else if (perElement % 1 != 0)
            {
                int x = 0;
                for (double j = perElement; j > 0.5;) // insert some extra elements until there's an even number left
                {
                    if (x == resultArr.Length) x = 0;

                    resultArr[x] += 1;
                    SrcArrLen--;
                    j = (double)SrcArrLen / (double)DestArrLen;
                    x++;
                }
            }

            int i = 0;
            if (perElement % 1 != 0) // if true, go to the loop for uneven numbers
            {               
                while (SrcArrLen > 0)
                {
                    if (i == resultArr.Length) // stay within array bounds
                        i = 0;
                    if (extraElements > 0) // insert extra elements first, when they're inserted add remaining elements.
                    {
                        resultArr[i] += 1;
                        SrcArrLen--;
                        extraElements--;
                        i++;
                        continue;
                    }
                    if (copy >= 1) // check if we've reached the threshold to insert value (needed when perElement < 1)
                    {
                        // here we insert values to the result table
                        if (perElement >= 1)
                        {
                            resultArr[i] += (int)perElement;
                            copy = perElement;
                            SrcArrLen -= (int)perElement;
                            i++;
                            continue;
                        }
                        else
                        {
                            resultArr[i] += 1;
                            copy = perElement;
                            SrcArrLen--;
                            i++;
                            continue;
                        }
                    }
                    copy += perElement;
                    i++;
                }
            } else // here is loop for even numbers
            {
                for (int j = 0; j < resultArr.Length; j++)
                {
                    resultArr[j] = (int)perElement;
                }
            }
            
            return resultArr;
        }
    }
}
