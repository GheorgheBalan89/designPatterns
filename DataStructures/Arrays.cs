using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class Arrays
    {
        static int hourglassSum(int[][] arr)
        {
           var sums = new List<int>();

            int key = 0;
            foreach (var row in arr)
            {
                if (key <= 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        var hourglass = new List<int>
                        {
                            row[i],
                            row[i + 1],
                            row[i + 2],
                            arr[key + 1][i + 1],
                            arr[key + 2][i],
                            arr[key + 2][i + 1],
                            arr[key + 2][i + 2]
                        };
                        sums.Add(hourglass.Sum());
                    }

                }
                
                key++;
            }

            return sums.Max();
        }

        static void Main(string[] args)
        {
          
            int[][] arr = new int[6][];
            string sampleInput =
                @"1 1 1 0 0 0
0 1 0 0 0 0
1 1 1 0 0 0
0 0 2 4 4 0
0 0 0 2 0 0
0 0 1 2 4 0";

        
            arr[0] = Array.ConvertAll("1 1 1 0 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[1] = Array.ConvertAll("0 1 0 0 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[2] = Array.ConvertAll("1 1 1 0 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[3] = Array.ConvertAll("0 0 2 4 4 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[4] = Array.ConvertAll("0 0 0 2 0 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            arr[5] = Array.ConvertAll("0 0 1 2 4 0".Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            int result = hourglassSum(arr);

            Console.WriteLine(result);
        }
    }
}
