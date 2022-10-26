using System;

namespace P01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var n = uint.Parse(Console.ReadLine());

                var result = Math.Sqrt(n);

                Console.WriteLine(result);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
