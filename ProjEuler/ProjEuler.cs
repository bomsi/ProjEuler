using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEuler
{
    public class ProjEuler
    {
        public static int Problem001(int limit)
        {
            int sum = 0;
            for (int i = 1; i < limit; ++i)
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            return sum;
        }

        public static int Problem002(int limit)
        {
            // prepare fibonacci sequence
            const int estimatedSize = 40;
            var fibonacci = new int[estimatedSize];
            int i, j;
            fibonacci[0] = 1;
            fibonacci[1] = 2;
            for (i = 0, j = 2; j < estimatedSize; ++i, ++j)
            {
                fibonacci[j] = fibonacci[i] + fibonacci[i+1];
                if (fibonacci[j] > limit)
                    break;
            }
            if (j >= estimatedSize && fibonacci[estimatedSize - 1] < limit)
                throw new Exception("Wrong buffer estimate. Buffer to small.");
            // find sum of even elements
            int sum = 0;
            for (i = j - 1; i > 0; --i)
            {
                if (!((fibonacci[i] & 1) == 1))
                    sum += fibonacci[i];
            }
            return sum;
        }

        public static long Problem003(long number)
        {
            const int estimatedSize = 7000;
            var primes = Util.Eratosthenes(estimatedSize);
            var factors = new List<int>();
            foreach (var prime in primes)
            {
                while (number % prime == 0)
                {
                    number /= prime;
                    factors.Add(prime);
                }
            }
            if (number != 1)
                throw new Exception("Wrong buffer estimate. Buffer to small.");
            return factors[factors.Count - 1];
        }

        public static int Problem004(int digits)
        {
            // TODO: optimize this brute force approach
            int tmp;
            int largest = 0;
            int upperLimit = (int)Math.Pow(10, digits) - 1;
            int lowerLimit = (int)Math.Pow(10, digits - 1) - 1;
            for (int i = upperLimit; i > lowerLimit; --i)
            {
                for (int j = upperLimit; j > lowerLimit; --j)
                {
                    tmp = i * j;
                    if (Util.Reverse(tmp.ToString()) == tmp.ToString())
                    {
                        if (tmp > largest)
                            largest = tmp;
                    }
                }
            }
            return largest;
        }

        public static int Problem005(int from, int to)
        {
            // TODO: optimize this brute force approach
            if (from == 1)
                from = 2;
            Func<int, bool> condition = (number) =>
            {
                for (int i = from; i <= to; ++i)
                {
                    if (number % i != 0)
                        return false;
                }
                return true;
            };
            int result = 0;
            for (int i = to; ; ++i)
            {
                if (condition(i))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static int Problem006(int limit)
        {
            int sumSqr = 0;
            int sqrSum = 0;
            for (int i = 1; i <= limit; ++i)
            {
                sumSqr += i * i;
                sqrSum += i;
            }
            return (sqrSum * sqrSum) - sumSqr;
        }

        public static int Problem007(int primeIndex)
        {
            var primes = new List<int>();
            for (int estimate = primeIndex * 11; primes.Count < primeIndex; estimate *= 11)
            {
                primes = Util.Eratosthenes(estimate);
            }
            return primes[primeIndex - 1];
        }

        private static string _problem008String = @"
            73167176531330624919225119674426574742355349194934
            96983520312774506326239578318016984801869478851843
            85861560789112949495459501737958331952853208805511
            12540698747158523863050715693290963295227443043557
            66896648950445244523161731856403098711121722383113
            62229893423380308135336276614282806444486645238749
            30358907296290491560440772390713810515859307960866
            70172427121883998797908792274921901699720888093776
            65727333001053367881220235421809751254540594752243
            52584907711670556013604839586446706324415722155397
            53697817977846174064955149290862569321978468622482
            83972241375657056057490261407972968652414535100474
            82166370484403199890008895243450658541227588666881
            16427171479924442928230863465674813919123162824586
            17866458359124566529476545682848912883142607690042
            24219022671055626321111109370544217506941658960408
            07198403850962455444362981230987879927244284909188
            84580156166097919133875499200524063689912560717606
            05886116467109405077541002256983155200055935729725
            71636269561882670428252483600823257530420752963450";

        public static long Problem008(int adjacentDigits)
        {
            string number = _problem008String.Replace("\r\n", "").Replace(" ", "");
            long greatestProduct = 0;
            long product = 1;
            string tmp;
            for (int i = 0; i < number.Length - adjacentDigits; ++i, product = 1)
            {
                tmp = number.Substring(i, adjacentDigits);
                if (tmp.Contains("0"))
                    continue;
                for (int j = 0; j < tmp.Length; ++j)
                    product *= int.Parse(tmp.Substring(j, 1));
                if (product > greatestProduct)
                    greatestProduct = product;
            }
            return greatestProduct;
        }

        public static int Problem009()
        {
            // TODO: optimize this brute force approach
            const int estimated = 500;
            for (int i = 1; i < estimated; ++i)
                for (int j = i + 1; j < estimated; ++j)
                    for (int k = j + 1; k < estimated; ++k)
                        if (i + j + k == 1000)
                            if (((i * i) + (j * j)) == (k * k))
                                return i * j * k;
            return 0;
        }
    }
}
