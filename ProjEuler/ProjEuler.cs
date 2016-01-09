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


    }
}
