using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Compress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = new HuffmanTable(4);
            Debug.Assert(t.Size == 4);
            Debug.Assert(t.GetCount(0) == 0);
        }
    }

    /*
    internal class HuffmanTree
    {
        public UInt32 count = 0;

        public static HuffmanTree Create(HuffmanTable table)
        {
            List<HuffmanTree> list = new List<HuffmanTree>();
            for (UInt32 i = 0; i < HuffmanTable.Size; i++)
            {
                if (table.d[i] != 0) {
                    list.Add(new HuffmanLeaf((Byte)i, table.d[i]));
                }
            }

            foreach (HuffmanTree t in list) {
                Console.WriteLine(t.ToString());
            }

            list.Sort((a, b) => (Int32)(a.count - b.count));

            foreach (HuffmanTree t in list)
            {
                Console.WriteLine(t.ToString());
            }

            return null; // TBD
        }
    }

    internal class HuffmanBranch : HuffmanTree
    {
        public HuffmanTree b0 = null;
        public HuffmanTree b1 = null;
        
        public override string ToString()
        {
            return "(" + b0.ToString() + ", " + b1.ToString() + ")";
        }
    }

    internal class HuffmanLeaf : HuffmanTree
    {
        public Byte d;

        public HuffmanLeaf(Byte d, UInt32 c)
        {
            this.d = d;
            this.count = c;
        }

        public override string ToString()
        {
            return "[" + this.d.ToString() + ", " + this.count.ToString() + "]";
        }
    }
    */
}
