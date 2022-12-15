using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [TestCase("Real Madrid")]
        [TestCase("Liverpool")]
        public void ConstructorShouldSetValueToName(string name)
        {
            FootballTeam footballTeam = new FootballTeam(name, 25);

            Assert.That(footballTeam.Name, Is.EqualTo(name));
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorWithInvalidNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(name, 25));
        }

        [TestCase(15)]
        [TestCase(25)]
        public void ConstructorShouldSetValueToCapacity(int capacity)
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", capacity);

            Assert.That(footballTeam.Capacity, Is.EqualTo(capacity));
        }

        [TestCase(14)]
        [TestCase(-1)]
        public void ConstructorWithInvalidCapacityShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Liverpool", capacity));
        }

        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 20);

            Assert.That(footballTeam.Players, Is.Not.Null);
            Assert.That(footballTeam.Players.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddPlayerMethodShouldStoreHimInTheCollection()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 20);
            FootballPlayer player = new FootballPlayer("Virgil Van Dijk", 4, "Midfielder");

            footballTeam.AddNewPlayer(player);

            Assert.That(footballTeam.Players.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddPlayerMethodWithFullCapacityShouldNotAddHimToTheCollection()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 15);

            for (int i = 0; i < 15; i++)
            {
                FootballPlayer player = new FootballPlayer($"Player {i}", i + 1, "Midfielder");
                footballTeam.AddNewPlayer(player);
            }

            footballTeam.AddNewPlayer(new FootballPlayer("Firmino", 9, "Forward"));
            Assert.That(footballTeam.Players.Count, Is.EqualTo(15));

            Assert.That(footballTeam.AddNewPlayer(new FootballPlayer("Firmino", 9, "Forward")),
                Is.EqualTo("No more positions available!"));
        }

        [Test]
        public void AddPlayerMethodWithNullPlayerShouldThrowNullReference()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 15);
            FootballPlayer player = null;

            Assert.Throws<NullReferenceException>(() => footballTeam.AddNewPlayer(player));
        }

        [Test]
        public void PickPlayerMethodShouldReturnAPlayer()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 20);
            FootballPlayer player = new FootballPlayer("Virgil Van Dijk", 4, "Midfielder");

            footballTeam.AddNewPlayer(player);

            Assert.That(footballTeam.PickPlayer("Virgil Van Dijk"), Is.EqualTo(player));
        }

        [Test]
        public void PickPlayerMethodWithInvalidNameShouldReturnNull()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 20);

            Assert.That(footballTeam.PickPlayer("Mo Salah"), Is.EqualTo(null));
        }

        [Test]
        public void PlayerScoreMethodShouldReturnPlayerInfo()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 20);
            FootballPlayer player = new FootballPlayer("Virgil Van Dijk", 4, "Midfielder");

            footballTeam.AddNewPlayer(player);
            footballTeam.PlayerScore(4);

            Assert.That(player.ScoredGoals, Is.EqualTo(1));
            Assert.That(footballTeam.PlayerScore(4),
                Is.EqualTo("Virgil Van Dijk scored and now has 2 for this season!"));
        }

        [Test]
        public void PlayerScoreMethodWithInvalidNumber()
        {
            FootballTeam footballTeam = new FootballTeam("Liverpool", 20);

            Assert.Throws<NullReferenceException>(() => footballTeam.PlayerScore(4));
        }
    }
}