using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void IsDatabaseCtorSettedProperly()
        {
            int[] nums = { 1, 2, 3, 4, 5 };

            database = new Database.Database(nums);

            Assert.That(database.Count, Is.EqualTo(nums.Length));
        }

        [Test]
        public void When_AddingToDatabase_Should_IncreaseItsCount()
        {
            database.Add(69);

            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_GetCount_Should_ReturnCountOfDatabaseData()
        {
            int[] nums = {1, 2, 3};

            database = new Database.Database(nums);

            Assert.That(database.Count, Is.EqualTo(3));
        }

        [Test]
        public void When_AddMoreThanDatabaseLimit_Should_ThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void When_RemoveFromDatabase_Should_DecreaseCount()
        {
            database = new Database.Database(1);

            database.Remove();

            Assert.That(database.Count == 0);
        }

        [Test]
        public void When_RemoveFromEmptyDatabase_Should_ThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void When_FetchDatabase_Should_ReturnNewArrayCopyOfData()
        {
            int[] nums = {1, 3, 5};

            database = new Database.Database(nums);

            Assert.That(database.Fetch, Is.EquivalentTo(nums));
        }
    }
}