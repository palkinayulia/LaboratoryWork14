using ClassLibrary10Lab;
using Лабораторная_работа_14;


namespace Test14Lab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1",list1);
            dic1.Add("store2", list2);
            var res = Program.WhereLINQ(dic1);
            Assert.AreEqual(1, res.Count);
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            var res = Program.WhereExtencion(dic1);
            Assert.AreEqual(1, res.Count);
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            List<Watch> list3 = new List<Watch>();
            Watch watch3 = new Watch("Casioo", 2020, 1);
            list3.Add(watch3);
            List<Watch> list4 = new List<Watch>();
            Watch watch4 = new Watch("Seikoo", 1820, 1);
            list4.Add(watch4);
            Dictionary<string, List<Watch>> dic2 = new Dictionary<string, List<Watch>>();
            dic2.Add("store3", list3);
            dic2.Add("store4", list4);
            var res = Program.UnionExtencion(dic1, dic2);
            Assert.AreEqual(4, res.Count);
        }
        [TestMethod]
        public void TestMethod4()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            List<Watch> list3 = new List<Watch>();
            Watch watch3 = new Watch("Casio", 2000, 1);
            list3.Add(watch1);
            List<Watch> list4 = new List<Watch>();
            Watch watch4 = new Watch("Seiko", 1800, 1);
            list4.Add(watch2);
            Dictionary<string, List<Watch>> dic2 = new Dictionary<string, List<Watch>>();
            dic2.Add("store3", list3);
            dic2.Add("store4", list4);
            var res = Program.UnionLINQ(dic1, dic2);
            Assert.AreEqual(4, res.Count);
        }
        [TestMethod]
        public void TestMethod5()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            var res = Program.MaxExtencion(dic1);
            Assert.AreEqual(2000, res);
        }
        [TestMethod]
        public void TestMethod6()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            var res = Program.MaxLINQ(dic1);
            Assert.AreEqual(2000, res);
        }
        [TestMethod]
        public void TestMethod7()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            var res = Program.MinExtencion(dic1);
            Assert.AreEqual(1800, res);
        }
        [TestMethod]
        public void TestMethod8()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            var res = Program.MinLINQ(dic1);
            Assert.AreEqual(1800, res);
        }
        [TestMethod]
        public void TestMethod9()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            var res = Program.GroupLINQ(dic1).ToList();
            Assert.AreEqual(2, res.Count);
        }
        [TestMethod]
        public void TestMethod10()
        {
            List<Watch> list1 = new List<Watch>();
            Watch watch1 = new Watch("Casio", 2000, 1);
            list1.Add(watch1);
            List<Watch> list2 = new List<Watch>();
            Watch watch2 = new Watch("Seiko", 1800, 1);
            list2.Add(watch2);
            Dictionary<string, List<Watch>> dic1 = new Dictionary<string, List<Watch>>();
            dic1.Add("store1", list1);
            dic1.Add("store2", list2);
            var res = Program.GroupExtencion(dic1).ToList();
            Assert.AreEqual(2, res.Count);
        }
    }
}