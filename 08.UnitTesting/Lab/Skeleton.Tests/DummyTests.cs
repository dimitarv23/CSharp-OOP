using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(100, 10);

            dummy.TakeAttack(20);

            Assert.That(80, Is.EqualTo(dummy.Health), "Dummy does not lose health when attacked.");
        }

        [Test]
        public void AttackOnDeadDummyShouldThrowException()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Catch(() =>
            {
                dummy.TakeAttack(1);
            }, "Attacking a dead dummy does not throw an exception.");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.That(10, Is.EqualTo(dummy.GiveExperience()), "Dead dummies do not give experience.");
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            Dummy dummy = new Dummy(100, 10);

            Assert.Catch(() =>
            {
                dummy.GiveExperience();
            }, "Alive dummies give experience.");
        }
    }
}