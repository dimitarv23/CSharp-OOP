using Logger.Enums;
using Logger.Messages.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Messages
{
    public class Message : IMessage
    {
        private string date;
        private string messageText;

        public Message(string date, string message, ReportLevel reportLevel)
        {
            this.Date = date;
            this.MessageText = message;
            this.Level = reportLevel;
        }

        public string Date
        {
            get { return date; }
            private set
            {
                if (!IsDateValid(value))
                {
                    throw new InvalidDateException();
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(Date), "Date cannot be empty!");
                }

                date = value;
            }
        }

        public ReportLevel Level { get; }

        public string MessageText
        {
            get { return messageText; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(MessageText), "Message cannot be empty!");
                }

                messageText = value;
            }
        }

        private bool IsDateValid(string dateToCheck)
            => DateTime.TryParse(dateToCheck, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out DateTime dateTime);
    }
}
