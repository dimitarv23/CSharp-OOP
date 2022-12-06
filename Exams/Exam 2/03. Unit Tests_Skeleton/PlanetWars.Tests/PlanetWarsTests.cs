using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    [TestFixture]
    public class PlanetWarsTests
    {
        [Test]
        public void ConstructorShouldSetValueToName()
        {
            Planet planet = new Planet("Earth", 200);

            Assert.That(planet.Name, Is.EqualTo("Earth"));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWithInvalidName()
        {
            Assert.Throws<ArgumentException>(
                () => new Planet("", 200));
        }

        [Test]
        public void ConstructorShouldSetValueToBudget()
        {
            Planet planet = new Planet("Earth", 200);

            Assert.That(planet.Budget, Is.EqualTo(200));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWithInvalidBudget()
        {
            Assert.Throws<ArgumentException>(
                () => new Planet("Earth", -1));
        }

        [Test]
        public void ConstructorShouldInitializeWeaponsList()
        {
            Planet planet = new Planet("Earth", 200);

            Assert.That(planet.Weapons, Is.Not.Null);
            Assert.That(planet.Weapons.Count, Is.EqualTo(0));
        }

        [Test]
        public void MilitaryRatioShouldBeCalculatedProperly()
        {
            Planet planet = new Planet("Earth", 200);
            planet.AddWeapon(new Weapon("Hammer", 20, 6));

            Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(6));
        }

        [Test]
        public void ProfitMethodShouldIncreaseBudget()
        {
            Planet planet = new Planet("Earth", 60);
            planet.Profit(10);

            Assert.That(planet.Budget, Is.EqualTo(70));
        }

        [Test]
        public void RemoveWeaponMethodShouldRemoveWeapon()
        {
            Planet planet = new Planet("Earth", 200);
            planet.AddWeapon(new Weapon("Hammer", 20, 6));
            planet.RemoveWeapon("Hammer");

            Assert.That(planet.Weapons.Count, Is.EqualTo(0));
        }

        [Test]
        public void SpendMethodShouldDecreaseBudget()
        {
            Planet planet = new Planet("Earth", 60);

            planet.SpendFunds(10);

            Assert.That(planet.Budget, Is.EqualTo(50));
        }

        [Test]
        public void SpendMethodWithInvalidAmountShouldThrowException()
        {
            Planet planet = new Planet("Earth", 60);

            Assert.Throws<InvalidOperationException>(
                () => planet.SpendFunds(61));
        }

        [Test]
        public void AddWeaponMethodShouldStoreIt()
        {
            Planet planet = new Planet("Earth", 60);
            planet.AddWeapon(new Weapon("Hammer", 20, 5));

            Assert.That(planet.Weapons.Count, Is.EqualTo(1));
        }

        [Test]
        public void RepeatingWeaponShouldThrowException()
        {
            Planet planet = new Planet("Earth", 60);
            planet.AddWeapon(new Weapon("Hammer", 20, 5));

            Assert.Throws<InvalidOperationException>(
                () => planet.AddWeapon(new Weapon("Hammer", 10, 4)));
        }

        [Test]
        public void UpgradeWeaponMethodShouldIncreaseItsDestructionLevel()
        {
            Planet planet = new Planet("Earth", 60);
            planet.AddWeapon(new Weapon("Hammer", 20, 5));
            planet.UpgradeWeapon("Hammer");

            Assert.That(planet.Weapons.FirstOrDefault(x => x.Name == "Hammer").DestructionLevel, Is.EqualTo(6));
        }

        [Test]
        public void UnexistingWeaponForUpgradeShouldThrowException()
        {
            Planet planet = new Planet("Earth", 60);

            Assert.Throws<InvalidOperationException>(
                () => planet.UpgradeWeapon("Hammer"));
        }

        [Test]
        public void DestructOponentShouldWorkWithValidOponent()
        {
            Planet planet = new Planet("Earth", 60);
            planet.AddWeapon(new Weapon("Hammer", 20, 5));

            Planet oponent = new Planet("Mars", 30);

            Assert.That(planet.DestructOpponent(oponent), Is.EqualTo("Mars is destructed!"));
        }

        [Test]
        public void DestructOponentShouldThrowExceptionWithStrongerOponent()
        {
            Planet planet = new Planet("Earth", 60);

            Planet oponent = new Planet("Mars", 30);
            oponent.AddWeapon(new Weapon("Hammer", 20, 5));

            Assert.Throws<InvalidOperationException>(() =>
                planet.DestructOpponent(oponent));
        }

        [Test]
        public void ConstructorShouldSetPrice()
        {
            Weapon weapon = new Weapon("Hammer", 20, 5);

            Assert.That(weapon.Price, Is.EqualTo(20));
        }

        [Test]
        public void ConstructorShouldThrowExceptionOnInvalidPrice()
        {
            Assert.Throws<ArgumentException>(
                () => new Weapon("Hammer", -1, 5));
        }

        [Test]
        public void ConstructorShouldSetDestructionLevel()
        {
            Weapon weapon = new Weapon("Hammer", 20, 5);

            Assert.That(weapon.DestructionLevel, Is.EqualTo(5));
        }

        [Test]
        public void IncreaseDestructionLevelShouldWork()
        {
            Weapon weapon = new Weapon("Hammer", 20, 5);
            weapon.IncreaseDestructionLevel();

            Assert.That(weapon.DestructionLevel, Is.EqualTo(6));
        }

        [Test]
        public void IsNuclearShouldBeCalculatedProperly()
        {
            Weapon weapon = new Weapon("Hammer", 20, 11);

            Assert.That(weapon.IsNuclear, Is.EqualTo(true));
        }
    }
}
