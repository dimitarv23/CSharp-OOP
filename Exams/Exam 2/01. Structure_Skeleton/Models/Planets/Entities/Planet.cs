using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits.Entities;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons.Entities;
using PlanetWars.Repositories.Entities;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets.Entities
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;

        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                }

                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                }

                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(CalculateMilitaryPower(), 3);

        private double CalculateMilitaryPower()
        {
            double sumOfUnitEndurances = units.Models.Sum(x => x.EnduranceLevel);
            double sumOfWeaponDestructions = weapons.Models.Sum(x => x.DestructionLevel);

            double total = sumOfUnitEndurances + sumOfWeaponDestructions;

            if (units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                total *= 1.3;
            }

            if (weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                total *= 1.45;
            }

            return total;
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            List<string> unitNames = new List<string>();
            foreach (var unit in units.Models)
            {
                unitNames.Add(unit.GetType().Name);
            }

            sb.AppendLine($"--Forces: {(units.Models.Count > 0 ? string.Join(", ", unitNames) : "No units")}");

            List<string> weaponNames = new List<string>();
            foreach (var weapon in weapons.Models)
            {
                weaponNames.Add(weapon.GetType().Name);
            }

            sb.AppendLine($"--Combat equipment: {(weapons.Models.Count > 0 ? string.Join(", ", weaponNames) : "No weapons")}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
