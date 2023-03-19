using System.Reflection.PortableExecutable;

namespace MaximalSum
{
    internal class Program
    {
        public static FileInfo file;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file: ");
            Console.WriteLine("Example: C:\\Users\\volko\\OneDrive\\Desktop\\.NET Mentoring\\3. Maximal sum\\MaximalSum\\data.txt");
            string dataFile = Console.ReadLine();
            
            file = new FileInfo(dataFile);

            if (CheckExistence() == false)
            {
                throw new ArgumentException("File path is not valid");
            } 
            else if (CheckIfEmpty() == true) 
            {
                throw new ArgumentException("File is empty");
            }
            else
            {
                MaxSumCalc calc = new MaxSumCalc(dataFile);
                Console.WriteLine($"Line with maximum sum of numbers is: {calc.MaxSumLineIdentification()}");
                Console.Write("Broken lines: ");
                calc.OutputBrokenLines();
            }
        }

        private static bool CheckExistence()
        {
            if (!file.Exists)
            {
                return false;
            }
            return true;
        }

        private static bool CheckIfEmpty()
        {
            if (file.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}