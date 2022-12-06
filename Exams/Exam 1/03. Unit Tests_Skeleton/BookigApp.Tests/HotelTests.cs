using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWithValidDataShouldPass()
        {
            var hotel = new Hotel("Sunrise Resort", 5);

            Assert.That(hotel.FullName, Is.EqualTo("Sunrise Resort"));
            Assert.That(hotel.Category, Is.EqualTo(5));
            Assert.That(hotel.Rooms, Is.Not.EqualTo(null));
            Assert.That(hotel.Bookings, Is.Not.EqualTo(null));
        }

        [Test]
        public void ConstructorWithInvalidCategoryShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var hotel = new Hotel("Sunrise Resort", 6);
            });
        }

        [Test]
        public void ConstructorWithInvalidNameShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var hotel = new Hotel("", 4);
            });
        }

        [Test]
        public void AddRoomMethodWithValidRoomShouldPass()
        {
            var hotel = new Hotel("Sunrise Resort", 5);
            var roomToAdd = new Room(2, 99.99);

            hotel.AddRoom(roomToAdd);
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void BookRoomMethodWithInvalidAdultsCountShouldThrowException()
        {
            var hotel = new Hotel("Sunrise Resort", 5);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(0, 2, 2, 200);
            });
        }

        [Test]
        public void BookRoomMethodWithInvalidChildrenCountShouldThrowException()
        {
            var hotel = new Hotel("Sunrise Resort", 5);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, -1, 2, 200);
            });
        }

        [Test]
        public void BookRoomMethodWithInvalidDurationShouldThrowException()
        {
            var hotel = new Hotel("Sunrise Resort", 5);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 0, 0, 200);
            });
        }

        [Test]
        public void BookRoomMethodWithNoSuitableRoomShouldNotWork()
        {
            var hotel = new Hotel("Sunrise Resort", 5);
            hotel.AddRoom(new Room(1, 69.99));
            hotel.AddRoom(new Room(2, 99.99));
            hotel.BookRoom(2, 1, 2, 500);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomMethodWithInsufficientBudgetShouldNotWork()
        {
            var hotel = new Hotel("Sunrise Resort", 5);
            hotel.AddRoom(new Room(2, 99));
            hotel.BookRoom(2, 0, 2, 160);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomMethodWithValidDataShouldWork()
        {
            var hotel = new Hotel("Sunrise Resort", 5);
            hotel.AddRoom(new Room(2, 99));
            hotel.BookRoom(2, 0, 2, 300);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
        }

        [Test]
        public void BookRoomMethodWithValidDataShouldIncreaseTurnover()
        {
            var hotel = new Hotel("Sunrise Resort", 5);
            hotel.AddRoom(new Room(2, 99.99));
            hotel.BookRoom(2, 0, 2, 300);

            Assert.That(hotel.Turnover, Is.EqualTo(2 * 99.99));
        }
    }
}