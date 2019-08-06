using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
             car = new Car("abv", "bmv", 10, 200);
        }

        [Test]
        public void Test1()
        {
            car.Refuel(10);
            car.Drive(10);

            Assert.That(car.FuelAmount, Is.EqualTo(9));
        }

        [Test]
        public void Test2()
        {
            car.Refuel(10);

            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void Test3()
        {
            Assert.That(() => car.Refuel(-10), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Test4()
        {
            car.Refuel(10);
            

            Assert.That(()=>car.Drive(1000), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void Test5()
        {
            Assert.That(() => car = new Car("", "bmv", 10, 200), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Test6()
        {
            Assert.That(() => car = new Car("abv", "", 10, 200), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Test7()
        {
            Assert.That(() => car = new Car("abv", "bmv", 0, 200), Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void Test8()
        {
            Assert.That(() => car = new Car("abv", "bmv", 10, 0), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Test9()
        {
            car.Refuel(10);
            car.Drive(-10);

            Assert.That(car.FuelAmount, Is.EqualTo(11));
        }

        [Test]
        public void Test10()
        {
            car.Refuel(1);
            car.Drive(10);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Test11()
        {
            Assert.That(() => car = new Car(null, "bmv", 10, 200), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Test12()
        {
            Assert.That(() => car = new Car("abc", null, 10, 200), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Test13()
        {
            car.Refuel(210);

            Assert.That(car.FuelAmount, Is.EqualTo(200));
        }
    }
}