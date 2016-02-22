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
        /// Returns a list of prime numbers
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

        /// <summary>
        /// Returns a list of prime factors for the given number
        /// </summary>
        /// <typeparam name="T">Integral type</typeparam>
        /// <param name="number">Number to factor</param>
        /// <param name="primes">List of primes to use</param>
        /// <returns>List of prime factors</returns>
        public static List<T>PrimeFactors<T>(T number, List<T> primes) where T: struct, IComparable, IComparable<T>, IEquatable<T>, IConvertible
        {
            T divisor;
            var primeFactors = new List<T>();
            for (int p = 0; p < primes.Count; )
            {
                divisor = primes[p];
                if ((dynamic)number % (dynamic)divisor == 0)
                {
                    number = (dynamic)number / (dynamic)divisor;
                    primeFactors.Add(divisor);
                }
                else
                    ++p;
            }
            return primeFactors;
        }

        /// <summary>
        /// Returns a set of factors for the fiven number
        /// </summary>
        /// <typeparam name="T">Integral type</typeparam>
        /// <param name="number">Number to factor</param>
        /// <param name="primes">List of primes to use</param>
        /// <returns>Set of factors</returns>
        public static HashSet<T> Factors<T>(T number, List<T> primes) where T: struct, IComparable, IComparable<T>, IEquatable<T>, IConvertible
        {
            var powerSetOfPrimeFactors = PowerSet(PrimeFactors(number, primes).Select((x, y) => new { x, y }).ToList());
            var factors = new HashSet<T>();
            foreach (var p in powerSetOfPrimeFactors)
            {
                var factor = p.Select(x => x.x).Aggregate((T)Convert.ChangeType(1, typeof(T)), (x, y) => (dynamic)x * y);
                factors.Add(factor);
            }
            return factors;
        }

        /// <summary>
        /// Creates a power set from the given list
        /// </summary>
        /// <typeparam name="T">Integral type</typeparam>
        /// <param name="list">List of integers</param>
        /// <returns>A power set of the given set</returns>
        public static IEnumerable<IEnumerable<T>> PowerSet<T>(List<T> list)
        {
            // source: http://rosettacode.org/wiki/Power_Set
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select from i in Enumerable.Range(0, list.Count)
                          where (m & (1 << i)) != 0
                          select list[i];
        }
    }
}
