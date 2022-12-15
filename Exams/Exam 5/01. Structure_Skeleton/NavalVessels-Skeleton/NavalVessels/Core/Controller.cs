using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(x => x.FullName == selectedCaptainName))
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (vessel == default)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vessels.FindByName(attackingVesselName);

            if (attacker == default)
            {
                return string.Format(OutputMessages.CaptainNotFound, attackingVesselName);
            }

            IVessel defender = vessels.FindByName(defendingVesselName);

            if (defender == default)
            {
                return string.Format(OutputMessages.CaptainNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attacker.Attack(defender);

            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel,
                defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            if (!captains.Any(x => x.FullName == captainFullName))
            {
                return string.Format(OutputMessages.CaptainNotFound, captainFullName);
            }

            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(x => x.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            ICaptain captain = new Captain(fullName);
            captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != default)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType != nameof(Battleship) &&
                vesselType != nameof(Submarine))
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }

            IVessel vessel;

            if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }

            vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == default)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == default)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == nameof(Battleship))
            {
                Battleship battleship = vessel as Battleship;
                battleship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            Submarine submarine = vessel as Submarine;
            submarine.ToggleSubmergeMode();
            return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == default)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            return vessel.ToString();
        }
    }
}
