namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldInitializeTheList()
        {
            Arena arena = new Arena();

            Assert.That(0, Is.EqualTo(arena.Warriors.Count), "Constructor does not initialize the warriors list.");
        }

        [Test]
        public void EnrollMethodShouldAddWarriorToTheList()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Ivan", 20, 100));

            Assert.That(1, Is.EqualTo(arena.Count), "Enroll method does not add the warrior to the list.");
        }

        [Test]
        public void EnrollMethodWithRepeatingWarriorNameShouldThrowException()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Ivan", 20, 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Ivan", 30, 200));
            }, "Enroll method does not throw an exception when a warrior with repeated name is given.");
        }

        [Test]
        public void FightMethodWithValidData_WarriorShouldAttackAnotherWarrior()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Ivan", 20, 100);
            Warrior defender = new Warrior("Stamat", 15, 75);

            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight("Ivan", "Stamat");

            Assert.That(85, Is.EqualTo(attacker.HP));
            Assert.That(55, Is.EqualTo(defender.HP));
        }

        [Test]
        public void FightMethodWithAnInvalidWarrorShouldThrowException()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Ivan", 20, 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Ivan", "Stamat");

            }, "Fighting with warrior that is not enrolled in a fight does not throw an exception.");
        }
    }
}
