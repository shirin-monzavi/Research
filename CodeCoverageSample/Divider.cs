using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCoverageSample
{
    public class Divider
    {
        [ExcludeFromCodeCoverage]
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
