using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr
{
    public class Helper
    {
        public delegate bool StrictEqualityFunction<T>(T a, T b);
        public delegate bool ExtendedEqualityFunction<T>(Object a, Object b);
        
        public ExtendedEqualityFunction<T> EqlFn<T>(StrictEqualityFunction<T> fn)
        {
            return (a, b) =>
            {
                if (a == null)
                {
                    return b == null;
                }
                else if (!(a is T))
                {
                    throw new NotImplementedException();
                }
                else if (!(b is T))
                {
                    return false;
                }
                else
                {
                    return fn((T)a, (T)b);
                }
            };
        }
    }
}
