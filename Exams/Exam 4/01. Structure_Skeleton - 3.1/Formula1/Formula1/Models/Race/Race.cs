using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Race
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;

            Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }

        public ICollection<IPilot> Pilots { get; private set; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.AppendLine($"Took place: {(TookPlace ? "Yes" : "No")}");

            return sb.ToString().TrimEnd();
        }
    }
}
