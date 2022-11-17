namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Transactions;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0, 100, -100, 4, 291, -10000 })]
        [TestCase(new int[] { int.MinValue, int.MaxValue })]
        public void ConstructorWithValidDataShouldWork(int[] parameters)
        {
            Database db = new Database(parameters);

            Assert.That(parameters.Length, Is.EqualTo(db.Count), "Constructor with valid data does not work.");
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 3, 4 })]
        [TestCase(new int[0], new int[] { 3, 4 })]
        [TestCase(new int[] { 1, 2 }, new int[] { int.MinValue, int.MaxValue, 0 })]
        [TestCase(new int[0], new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodWithValidDataShouldWork(int[] ctorParameters, int[] parameters)
        {
            Database db = new Database(ctorParameters);

            for (int i = 0; i < parameters.Length; i++)
            {
                db.Add(parameters[i]);
            }

            int expectedLength = ctorParameters.Length + parameters.Length;

            Assert.That(expectedLength, Is.EqualTo(db.Count), "The add method does not work with valid data.");
        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowException()
        {
            Database db = new Database(new int[16]);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(1);
            }, "Adding 17 elements does not throw an exception.");
        }

        [Test]
        public void RemovingAnElementShouldWork()
        {
            Database db = new Database(new int[3] { 1, 2, 3 });
            db.Remove();

            Assert.That(2, Is.EqualTo(db.Count));
        }

        [Test]
        public void RemovingElementFromEmptyDatabaseShouldThrowException()
        {
            Database db = new Database(new int[0]);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "Removing an element from empty collection does not throw an exception.");
        }

        [Test]
        public void FetchMethodShouldReturnArrayOfIntegers()
        {
            Database db = new Database(new int[3] { 1, 2, 3 });

            Assert.IsInstanceOf<int[]>(db.Fetch());
        }

        [Test]
        public void FetchMethodShouldReturnAllElementsInTheDatabase()
        {
            Database db = new Database(new int[3] { 1, 2, 3 });

            Assert.That(3, Is.EqualTo(db.Fetch().Length));
        }
    }
}
