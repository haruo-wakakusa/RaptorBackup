using Compress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compress.HuffmanTree
{
    public class HuffmanTreeBuilder
    {
        public readonly HuffmanNode[] nodes;
        public uint idx = 0;

        public HuffmanTreeBuilder(HuffmanNode[] nodes)
        {
            this.nodes = (HuffmanNode[])nodes.Clone();
            Array.Sort(this.nodes, (a, b) => { return (int)(a.Count - b.Count); });
        }

        public bool Increment()
        {
            if (this.idx >= this.nodes.Length)
            {
                throw new NotImplementedException();
            }

            if (this.idx + 1 == this.nodes.Length)
            {
                return false;
            }

            var b = new HuffmanBranch(this.nodes[this.idx], this.nodes[this.idx + 1]);
            this.idx += 1;
            this.nodes[this.idx] = b;
            var i = idx;
            while (i + 1 < this.nodes.Length && this.nodes[i].Count > this.nodes[i + 1].Count)
            {
                var tmp = this.nodes[i];
                this.nodes[i] = this.nodes[i + 1];
                this.nodes[i + 1] = tmp;
                i += 1;
            }
            return true;
        }
    }
}
