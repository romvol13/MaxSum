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
        public void IsFileEmpty()
        {
            // arrange
            string file = "Test1.txt";
            string[] lines = File.ReadAllLines(file);

            //act
            MaxSumCalc test1 = new MaxSumCalc(file);
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
            int actualResult = test2.GetMaxSumLine();

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
            test3.GetMaxSumLine();
            int[] actualResult = test3.BrokenLinesArrayClone();

            // assert
            CollectionAssert.AreEqual(_brokenLines, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AllLinesBroken()
        {
            // arrange
            string file = "Test3.txt";

            //act
            MaxSumCalc test4 = new MaxSumCalc(file);
        }
    }
}