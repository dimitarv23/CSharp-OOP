using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace P05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int caughtExceptions = 0;

            while (caughtExceptions < 3)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];

                try
                {
                    if (action == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);

                        numbers[index] = element;
                    }
                    else if (action == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        var output = new StringBuilder();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            if (i == endIndex)
                            {
                                output.Append(numbers[i]);
                                break;
                            }

                            output.Append(numbers[i] + ", ");
                        }

                        Console.WriteLine(output);
                    }
                    else if (action == "Show")
                    {
                        int index = int.Parse(command[1]);

                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    caughtExceptions++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    caughtExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
