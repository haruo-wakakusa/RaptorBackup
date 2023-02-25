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
        public void HuffmanNode_GetHashCode_Test()
        {
            Assert.AreEqual(8, (new HuffmanLeaf(7, 8)).GetHashCode());
            var b = new HuffmanBranch(new HuffmanLeaf(1, 2), new HuffmanLeaf(8, 15));
            Assert.AreEqual(17, b.GetHashCode());
        }

        [TestMethod]
        public void HuffmanNode_Equals_Test()
        {
            Assert.AreEqual(new HuffmanLeaf(1, 2), new HuffmanLeaf(1, 2));
            Assert.AreNotEqual(new HuffmanLeaf(1, 2), new HuffmanLeaf(2, 2));
            var a = new HuffmanBranch(new HuffmanLeaf(1, 2), new HuffmanLeaf(3, 4));
            var b = new HuffmanBranch(new HuffmanLeaf(1, 2), new HuffmanLeaf(3, 4));
            var c = new HuffmanBranch(new HuffmanLeaf(3, 4), new HuffmanLeaf(1, 2));
            Assert.AreEqual(a, b);
            Assert.AreNotEqual(a, c);
        }

        [TestMethod]
        public void HuffmanTreeBuilder_Initalization_Test1()
        {
            var n1 = new HuffmanLeaf(31, 1);
            var n2 = new HuffmanLeaf(22, 2);
            var n3 = new HuffmanLeaf(13, 3);
            {
                var b = new HuffmanTreeBuilder(new HuffmanLeaf[] { n1, n2, n3 });
                Assert.AreEqual(n1, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n3, b.nodes[2]);
            }
            {
                var b = new HuffmanTreeBuilder(new HuffmanLeaf[] { n3, n2, n1 });
                Assert.AreEqual(n1, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n3, b.nodes[2]);
            }
            {
                var b = new HuffmanTreeBuilder(new HuffmanLeaf[] { n2, n3, n1 });
                Assert.AreEqual(n1, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n3, b.nodes[2]);
            }
        }

        [TestMethod]
        public void HuffmanTreeBuilder_Initalization_Test2()
        {
            var n1 = new HuffmanLeaf(31, 2);
            var n2 = new HuffmanLeaf(22, 2);
            var n3 = new HuffmanLeaf(13, 2);
            {
                var b = new HuffmanTreeBuilder(new HuffmanLeaf[] { n1, n2, n3 });
                Assert.AreEqual(n3, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n1, b.nodes[2]);
            }
            {
                var b = new HuffmanTreeBuilder(new HuffmanLeaf[] { n3, n2, n1 });
                Assert.AreEqual(n3, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n1, b.nodes[2]);
            }
            {
                var b = new HuffmanTreeBuilder(new HuffmanLeaf[] { n2, n3, n1 });
                Assert.AreEqual(n3, b.nodes[0]);
                Assert.AreEqual(n2, b.nodes[1]);
                Assert.AreEqual(n1, b.nodes[2]);
            }
        }

        [TestMethod]
        public void HuffmanTreeBuilder_Increment_Test1()
        {
            var n1 = new HuffmanLeaf(31, 1);
            var n2 = new HuffmanLeaf(22, 2);
            var n3 = new HuffmanLeaf(13, 3);
            var b = new HuffmanTreeBuilder(new HuffmanLeaf[] { n1, n2, n3 });
            Assert.AreEqual(0, b.idx);
            Assert.AreEqual(n1, b.nodes[0]);
            Assert.AreEqual(n2, b.nodes[1]);
            Assert.AreEqual(n3, b.nodes[2]);
            Assert.IsTrue(b.Increment());
            Assert.AreEqual(1, b.idx);
            Assert.AreEqual(n1, b.nodes[0]);
            Assert.AreEqual(new HuffmanBranch(n1, n2), b.nodes[1]);
            Assert.AreEqual(n3, b.nodes[2]);
            Assert.IsTrue(b.Increment());
            Assert.AreEqual(2, b.idx);
            Assert.AreEqual(n1, b.nodes[0]);
            Assert.AreEqual(new HuffmanBranch(n1, n2), b.nodes[1]);
            Assert.AreEqual(new HuffmanBranch(new HuffmanBranch(n1, n2), n3), b.nodes[2]);
            Assert.IsFalse(b.Increment());
            Assert.AreEqual(2, b.idx);
        }

        /*
        [TestMethod]
        public void HuffmanTreeBuilder_Increment_Test2()
        {
            var n1 = new HuffmanLeaf(31, 2);
            var n2 = new HuffmanLeaf(22, 2);
            var n3 = new HuffmanLeaf(13, 2);
            var b = new HuffmanTreeBuilder(new HuffmanNode[] { n1, n2, n3 });
            Assert.AreEqual(0, b.idx);
            Assert.AreEqual(n1, b.nodes[0]);
            Assert.AreEqual(n2, b.nodes[1]);
            Assert.AreEqual(n3, b.nodes[2]);
            //Assert.IsTrue(b.Increment());
            //Assert.AreEqual(1, b.idx);
            //Assert.AreEqual(n1, b.nodes[0]);
            //Assert.AreEqual(new HuffmanBranch(n1, n2), b.nodes[1]);
            //Assert.AreEqual(n3, b.nodes[2]);
            //Assert.IsTrue(b.Increment());
            //Assert.AreEqual(2, b.idx);
            //Assert.AreEqual(n1, b.nodes[0]);
            //Assert.AreEqual(new HuffmanBranch(n1, n2), b.nodes[1]);
            //Assert.AreEqual(new HuffmanBranch(new HuffmanBranch(n1, n2), n3), b.nodes[2]);
            //Assert.IsFalse(b.Increment());
            //Assert.AreEqual(2, b.idx);
        }
        */
    }
}
