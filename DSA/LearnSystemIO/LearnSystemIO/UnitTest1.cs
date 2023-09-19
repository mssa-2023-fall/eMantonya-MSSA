using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using CsvHelper;
using CsvHelper.Configuration;
using Parquet.Serialization;

namespace LearnSystemIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TryStreamReadMethod()
        {
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = i;
            }
            //arrange: create a 100 loop to build memory stream 0x01, 0x02, 0x03, ...
            Stream s = new MemoryStream(byteArr);
            //act: read first 5 bytes by using Stream.Read method
            byte[] bufferToPopulate = new byte[5]; //creates 5 byte array as the destination to store bytes read
            int bytesRead = s.Read(bufferToPopulate, 0, 5);//call stream.read to read the first 5 bytes ** it will advance the pointer from 0 to 5
            //Assert : stream.read signature (byte[] bufferToPopulate, int starting Position, int numberOfBytes)
            Assert.AreEqual(bufferToPopulate[0],0x00);
            Assert.AreEqual(bufferToPopulate[1],0x01);
            Assert.AreEqual(bufferToPopulate[2],0x02);
            Assert.AreEqual(bufferToPopulate[3],0x03);
            Assert.AreEqual(bufferToPopulate[4],0x04);
            Assert.AreEqual(bytesRead, 5);
        }
        [TestMethod]
        public void ConfirmStreamReadReturnValueIsBoundByTheNumberOfBytesActuallyRead()
        {
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = i;
            }
            //arrange: create a 100 loop to build memory stream 0x01, 0x02, 0x03, ...
            Stream s = new MemoryStream(byteArr);
            //act: read first 5 bytes by using Stream.Read method
            byte[] bufferToPopulate = new byte[120]; //creates 5 byte array as the destination to store bytes read
            int bytesRead = s.Read(bufferToPopulate, 0, 120);//call stream.read to read the first 5 bytes ** it will advance the pointer from 0 to 5
            //Assert : stream.read signature (byte[] bufferToPopulate, int starting Position, int numberOfBytes)
            Assert.AreEqual(bufferToPopulate[0], 0x00);
            Assert.AreEqual(bufferToPopulate[1], 0x01);
            Assert.AreEqual(bufferToPopulate[2], 0x02);
            Assert.AreEqual(bufferToPopulate[3], 0x03);
            Assert.AreEqual(bufferToPopulate[4], 0x04);
            Assert.AreEqual(bytesRead, 100);
        }
        [TestMethod]
        public void CreateANewMemoryStreamFromBytes()
        {
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = i;
            }
            Stream s = new MemoryStream();
            //Act: write to Stream s using data in byteArr

            s.Write(byteArr, 0, 100);
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanRead);
            Assert.IsTrue(s.CanSeek);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(100, s.Position);
            s.Position = 0;
            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
        }
        [TestMethod]
        public void CreateANewFileStreamFromBytes()
        {
            byte[] byteArr = new byte[100];
            for (byte i = 0; i < 100; i++)
            {
                byteArr[i] = i;
            }
            Stream s = new FileStream("out.bin", FileMode.OpenOrCreate);
            //Act: write to Stream s using data in byteArr

            s.Write(byteArr, 0, 100);
            Assert.IsTrue(s.CanWrite);
            Assert.IsTrue(s.CanRead);
            Assert.IsTrue(s.CanSeek);
            Assert.AreEqual(100, s.Length);
            Assert.AreEqual(100, s.Position);
            s.Position = 0;
            Assert.AreEqual(0, s.ReadByte());
            Assert.AreEqual(10, s.Seek(10, 0));
            Assert.AreEqual(10, s.ReadByte());
            s.Flush();
            s.Close();
        }
        [TestMethod]
        public void WritePrimitiveData()
        {
            //arrange: create a file stream to store data at binary.bin
            //2 construct BinaryWriter with above stream
            Stream s = new FileStream("primitive.bin", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(s);

            //act : write char, string, decimal, int32, int64, and write a double
            //dont fortet to flush and close the file
            char a = 'a';
            string b = "Hello World";
            decimal c = 12.3M;
            Int64 d = Int64.MaxValue;
            Int32 e = Int32.MaxValue;
            double f = double.MaxValue;
            bw.Write(a);
            bw.Write(b);
            bw.Write(c);
            bw.Write(d);
            bw.Write(e);
            bw.Write(f);
            bw.Flush();
            bw.Close();

            //Assert
            var file = new FileInfo("primitive.bin");
            Assert.AreEqual(49, file.Length);

            Stream s2 = new FileStream("primitive.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(s2);
            Assert.AreEqual(a, br.ReadChar());
            Assert.AreEqual(b, br.ReadString());
            Assert.AreEqual(c, br.ReadDecimal());
            Assert.AreEqual(d, br.ReadInt64());
            Assert.AreEqual(e, br.ReadInt32());
            Assert.AreEqual(f, br.ReadDouble());
            br.Close();
        }
        [TestMethod]
        public void CopyPic()
        {
            var source = new FileStream(@"C:\mssa-repos\eMantonya-MSSA\DSA\LearnSystemIO\a.jpg", FileMode.Open);
            var copy = new FileStream(@"C:\mssa-repos\eMantonya-MSSA\DSA\LearnSystemIO\aCopy.jpg", FileMode.OpenOrCreate);
            var br = new BinaryReader(source);
            var bw = new BinaryWriter(copy);
            bw.Write(br.ReadBytes((int)source.Length));

            
            Assert.AreEqual(source.Length, copy.Length);
            br.Close();
            bw.Close();
        }
        [TestMethod]
        public void TestParsingStringToWinnerInstance()
        {
            string input = @"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""";
            Winner w = new Winner(input);

            Assert.AreEqual(44, w.age);
            Assert.AreEqual("Emil Jannings", w.name);
            Assert.AreEqual(1982, w.year);
            Assert.AreEqual(1, w.index);
            Assert.AreEqual("The Last Command, The Way of All Flesh", w.movie);
        }
        [TestMethod]
        public void CreateListOfWinners()
        {
            List<Winner> winners = new List<Winner>();

            using (StreamReader sr = new StreamReader(@"C:\\mssa-repos\\eMantonya-MSSA\\DSA\\LearnSystemIO\oscar_age_male.csv"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0) break;
                    winners.Add(new Winner(line));
                }
            }
            Assert.AreEqual(89, winners.Count);
            Assert.AreEqual(76, winners.Max(w=>w.age));
            Assert.AreEqual(29, winners.Min(w=>w.age));
            var uberWin = 
            winners.GroupBy(winner => winner.name) //create a group based on Actors names
                .Select(g => new { Actor = g.Key, Count = g.Count() }) //return a new class with 2 properties: Actor and Count
                .Where(global => global.Count > 1) //only return the actors that have more then 1 entry
                .OrderByDescending(g => g.Count)
                .ToList();
            Assert.AreEqual(9, uberWin.Count);
            var sw = new StreamWriter(@"C:\\mssa-repos\\eMantonya-MSSA\\DSA\\LearnSystemIO\mostWins.csv");
            foreach (var item in uberWin)
            {
                sw.WriteLine($"{item.Actor, 20}{item.Count, 20}");
            }
            sw.Close();
        }
        [TestMethod]
        public void ParseCsvUsingHelperPackage()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                BadDataFound = null,
                Quote = '"',
                Delimiter= ", "
            };
            IEnumerable<Winner> records = new List<Winner>();
            Winner w;
            List<Winner> winners;
            using(var reader = new StreamReader(@"C:\\mssa-repos\\eMantonya-MSSA\\DSA\\LearnSystemIO\oscar_age_male.csv"))
            using(var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<Winner>();
                winners = records.ToList();
                w = winners[0];
            }

            Assert.AreEqual(44, w.age);
            Assert.AreEqual("Emil Jannings", w.name);
            Assert.AreEqual(1928, w.year);
            Assert.AreEqual(1, w.index);
            Assert.AreEqual("The Last Command, The Way of All Flesh", w.movie);
            ParquetSerializer.SerializeAsync(winners, @"C:\\mssa-repos\\eMantonya-MSSA\\DSA\\LearnSystemIO\winners.parquet").Wait();
        }
        [TestMethod]
        public void DeserializeParquet()
        {
            IList<Winner> winners = 
                ParquetSerializer.DeserializeAsync<Winner>(new FileStream(@"C:\\mssa-repos\\eMantonya-MSSA\\DSA\\LearnSystemIO\winners.parquet", FileMode.Open)).Result;
        }
    }
}
