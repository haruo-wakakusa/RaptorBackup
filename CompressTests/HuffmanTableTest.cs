using Compress;

namespace CompressTests
{
    [TestClass]
    public class HuffmanTableTest
    {
        [TestMethod]
        public void InitializationTest()
        {
            {
                var t = new HuffmanTable(4);
                Assert.AreEqual(4, t.Size);
                Assert.AreEqual(0, t.GetCount(0));
                Assert.AreEqual(0, t.GetCount(1));
                Assert.AreEqual(0, t.GetCount(2));
                Assert.AreEqual(0, t.GetCount(3));
            }
            {
                var t = new HuffmanTable(256);
                Assert.AreEqual(256, t.Size);
                Assert.AreEqual(0, t.GetCount(0));
                Assert.AreEqual(0, t.GetCount(7));
                Assert.AreEqual(0, t.GetCount(255));
            }
        }

        [TestMethod]
        public void CountTest1()
        {
            var t = new HuffmanTable(256);
            t.Add(1);
            t.Add(2);
            t.Add(3);
            t.Add(2);
            t.Add(1);
            Assert.AreEqual(0, t.GetCount(0));
            Assert.AreEqual(2, t.GetCount(1));
            Assert.AreEqual(2, t.GetCount(2));
            Assert.AreEqual(1, t.GetCount(3));
            for (int i = 4; i < 256; i++)
            {
                Assert.AreEqual(0, t.GetCount((byte)i));
            }
        }
    }
}