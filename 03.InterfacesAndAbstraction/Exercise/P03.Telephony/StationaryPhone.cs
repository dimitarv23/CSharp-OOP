using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (number.Any(c => char.IsLetter(c)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
