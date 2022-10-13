using System;

namespace P03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] websiteUrls = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ICallable callable = null;

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        callable = new StationaryPhone();
                        Console.WriteLine(callable.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        callable = new Smartphone();
                        Console.WriteLine(callable.Call(number));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            IBrowsable browsable = new Smartphone();

            foreach (var url in websiteUrls)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(url));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
