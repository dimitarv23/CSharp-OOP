namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ConstructorWithValidDataShouldWork()
        {
            Car car = new Car("BMW", "E60", 8, 70);

            Assert.That(car.Make, Is.EqualTo("BMW"), "Giving valid car make does not work.");
            Assert.That(car.Model, Is.EqualTo("E60"), "Giving valid car model does not work.");
            Assert.That(car.FuelConsumption, Is.EqualTo(8), "Giving valid fuel consumption does not work.");
            Assert.That(car.FuelCapacity, Is.EqualTo(70), "Giving valid fuel capacity does not work.");
            Assert.That(car.FuelAmount, Is.EqualTo(0), "Fuel amount does not go to 0, the private constructor does not work properly.");
        }

        [Test]
        public void ConstructorWithInvalidMakeShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "E60", 8, 70);
            }, "Giving empty car make does not throw an exception.");
        }

        [Test]
        public void ConstructorWithInvalidModelShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "", 8, 70);
            }, "Giving empty car model does not throw an exception.");
        }

        [Test]
        public void ConstructorWithInvalidFuelConsumptionShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "E60", 0, 70);
            }, "Giving 0 fuel consumption does not throw an exception.");
        }

        [Test]
        public void ConstructorWithInvalidFuelCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "E60", 8, 0);
            }, "Giving 0 fuel capacity does not throw an exception.");
        }

        [Test]
        public void RefuelWithValidFuelAmountShouldWork()
        {
            Car car = new Car("BMW", "E60", 8, 70);
            car.Refuel(20);

            Assert.That(20, Is.EqualTo(car.FuelAmount), "Refueling with valid fuel amount does not work properly.");
        }

        [Test]
        public void RefuelingWithALotOfFuelShouldNotExceedTheFuelCapacity()
        {
            Car car = new Car("BMW", "E60", 8, 70);
            car.Refuel(100);

            Assert.That(70, Is.EqualTo(car.FuelAmount), "Refueling with a lot of fuel amount exceeds the fuel capacity.");
        }

        [Test]
        public void RefuelingWithInvalidFuelAmountShouldThrowException()
        {
            Car car = new Car("BMW", "E60", 8, 70);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            }, "Refueling with invalid fuel amount does not throw an exception.");
        }

        [Test]
        public void DrivingCarShouldDecreaseFuelAmount()
        {
            Car car = new Car("BMW", "E60", 8, 70);

            car.Refuel(20);
            car.Drive(150);

            //Driving 150km with fuel consumption of 8 uses (150/100)*8 = 1.5*8 = 12 liters
            Assert.That(8, Is.EqualTo(car.FuelAmount), "Driving car does not decrease fuel amount properly.");
        }

        [Test]
        public void DrivingWithInsufficientFuelAmountShouldThrowException()
        {
            Car car = new Car("BMW", "E60", 8, 70);

            car.Refuel(10);

            //Driving 150km with fuel consumption of 8 uses (150/100)*8 = 1.5*8 = 12 liters
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(150);
            }, "Driving a distance with insufficient fuel amount does not throw an exception.");
        }
    }
}