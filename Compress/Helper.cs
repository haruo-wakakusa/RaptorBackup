using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr
{
    public class Helper
    {
        public static bool IsNotTheSameType(Object a, Object b)
        {
            if (b == null) return true;
            if (a.GetType() != b.GetType()) return true;
            return false;
        }
    }
}
