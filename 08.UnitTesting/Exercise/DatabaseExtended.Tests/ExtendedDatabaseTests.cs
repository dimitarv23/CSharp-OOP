namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void ConstructorWithValidDataShouldWork()
        {
            Database db = new Database(new Person(1, "ivan"));

            Assert.That(1, Is.EqualTo(db.Count), "Constructor with valid data does not work.");
        }

        [Test]
        public void ConstructorWithNoDataShouldWork()
        {
            Database db = new Database();

            Assert.That(0, Is.EqualTo(db.Count), "Constructor with no given data does not work.");
        }

        [Test]
        public void ConstructorWithMoreThan16PeopleShouldThrowException()
        {
            Person[] people = new Person[17];

            Assert.Catch(() =>
            {
                Database db = new Database(people);
            }, "Constructor with given more than 16 people does not throw an exception.");
        }

        [Test]
        public void AddMethodWithValidDataShouldStoreThePerson()
        {
            Database db = new Database(new Person(1, "ivan"), new Person(2, "pesho"));

            db.Add(new Person(3, "stamat"));

            Assert.That(3, Is.EqualTo(db.Count), "Add method with valid person does not add it to the collection.");
        }

        [Test]
        public void AddMethodWithRepeatingIDsShouldThrowException()
        {
            Database db = new Database(new Person(1, "ivan"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(1, "stamat"));
            }, "Add method with a given person with existing id does not throw an exception.");
        }

        [Test]
        public void AddMethodWithRepeatingUsernamesShouldThrowException()
        {
            Database db = new Database(new Person(1, "ivan"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(2, "ivan"));
            }, "Add method with a given person with existing username does not throw an exception.");
        }

        [Test]
        public void Adding17thElementShouldThrowException()
        {
            Person[] people = new Person[16];

            for (int i = 1; i <= 16; i++)
            {
                people[i - 1] = new Person(i, $"ivan {i}");
            }

            Database db = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(17, "georgi"));
            }, "Adding 17th element to the collection does not throw an exception.");
        }

        [Test]
        public void RemovedMethodShouldRemovePerson()
        {
            Database db = new Database(new Person(1, "ivan"), new Person(2, "georgi"));

            db.Remove();

            Assert.That(1, Is.EqualTo(db.Count), "Remove method does not remove a person from the collection.");
        }

        [Test]
        public void RemoveMethodOnEmptyDatabaseShouldThrowException()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "Remove method called on an empty database does not throw an exception.");
        }

        [Test]
        public void FindByUsernameShouldWorkWithValidUsername()
        {
            Person person = new Person(1, "ivan");
            Database db = new Database(person);

            Assert.That(person, Is.EqualTo(db.FindByUsername("ivan")), "FindByUsername method does not work with a valid username given.");
        }

        [Test]
        public void FindByUsernameWithInvalidUsernameShouldThrowException()
        {
            Person person = new Person(1, "ivan");
            Database db = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("pesho");
            }, "FindByUsername method with an invalid username does not throw an exception.");
        }

        [Test]
        public void FindByUsernameWithEmptyUsernameShouldThrowException()
        {
            Person person = new Person(1, "ivan");
            Database db = new Database(person);

            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername("");
            }, "FindByUsername method with an empty username does not throw an exception.");
        }

        [Test]
        public void FindByIDShouldWorkWithValidID()
        {
            Person person = new Person(1, "ivan");
            Database db = new Database(person);

            Assert.That(person, Is.EqualTo(db.FindById(1)), "FindById method does not work with a valid id given.");
        }

        [Test]
        public void FindByIDWithInvalidIDShouldThrowException()
        {
            Person person = new Person(1, "ivan");
            Database db = new Database(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(2);
            }, "FindById method with an invalid id does not throw an exception.");
        }

        [Test]
        public void FindByIDWithNegativeIDShouldThrowException()
        {
            Database db = new Database();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-1);
            }, "FindById method with a negative id does not throw an exception.");
        }
    }
}