using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compress.HuffmanTree;

namespace CompressTests
{
    [TestClass]
    public class HuffmanTreeTest
    {
        [TestMethod]
        public void HuffmanNode_ToString_Test()
        {
            {
                var n = new HuffmanLeaf(1, 5);
                Assert.AreEqual("[1, 5]", n.ToString());
            }
            {
                var n = new HuffmanBranch(new HuffmanLeaf(2, 1), new HuffmanLeaf(3, 4));
                Assert.AreEqual("([2, 1], [3, 4])", n.ToString());
            }

        }
    }
}
