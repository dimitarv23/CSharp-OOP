using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.FormulaOneCar;
using Formula1.Models.Pilot;
using Formula1.Models.Race;
using Formula1.Repositories.Entities;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot == default || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (car == default)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == default)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (pilot == default || !pilot.CanRace || race.Pilots.Any(x => x.FullName == pilot.FullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type != nameof(Ferrari)
                && type != nameof(Williams))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar car;

            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }

            carRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models
                .OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(r => r.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == default)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> racers = pilotRepository.Models
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .ToList();

            IPilot winner = racers.First();
            IPilot second = racers[1];
            IPilot third = racers[2];

            race.TookPlace = true;
            winner.WinRace();

            var sb = new StringBuilder();
            sb.AppendLine($"Pilot {winner.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {second.FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {third.FullName} is third in the {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
