using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    internal class InvalidDateException : Exception
    {
        private const string defaultMessage = "The date you entered is invalid!";

        public InvalidDateException() : base(defaultMessage)
        {

        }
    }
}
