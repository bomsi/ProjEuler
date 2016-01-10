using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEuler
{
    class Util
    {
        /// <summary>
        /// Return a list of prime numbers
        /// </summary>
        /// <param name="limit">Largest number to test</param>
        /// <param name="smallest">Smallest prime to include in the list</param>
        /// <returns>A list of prime numbers</returns>
        public static List<int> Eratosthenes(int limit, int smallest = 2)
        {
            bool[] mark = new bool[limit + 1];
            int tmp;
            for (int p = 2; p < limit; ++p)
            {
                if (mark[p] == true)
                    continue;
                for (int i = 1; ; )
                {
                    tmp = (++i) * p;
                    if (tmp > limit)
                        break;
                    mark[tmp] = true;
                }
            }
            var result = new List<int>();
            for (int i = 2; i < limit; ++i)
            {
                if (mark[i] == false && i >= smallest)
                    result.Add(i);
            }
            return result;
        }

        /// <summary>
        /// Reverses a string
        /// </summary>
        /// <param name="str">String to reverse</param>
        /// <returns>The reversed string</returns>
        public static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
