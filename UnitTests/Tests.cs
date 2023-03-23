using MaximalSum;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfFileEmpty()
        {
            // arrange
            string file = "Test1.txt";
            string[] lines = File.ReadAllLines(file);

            //act
            MaxSumCalc test1 = new MaxSumCalc(file);

            // assert
            bool actualResult = test1.IsFileEmpty();
        }

        [TestMethod]
        public void MaxCalculation() 
        {
            // arrange
            string file = "Test2.txt";
            string[] lines = File.ReadAllLines(file);
            int expectedResult = 10;

            //act
            MaxSumCalc test2 = new MaxSumCalc(file);
            int actualResult = test2.MaxSumLineIdentification();

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void BrokenLines()
        {
            // arrange   
            string file = "Test2.txt";

            string[] lines = File.ReadAllLines(file);
            int[] _brokenLines = { 2, 4, 7, 8, 9 };

            //act
            MaxSumCalc test3 = new MaxSumCalc(file);
            test3.MaxSumLineIdentification();
            int[] actualResult = test3.BrokenLinesArrayClone();

            // assert
            CollectionAssert.AreEqual(_brokenLines, actualResult);
        }
    }
}