using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCoverageSample
{
    public class Divider
    {
        public int Divide(int x, int y)
        {
            if (y != 0)
            {
                return x/ y;
            }

            return 0;
        }
    }
}
