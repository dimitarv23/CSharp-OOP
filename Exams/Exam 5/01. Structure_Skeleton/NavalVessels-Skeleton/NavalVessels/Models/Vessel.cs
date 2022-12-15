using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;

            this.Targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }

                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; private protected set; }

        public double Speed { get; private protected set; }

        public ICollection<string> Targets { get; private set; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            if (this.MainWeaponCaliber >= target.ArmorThickness)
            {
                target.ArmorThickness = 0;
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }

            this.Targets.Add(target.Name);
        }

        public virtual void RepairVessel()
        {
            if (this is Submarine)
            {
                this.ArmorThickness = 200;
            }
            else if (this is Battleship)
            {
                this.ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");

            if (this.Targets != null && this.Targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {string.Join(", ", this.Targets)}");
            }
            else
            {
                sb.AppendLine($" *Targets: None");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
