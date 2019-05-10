using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHWLoadoutEdit
{
    public static class Utility
    {
        public static T[] Slice<T>(this T[] self, int start, int end)
        {
            return self.Skip(start).Take(end - start).ToArray();
        }
    }
}
