using System;
using System.Collections.Generic;

namespace P02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(10);
            int start = 1;

            while (numbers.Count < 10)
            {
                int numberRead = ReadNumber(start, 100);

                if (numberRead != -1)
                {
                    numbers.Add(numberRead);
                    start = numberRead;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
        static int ReadNumber(int start, int end)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n <= start || n >= end)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return n;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
                return -1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Your number is not in range {start} - 100!");
                return -1;
            }
        }
    }

}
