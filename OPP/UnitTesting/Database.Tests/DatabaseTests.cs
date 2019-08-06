using Database;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private int[] input = new int[] { 1, 2, 3 };

        [SetUp]
        public void Setup()
        {

             database = new Database.Database(input);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void Test2()
        {
            database.Add(4);

            Assert.AreEqual(4, database.Count);
        }

        [Test]
        public void Test3()
        {
            for (int i = 4; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.That(()=>database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Test4()
        {
            int[] input = new int[] {  };

            database = new Database.Database(input);

            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Test5()
        {
            database.Remove();
            Assert.AreEqual(2 , database.Count);
        }

        [Test]
        public void Test6()
        {
            int[] result = database.Fetch();
            Assert.AreEqual(input, result);
        }
    }
}