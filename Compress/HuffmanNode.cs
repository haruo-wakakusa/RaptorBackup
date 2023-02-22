﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compress.HuffmanTree
{
    public abstract class HuffmanNode
    {
        private readonly UInt32 count;

        protected HuffmanNode(UInt32 count)
        {
            this.count = count;
        }

        public UInt32 Count { get { return count; } }

        public override abstract string ToString();
    }

    public class HuffmanBranch : HuffmanNode
    {
        private readonly HuffmanNode n0;
        private readonly HuffmanNode n1;

        public HuffmanBranch(HuffmanNode n0, HuffmanNode n1)
            : base(n0.Count + n1.Count)
        {
            this.n0 = n0;
            this.n1 = n1;
        }

        public HuffmanNode Node0 { get { return n0; } }
        public HuffmanNode Node1 { get { return n1; } }

        public override string ToString()
        {
            return "(" + n0.ToString() + ", " + n1.ToString() + ")";
        }
    }

    public class HuffmanLeaf : HuffmanNode
    {
        private readonly byte idx;
        public HuffmanLeaf(byte index, uint count) : base(count)
        {
            this.idx = index;
        }

        public byte Index { get { return idx; } }

        public override string ToString()
        {
            return "[" + this.idx.ToString() + ", " + this.Count.ToString() + "]";
        }
    }
}
