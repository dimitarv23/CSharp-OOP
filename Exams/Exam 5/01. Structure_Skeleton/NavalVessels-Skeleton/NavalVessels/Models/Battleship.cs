using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double initialArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            base.RepairVessel();
        }

        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;

            if (this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {(this.SonarMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
