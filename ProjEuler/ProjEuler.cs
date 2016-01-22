using System;
using System.Collections.Generic;
using System.IO;
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

        private static readonly string _problem008String = @"
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

        public static long Problem010(int limit)
        {
            var primes = Util.Eratosthenes(limit);
            long sum = 0;
            foreach (var prime in primes)
            {
                sum += prime;
            }
            return sum;
        }

        private static readonly string _problem011String = @"
            08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
            49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
            81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
            52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
            22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
            24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
            32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
            67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
            24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
            21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
            78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
            16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
            86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
            19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
            04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
            88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
            04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
            20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
            20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
            01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

        public static long Problem011(int adjacent)
        {
            const int limit = 20;
            int[,] grid = new int[limit, limit];
            { // read numbers into a typed grid
                var lines = new StringReader(_problem011String.Trim());
                string line;
                int row = 0, column = 0;
                char[] number = new char[2];
                while ((line = lines.ReadLine()) != null)
                {
                    var numbers = new StringReader(line.Trim());

                    while (numbers.Read(number, 0, 2) == 2)
                    {
                        grid[row, column] = int.Parse(new string(number));
                        ++column;
                        numbers.Read();
                    }
                    ++row;
                    column = 0;
                }
            }
            long greatestProduct = 1;
            long product;
            for (int i = 0; i < limit; ++i)
            {
                for(int j = 0; j < limit; ++j)
                {
                    if (j + adjacent <= limit)
                    { // left, right direction
                        product = 1;
                        for (int k = 0; k < adjacent; ++k)
                            product *= grid[i, j + k];
                        if (product > greatestProduct)
                            greatestProduct = product;
                    }
                    if (i + adjacent <= limit)
                    { // up, down direction
                        product = 1;
                        for (int k = 0; k < adjacent; ++k)
                            product *= grid[i + k, j];
                        if (product > greatestProduct)
                            greatestProduct = product;
                    }
                    if (i + adjacent <= limit && j + adjacent <= limit)
                    { // diagonally from the left
                        product = 1;
                        for (int k = 0; k < adjacent; ++k)
                            product *= grid[i + k, j + k];
                        if (product > greatestProduct)
                            greatestProduct = product;
                    }
                }
                for (int j = adjacent - 1; j < limit; ++j)
                {
                    if (i + adjacent <= limit)
                    { // diagonally from the right
                        product = 1;
                        for (int k = 0; k < adjacent; ++k)
                            product *= grid[i + k, j - k];
                        if (product > greatestProduct)
                            greatestProduct = product;
                    }
                }
            }

            return greatestProduct;
        }
    }
}
