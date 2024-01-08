using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _21._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\docs_vs\file.txt";
            string outputpath = @"D:\docs_vs\output.txt";
            List<int> numbers = ReadNumbers(path);
            Console.Write("Исходный список чисел: ");
            Print(numbers);
            List<int> SetToZeroNumbers = SetToZero(numbers);
            using (StreamWriter writer = new StreamWriter(outputpath, false, Encoding.Default))
            {
                foreach (int number in SetToZeroNumbers)
                {
                    writer.WriteLine(number);
                }
            }
            Console.WriteLine();
            Console.Write("Измененный список: ");
            Print(SetToZeroNumbers);
            Console.ReadLine();
        }

        static List<int> ReadNumbers(string filename)
        {
            List<int> numbers = new List<int>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number)) numbers.Add(number);
                }
            }
            return numbers;
        }

        static List<int> SetToZero(List<int> numbers)
        {
            List<int> zeronumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number < 0)
                    zeronumbers.Add(0);
                else
                    zeronumbers.Add(number);
            }
            return zeronumbers;
        }

        static void Print(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
