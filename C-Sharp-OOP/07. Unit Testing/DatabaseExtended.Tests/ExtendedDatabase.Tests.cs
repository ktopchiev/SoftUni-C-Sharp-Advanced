//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private string username;
        private Person person;

        [SetUp]
        public void Setup()
        {
            username = "username";
            person = new Person(1, username);
            database = new ExtendedDatabase(person);
        }

        [Test]
        public void When_CtorIsSet_ShouldSetProperly()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"username{i}");
            }

            database = new ExtendedDatabase(persons);

            Assert.That(database.Count == 16);
        }

        [Test]
        public void When_CtorRangeIsExceeded_ShouldThrowException()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, $"username{i}");
            }

            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase(persons));
        }

        [Test]
        public void When_AddToDatabase_Should_IncreaseCountOfPersons()
        {

            database = new ExtendedDatabase(new Person(2, "johnDoe"));

            database.Add(person);

            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void When_AddToFullDatabase_Should_ThrowInvalidOperationException()
        {

            Person[] fullPersons = new Person[16];

            for (int i = 0; i < fullPersons.Length; i++)
            {
                fullPersons[i] = new Person(i, $"username{i}");
            }

            ExtendedDatabase fullDatabase = new ExtendedDatabase(fullPersons);

            Assert.Throws<InvalidOperationException>(() => fullDatabase.Add(person));
        }

        [Test]
        public void When_AddUsernameThatExistsInData_Should_ThrowException()
        {

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "username")));
        }

        [Test]
        public void When_AddIdThatExistsInData_Should_ThrowException()
        {

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "JohnDoe")));
        }

        [Test]
        public void When_RemoveFromDatabase_Should_DecreaseItsCount()
        {
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_RemoveFromEmptyDatabase_Should_ThrowException()
        {
            database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void When_FindByUsername_Should_ReturnPersonWithThatUsername()
        {
            Assert.That(database.FindByUsername(username).UserName, Is.EqualTo(username));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_FindByUsernameReceivedArgumentIsNullOrEmpty_Should_ThrowException(string username)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }
        
        [Test]
        public void When_FindByUsernameReceivedUsernameDoesNotExist_Should_ThrowException()
        {
            string nonExistingUser = "JohnDoe";

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(nonExistingUser));
        }

        [Test]
        public void When_FindById_Should_ReturnPersonWithThatId()
        {
            int id = 1;
            Assert.That(database.FindById(id).Id, Is.EqualTo(id));
        }

        [Test]
        public void When_FindByIdReceivedArgumentIsNegativeNum_Should_ThrowException()
        {
            int id = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void When_FindByIdReceivedIdDoesNotExist_Should_ThrowException()
        {
            int nonExistingId = 69;

            Assert.Throws<InvalidOperationException>(() => database.FindById(nonExistingId));
        }
    }
}