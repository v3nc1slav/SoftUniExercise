using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase.ExtendedDatabase database;


        [SetUp]
        public void Setup()
        {
            person = new Person(0123456789, "Vencislav");
            database = new ExtendedDatabase.ExtendedDatabase(person);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass(person.UserName, Is.EqualTo("Vencislav"));
        }

        [Test]
        public void Test2()
        {
            Assert.That(person.Id, Is.EqualTo(0123456789));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(1, database.Count);
        }


        [Test]
        public void Test4()
        {
            person = new Person(987654321, "Vladi");
            database.Add(person);

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void Test5()
        {
            person = new Person(987654321, "Vladi");
            database.Add(person);
      
            Assert.That(() => database.Add(person), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Test6()
        {
            person = new Person(987654321, "Vladi");
            Person person1 = new Person(987654321, "Vladislav");
            database.Add(person);

            Assert.That(() => database.Add(person1), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void Test7()
        {
            person = new Person(2, "b");
            database.Add(person);
            person = new Person(3, "c");
            database.Add(person);
            person = new Person(4, "d");
            database.Add(person);
            person = new Person(5, "e");
            database.Add(person);
            person = new Person(6, "f");
            database.Add(person);
            person = new Person(7, "h");
            database.Add(person);
            person = new Person(8, "g");
            database.Add(person);
            person = new Person(9, "i");
            database.Add(person);
            person = new Person(10, "j");
            database.Add(person);
            person = new Person(11, "k");
            database.Add(person);
            person = new Person(12, "l");
            database.Add(person);
            person = new Person(13, "m");
            database.Add(person);
            person = new Person(14, "n");
            database.Add(person);
            person = new Person(15, "p");
            database.Add(person);
            person = new Person(16, "r");
            database.Add(person);
            person = new Person(17, "s");

            Assert.That(() => database.Add(person), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Test8()
        {
            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void Test9()
        {
            database.Remove();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void Test10()
        {
            //person = new Person(13, "");
            //Assert.Throws<ArgumentOutOfRangeException>(() =>
            //{
            //    database.FindByUsername(person.UserName);
            //});
            Assert.That(() => database.FindByUsername(""), Throws.ArgumentNullException);
        }

        [Test]
        public void Test11()
        {
            Assert.That(() => database.FindByUsername("Venci"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void Test12()
        {
            Person person1 = database.FindByUsername("Vencislav");

            Assert.That(person, Is.EqualTo(person1));
        }

        [Test]
        public void Test13()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });
           // Assert.That(() => database.FindById(-1), Throws.ArgumentOutOfRangeException.With.Message.EqualTo("Id should be a positive number!")) ;
        }

        [Test]
        public void Test14()
        {
            Assert.That(() => database.FindById(12345), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void Test15()
        {
            Person person1 = database.FindById(0123456789);

            Assert.That(person, Is.EqualTo(person1));
        }
    }
}