using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;

namespace Formula1.Models.Pilot
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private bool canRace = false;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCarForPilot));
                }

                car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
