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
        public int idx = 0;

        public HuffmanTreeBuilder(HuffmanLeaf[] nodes1)
        {
            HuffmanLeaf[] nodes2 = (HuffmanLeaf[])nodes1.Clone();
            Array.Sort(nodes2, (a, b) => { 
                int a_b = (int)(a.Count - b.Count);
                if (a_b != 0)
                {
                    return a_b;
                }
                else
                {
                    return a.Index - b.Index;
                }
            });
            this.nodes = (HuffmanNode[])nodes2; // 配列の共変性を利用
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
