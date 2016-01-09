using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEuler
{
    class Util
    {
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
    }
}
