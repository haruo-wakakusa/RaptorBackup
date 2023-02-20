using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Compress
{
    public class HuffmanTable
    {
        private readonly int size;
        private readonly int[] d;

        public HuffmanTable(int size)
        {
            Debug.Assert(size > 0 && size <= 256);
            this.size = size;

            this.d = new int[this.size];
            for (int i = 0; i < this.size; ++i)
            {
                this.d[i] = 0;
            }
        }

        public int Size
        {
            get { return this.size; }
        }

        public void Add(byte b)
        {
            ++this.d[b];
            if (this.d[b] < 0)
            {
                throw new OverflowException();
            }
        }

        public int GetCount(byte b)
        {
            return this.d[b];
        }
    }
}