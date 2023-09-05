
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
        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties()
        {
            //Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //Assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);

        }
        [TestMethod]
        public void RecordPropertiesAreMutable()
        {
            //Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5)) { MutableProp = "not tested" };

            //Act
            record1.MutableProp = "tested";

            //Assert
            Assert.AreEqual("tested", record1.MutableProp);
        }
        [TestMethod]
        public void TestRecordTypeHaveDestructMethodWithoutParam()
        {
            //Arrange
            SampleRecord record1 = new SampleRecord(ParamString: "test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5)) { MutableProp = "test" };

            string outString = String.Empty;
            int outInt = 1;
            DateTime outDateTime = new DateTime();

            //Act
            record1.Deconstruct(out outString, out outInt, out outDateTime);

            //Assert
            Assert.AreEqual(outString, "test");
            Assert.AreEqual(outInt, 1);
            Assert.AreEqual(outDateTime, new DateTime(2023, 9, 5));
        }
    }
}
