using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestCase("CarGarage")]
        [TestCase("TruckGarage")]
        public void ConstructorShouldSetValueToNameProperty(string nameOfGarage)
        {
            Garage garage = new Garage(nameOfGarage, 2);

            Assert.That(garage.Name, Is.EqualTo(nameOfGarage));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorWithInvalidNameShouldThrowException(string nameOfGarage)
        {
            Assert.Throws<ArgumentNullException>(
                () => new Garage(nameOfGarage, 2));
        }

        [TestCase(1)]
        [TestCase(20)]
        public void ConstructorShouldSetValueToMechanicsProperty(int mechanicsCount)
        {
            Garage garage = new Garage("CarGarage", mechanicsCount);

            Assert.That(garage.MechanicsAvailable, Is.EqualTo(mechanicsCount));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorWithInvalidMechanicsCountShouldThrowException(int mechanicsCount)
        {
            Assert.Throws<ArgumentException>(
                () => new Garage("CarGarage", mechanicsCount));
        }

        [Test]
        public void ConstructorShouldInitializeAnEmptyCollection()
        {
            Garage garage = new Garage("CarGarage", 2);

            Assert.That(garage.CarsInGarage, Is.EqualTo(0));
        }

        [Test]
        public void AddCarMethodShouldStoreTheCar()
        {
            Garage garage = new Garage("CarGarage", 2);
            garage.AddCar(new Car("BMW E60", 1));

            Assert.That(garage.CarsInGarage, Is.EqualTo(1));
        }

        [Test]
        public void AddCarMethodWithNoMechanicsAvailableShouldThrowException()
        {
            Garage garage = new Garage("CarGarage", 1);
            garage.AddCar(new Car("BMW E60", 1));

            Assert.Throws<InvalidOperationException>(
                () => garage.AddCar(new Car("Mercedes C280", 4)));
        }

        [Test]
        public void FixCarMethodShouldWork()
        {
            Garage garage = new Garage("CarGarage", 2);
            Car car = new Car("BMW E60", 1);

            garage.AddCar(car);
            garage.FixCar("BMW E60");

            Assert.That(car.NumberOfIssues, Is.EqualTo(0));
        }

        [Test]
        public void FixCarMethodWithInvalidCarShouldThrowException()
        {
            Garage garage = new Garage("CarGarage", 1);

            Assert.Throws<InvalidOperationException>(
                () => garage.FixCar("BMW E60"));
        }

        [Test]
        public void RemoveFixedCarMethodShouldRemoveAllFixedCars()
        {
            Garage garage = new Garage("CarGarage", 2);
            garage.AddCar(new Car("BMW E60", 1));
            garage.AddCar(new Car("Audi A6", 1));

            garage.FixCar("BMW E60");
            garage.FixCar("Audi A6");

            garage.RemoveFixedCar();
            Assert.That(garage.CarsInGarage, Is.EqualTo(0));
        }

        [Test]
        public void RemoveFixedCarMethodWithInvalidCarModelShouldThrowException()
        {
            Garage garage = new Garage("CarGarage", 2);

            Assert.Throws<InvalidOperationException>(
                () => garage.RemoveFixedCar());
        }

        [Test]
        public void ReportMethodShouldReturnCorrectInformation()
        {
            Garage garage = new Garage("CarGarage", 2);
            garage.AddCar(new Car("BMW E60", 1));
            garage.AddCar(new Car("Audi A6", 2));

            Assert.That(garage.Report(), Is.EqualTo("There are 2 which are not fixed: BMW E60, Audi A6."));
        }
    }
}