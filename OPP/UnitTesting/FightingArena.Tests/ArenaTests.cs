using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;
        Warrior warrior = new Warrior("Vencislav", 10, 20);

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Test1()
        {
            arena.Enroll(warrior);
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test2()
        {
            arena.Enroll(warrior);
            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);//.With.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Test3()
        {
            Assert.That(() => arena.Fight("Vencislav", "Venci"), Throws.InvalidOperationException);//.With.EqualTo("There is no fighter with name Venci enrolled for the fights!"));
        }

        [Test]
        public void Test4()
        {
            Assert.That(() => arena.Fight("", "Venci"), Throws.InvalidOperationException);//.With.EqualTo("There is no fighter with name  enrolled for the fights!"));
        }

        [Test]
        public void Test5()
        {
            Warrior attacker = new Warrior("Vencislav", 30, 35);
            arena.Enroll(attacker);
            Warrior defender = new Warrior("Venci", 25, 31);
            arena.Enroll(defender);
            arena.Fight("Vencislav", "Venci");
            Assert.That(attacker.HP, Is.EqualTo(10));
        }
    }
}
