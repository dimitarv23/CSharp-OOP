namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorWithValidDateShouldWork()
        {
            Warrior warrior = new Warrior("Ivan", 20, 100);

            Assert.That("Ivan", Is.EqualTo(warrior.Name), "Constructor does not set warrior name properly.");
            Assert.That(20, Is.EqualTo(warrior.Damage), "Constructor does not set warrior damage properly.");
            Assert.That(100, Is.EqualTo(warrior.HP), "Constructor does not set warrior HP properly.");
        }

        [Test]
        public void ConstructorWithInvalidNameShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("", 20, 100);

            }, "When given an invalid name, an exception is not thrown.");
        }

        [Test]
        public void ConstructorWithInvalidDamageShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivan", 0, 100);

            }, "When given an invalid damage, an exception is not thrown.");
        }

        [Test]
        public void ConstructorWithInvalidHPShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivan", 20, -1);

            }, "When given an invalid HP, an exception is not thrown.");
        }

        [Test]
        public void AttackingWithoutDying()
        {
            Warrior attacker = new Warrior("Ivan", 20, 100);
            Warrior defender = new Warrior("Stamat", 25, 100);

            attacker.Attack(defender);

            Assert.That(80, Is.EqualTo(defender.HP), "Attacking the defender does not reduce his HP properly.");
            Assert.That(75, Is.EqualTo(attacker.HP), "Attacking the attacker does not reduce his HP properly.");
        }

        [Test]
        public void AttackingTheDefenderWithMoreDamageThanHisHP()
        {
            Warrior attacker = new Warrior("Ivan", 50, 100);
            Warrior defender = new Warrior("Stamat", 15, 40);

            attacker.Attack(defender);

            Assert.That(0, Is.EqualTo(defender.HP), "When the defender dies his HP does not turn to 0.");
        }

        [Test]
        public void AttackingTheAttackerWithMoreDamageThanHisHPShouldThrowException()
        {
            Warrior attacker = new Warrior("Ivan", 20, 40);
            Warrior defender = new Warrior("Stamat", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "The attacker attacks a defender with a damage more than his own HP and an exception is not thrown.");
        }

        [Test]
        public void AttackingDefenderWithLessThanTheMinimumAllowedHPShouldThrowException()
        {
            Warrior attacker = new Warrior("Ivan", 20, 100);
            Warrior defender = new Warrior("Stamat", 20, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "The attacker attacks a defender with HP <= minimum allowed HP, and it does not throw an exception.");
        }

        [Test]
        public void AttackingWithLessThanTheMinimumAllowedHPShouldThrowException()
        {
            Warrior attacker = new Warrior("Ivan", 20, 30);
            Warrior defender = new Warrior("Stamat", 20, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "The attacker attacks with HP <= minimum allowed HP, and it does not throw an exception.");
        }
    }
}