using System;
using System.Numerics;

namespace P04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(' ');

            BigInteger sum = 0;

            foreach (var element in elements)
            {
                try
                {
                    int currNum = int.Parse(element); //Can throw a format exception or overflow exception

                    sum += currNum;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
