
namespace LearnImmutableTest
{

    [TestClass]
    public class SampleRecordTest
    {
        [TestMethod]
        public void TestRecordTypeEqualityWithPositionParameters()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }

        [TestMethod]
        public void TestRecordTypeInEqualityWithPositionParameters()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeSamenessWithPositionParameters()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = record1;

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);
        }
    }
}
