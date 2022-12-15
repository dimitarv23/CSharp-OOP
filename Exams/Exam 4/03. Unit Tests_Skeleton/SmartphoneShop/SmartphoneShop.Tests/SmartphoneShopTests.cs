using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(0)]
        [TestCase(2)]
        [TestCase(100000)]
        public void ConstructorShouldSetValueToCapacityProperty(int capacity)
        {
            Shop shop = new Shop(capacity);

            Assert.That(shop.Capacity, Is.EqualTo(capacity));
        }

        [Test]
        public void ConstructorWithInvalidCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-1));
        }

        [Test]
        public void ConstructorShouldInitializePhonesCollection()
        {
            Shop shop = new Shop(2);

            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddMethodShouldAddASmartphone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("iPhone 13", 96);

            shop.Add(smartphone);

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodWithRepeatingPhone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("iPhone 13", 96);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void AddMethodFullCapacity()
        {
            Shop shop = new Shop(0);
            Smartphone smartphone = new Smartphone("iPhone 14", 99);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void RemoveMethodShouldRemoveSmartphone()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iPhone 13", 96));
            shop.Remove("iPhone 13");

            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveMethodWithInvalidModel()
        {
            Shop shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("iPhone 13"));
        }

        [Test]
        public void TestPhoneShouldDecreaseBattery()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("iPhone 13", 96);
            shop.Add(smartphone);

            shop.TestPhone("iPhone 13", 6);
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(90));

            shop.TestPhone("iPhone 13", 6);
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(84));
        }

        [Test]
        public void TestPhoneWithInvalidModel()
        {
            Shop shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("iPhone 13", 6));
        }

        [Test]
        public void TestPhoneWithLowBattery()
        {
            Shop shop = new Shop(2);
            shop.Add(new Smartphone("iPhone 13", 99));
            shop.TestPhone("iPhone 13", 90);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("iPhone 13", 10));
        }

        [Test]
        public void ChargePhoneMethodShouldMaximiseBattery()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("iPhone 13", 99);
            shop.Add(smartphone);
            shop.TestPhone("iPhone 13", 10);

            shop.ChargePhone("iPhone 13");

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(99));
        }

        [Test]
        public void ChargePhoneMethodWithInvalidModel()
        {
            Shop shop = new Shop(2);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("iPhone 13"));
        }
    }
}