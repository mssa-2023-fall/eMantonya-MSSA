using MSSAExtension;
using static MSSAExtension.MssaExtensions;

namespace MssaExtensionTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetSHAStringExtension()
        {
            var _file = new FileInfo(@"C:\\mssa-repos\\eMantonya-MSSA\\DSA\\MSSAExtension\\oscar_age_male.csv"); //this is a FileInfo object
            Assert.AreEqual("rSSHX5rkP6Y4BrmT3rYYmGmqInc=", _file.GetSHAString(StringFormat.Base64)); //it has access to the method we created from the sealed FileInfo Class
            Assert.AreEqual("ad24875f9ae43fa63806b993deb6189869aa2277", _file.GetSHAString(StringFormat.Hex));
        }
        [TestMethod]
        public void CustomLinqMethods()
        {
            IEnumerable<int> inputs = new[] { 1, 2, 3, 4, 5, 6, 7 };
            
            float median = inputs.Median(); //median will be implemented as extension method
            Assert.AreEqual(4, median);
        }
        [TestMethod]
        public void CustomLinqMethods2()
        {
            IEnumerable<double> inputs = new[] { 1, 2.5, 3.9, 4.7, 5.2, 6.7, 7.5, 8.9 };
            var median = inputs.Median();
            Assert.AreEqual(5.2, median);
        }
        [TestMethod]
        public void CustomLinqMethods3()
        {
            IEnumerable<float> inputs = new[] { 1f, 2.5f, 3.9f, 4.7f, 5.2f, 6.7f, 7.5f, 8.9f };
            var median = inputs.Median();
            Assert.AreEqual(5.2f, median);
        }
        [TestMethod]
        public void CustomLinqMethods4()
        {
            IEnumerable<decimal> inputs = new[] { 1m, 2.5m, 3.9m, 4.7m, 5.2m, 6.7m, 7.5m, 8.9m };
            var median = inputs.Median();
            Assert.AreEqual(5.2m, median);
        }
        [TestMethod]
        public void TestDictionaryIndexer()
        {
            var dict = new Dictionary<FileInfo, Stream>();
            var _file = new FileInfo(@"C:\\mssa-repos\\eMantonya-MSSA\\DSA\\MSSAExtension\\oscar_age_male.csv");
            dict.Add(_file, _file.OpenRead());
            Assert.IsTrue(dict[_file].Length == _file.Length);
        }
    }
}
