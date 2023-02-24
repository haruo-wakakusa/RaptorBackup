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

        [TestMethod]
        public void HuffmanTreeBuilder_Initialization_Test()
        {
            var n1 = new HuffmanLeaf(31, 1);
            var n2 = new HuffmanLeaf(22, 2);
            var n3 = new HuffmanLeaf(13, 3);
            {
                var b = new HuffmanTreeBuilder(new HuffmanNode[] { n1, n2, n3 });
                Assert.AreEqual(n1, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n3, b.nodes[2]);
            }
            {
                var b = new HuffmanTreeBuilder(new HuffmanNode[] { n3, n2, n1 });
                Assert.AreEqual(n1, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n3, b.nodes[2]);
            }
            {
                var b = new HuffmanTreeBuilder(new HuffmanNode[] { n2, n3, n1 });
                Assert.AreEqual(n1, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n3, b.nodes[2]);
            }
        }



        [TestMethod]
        public void HuffmanTreeBuilder_Increment_Test1()
        {
            var n1 = new HuffmanLeaf(1, 1);
            var n2 = new HuffmanLeaf(2, 2);
            var n3 = new HuffmanLeaf(3, 3);
        }
    }
}
