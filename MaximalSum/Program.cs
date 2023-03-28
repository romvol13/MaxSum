using System.Reflection.PortableExecutable;
using System.IO;


namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataFile;
            if (args.Length == 0)
            {
                Console.WriteLine("Enter path to file: ");
                Console.WriteLine("Example: C:\\Users\\volko\\OneDrive\\Desktop\\.NET Mentoring\\3. Maximal sum\\MaximalSum\\data.txt");
                dataFile = Console.ReadLine();
            } 
            else
            {
                dataFile = args[0];
            }

            FileInfo file = new FileInfo(dataFile);

            if (!file.Exists)
            {
                throw new ArgumentException("File path is not valid!");
            } 
            else
            {
                MaxSumCalc calc = new MaxSumCalc(dataFile);
                Console.WriteLine($"Line with maximum sum of numbers is: {calc.GetMaxSumLine()}");
                Console.Write("Broken lines: ");
                calc.OutputBrokenLines();
            }
        }
    }
}