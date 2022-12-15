using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double initialArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            base.RepairVessel();
        }

        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;

            if (this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {(this.SubmergeMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
