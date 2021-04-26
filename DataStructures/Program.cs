using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    class Solution
    {

        // Complete the sockMerchant function below.
        static int sockMerchant(int n, int[] ar)
        {

            var distinctColors = ar.ToList().Distinct();

            var pairs = new List<int>();

            foreach (var dist in distinctColors)
            {
                var pairX = ar.Count(x => x == dist);

                if (pairX % 2 == 0 )
                {
                    var modEven = pairX / 2;
                    for (var i =0; i < modEven; i++)
                    {
                        pairs.Add(dist);
                    }
                }

                if (pairX %2 != 0  && (pairX % 3 == 0 || pairX % 5 == 0 || pairX % 7 == 0 || pairX % 9== 0))
                {
                    var modOdd = (pairX - 1) / 2;
                    for (var i = 0; i < modOdd; i++)
                    {
                        pairs.Add(dist);
                    }
                }

            }
            Console.WriteLine(pairs.Count);
            return pairs.Count();

        }

        private static void AddOddNums(int pairX, List<int> pairs, int dist)
        {
          
        }

        //static void Main(string[] args)
        //{
        //    int n = 20;
        //    int[] ar = new[] { 4, 5, 5, 5, 6, 6, 4, 1, 4, 4, 3, 6, 6, 3, 6, 1, 4, 5, 5, 5 };

        //    int result = sockMerchant(n, ar);

        //    Console.WriteLine(result);

        //}
    }

}
