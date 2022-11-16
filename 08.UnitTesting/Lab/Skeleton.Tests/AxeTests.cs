using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    public class AxeTests
    {
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(100, 100);
        }

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            Axe axe = new Axe(20, 10);
            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe does not lose durability after an attack.");
        }

        [Test]
        public void AttackingWithBrokenAxeShouldThrowException()
        {
            Axe axe = new Axe(20, 0);

            Assert.Catch(() =>
            {
                axe.Attack(dummy);
            }, "Attacking with a broken axe does not throw an exception.");
        }
    }
}