using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    public class MaxSumCalc
    {
        private string[] _data;
        private List<int> _brokenLines = new List<int>();
        private double _maxSum = double.MinValue;
        private int _lineNumber = 0;

        public MaxSumCalc(string dataFile)
        {
            _data = File.ReadAllLines(dataFile);

            if (IsFileEmpty() == true)
            {
                throw new ArgumentException("File is empty");
            }

            BrokenLineIdentification();
        }

        public int MaxSumLineIdentification()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                string[] numbers = _data[i].Split(',');
                double sum = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    double number;
                    if (double.TryParse(numbers[j], out number))
                    {
                        sum += number;
                    }
                }

                if (sum > _maxSum)
                {
                    _maxSum = sum;
                    _lineNumber = i+1;    //adding one to line number, because normally we start counting from 1, not from 0
                }
            }
            return _lineNumber;
        }

        public void OutputBrokenLines()
        {
            foreach (int line in _brokenLines)
            {
                Console.Write(line + " ");
            }
        }

        public bool IsFileEmpty()
        {
            if (_data.Length == 0 )
            {
                return true;
            }
            return false;
        }

        public int[] BrokenLinesArrayClone()   //method for unit test only
        {
            int[] clonedArray = _brokenLines.ToArray();
            return clonedArray;
        }

        private void BrokenLineIdentification()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                string[] numbers = _data[i].Split(',');

                for (int j = 0; j < numbers.Length; j++)
                {
                    double number;
                    if (!double.TryParse(numbers[j], out number))
                    {
                        _brokenLines.Add(i + 1);  //adding one to line number, because normally we start counting from 1, not from 0
                        break;
                    }
                }
            }
        }
    }
}
