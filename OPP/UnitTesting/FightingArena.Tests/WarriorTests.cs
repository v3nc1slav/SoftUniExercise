using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        Warrior warrior; 

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Vencislav", 10, 20);
        }

        [Test]
        public void Test1()
        {
            Assert.That(() => new Warrior("", 10, 20), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void Test2()
        {
            Assert.That(() => new Warrior(null, 10, 20), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void Test3()
        {
            Assert.That(() => new Warrior("Vencislav", -1, 20), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void Test4()
        {
            Assert.That(() => new Warrior("Vencislav", 10, -1), Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Test5()
        {
            Warrior warrior1 = new Warrior("Venci", 10, 31);
            Assert.That(()=>warrior.Attack(warrior1), Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Test6()
        {
            warrior = new Warrior("Vencislav", 10,35);
            Warrior warrior1 = new Warrior("Venci", 10, 20);
            Assert.That(() => warrior.Attack(warrior1), Throws.InvalidOperationException.With.Message.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void Test7()
        {
            warrior = new Warrior("Vencislav", 10, 35);
            Warrior warrior1 = new Warrior("Venci", 55, 31);
            Assert.That(() => warrior.Attack(warrior1), Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void Test8()
        {
            warrior = new Warrior("Vencislav", 32, 35);
            Warrior warrior1 = new Warrior("Venci", 25, 31);
            warrior.Attack(warrior1);
            Assert.That(warrior1.HP, Is.EqualTo(0));
        }


        [Test]
        public void Test9()
        {
            warrior = new Warrior("Vencislav", 32, 35);
            Warrior warrior1 = new Warrior("Venci", 25, 31);
            warrior.Attack(warrior1);
            Assert.That(warrior.HP, Is.EqualTo(10));
        }

        [Test]
        public void Test10()
        {
            warrior = new Warrior("Vencislav", 30, 35);
            Warrior warrior1 = new Warrior("Venci", 25, 31);
            warrior.Attack(warrior1);
            Assert.That(warrior1.HP, Is.EqualTo(1));
        }
    }
}