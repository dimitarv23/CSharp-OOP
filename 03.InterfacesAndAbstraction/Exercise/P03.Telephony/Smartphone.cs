using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (number.Any(c => char.IsLetter(c)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }
    }
}
