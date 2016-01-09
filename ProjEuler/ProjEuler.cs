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
    }
}
