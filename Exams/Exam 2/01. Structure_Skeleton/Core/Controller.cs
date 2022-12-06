using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits.Entities;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Planets.Entities;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons.Entities;
using PlanetWars.Repositories.Entities;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit)
                && unitTypeName != nameof(SpaceForces)
                && unitTypeName != nameof(StormTroopers))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unitToAdd;

            if (unitTypeName == nameof(SpaceForces))
            {
                unitToAdd = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unitToAdd = new StormTroopers();
            }
            else
            {
                unitToAdd = new AnonymousImpactUnit();
            }

            planet.Spend(unitToAdd.Cost);
            planet.AddUnit(unitToAdd);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon)
                && weaponTypeName != nameof(NuclearWeapon)
                && weaponTypeName != nameof(SpaceMissiles))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weaponToAdd;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weaponToAdd = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weaponToAdd = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weaponToAdd = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weaponToAdd.Price);
            planet.AddWeapon(weaponToAdd);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != default)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models
                .OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            IPlanet winner;
            IPlanet loser;

            if (firstPlanet.MilitaryPower != secondPlanet.MilitaryPower)
            {
                if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }
            else
            {
                var firstNuclearWeapon = firstPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == nameof(NuclearWeapon));
                var secondNuclearWeapon = secondPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == nameof(NuclearWeapon));

                if ((firstNuclearWeapon != null && secondNuclearWeapon != null) ||
                    (firstNuclearWeapon == null && secondNuclearWeapon == null))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return string.Format(OutputMessages.NoWinner);
                }

                if (firstNuclearWeapon != null && secondNuclearWeapon == null)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }

            double profitOfWinner = loser.Weapons.Sum(x => x.Price)
                + loser.Army.Sum(x => x.Cost);

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(profitOfWinner);
            planets.RemoveItem(loser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == default)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.TrainArmy();
            planet.Spend(1.25);
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
