using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;

        public Captain(string fullName)
        {
            this.FullName = fullName;

            this.CombatExperience = 0;
            this.Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidCaptainName));
                }

                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidVesselForCaptain));
            }

            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            foreach (var vessel in this.Vessels)
            {
                sb.AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
