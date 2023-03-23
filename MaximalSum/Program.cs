using System.Reflection.PortableExecutable;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file: ");
            Console.WriteLine("Example: C:\\Users\\volko\\OneDrive\\Desktop\\.NET Mentoring\\3. Maximal sum\\MaximalSum\\data.txt");
            string dataFile = Console.ReadLine();
            
            FileInfo file = new FileInfo(dataFile);

            if (!CheckExistence(file))
            {
                throw new ArgumentException("File path is not valid");
            } 
            else
            {
                MaxSumCalc calc = new MaxSumCalc(dataFile);
                Console.WriteLine($"Line with maximum sum of numbers is: {calc.MaxSumLineIdentification()}");
                Console.Write("Broken lines: ");
                calc.OutputBrokenLines();
            }
        }

        private static bool CheckExistence(FileInfo file)
        {
            if (!file.Exists)
            {
                return false;
            }
            return true;
        }
    }
}