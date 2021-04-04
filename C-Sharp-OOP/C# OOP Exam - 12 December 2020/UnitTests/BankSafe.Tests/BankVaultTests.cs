using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Gosho", "1");
        }

        [Test]
        public void Ctor_Should_ImplementDictionaryWithFilledKeys()
        {
            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12));

            string[] letters = { "A", "B", "C" };
            string[] numbers = { "1", "2", "3", "4" };

            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    Assert.That(bankVault.VaultCells.ContainsKey($"{letters[i]}{numbers[j]}"));
                }
            }

            foreach (var pair in bankVault.VaultCells)
            {
                var value = pair.Value;
                Assert.That(value, Is.EqualTo(null));
            }
        }


        [Test]
        public void AddItem_Should_DecreaseNullValuesCount_When_IdemIsAdded()
        {
            bankVault.AddItem("A1", item);

            var nullValuesCount = bankVault.VaultCells.Where(x => x.Value == null).Count();

            Assert.That(nullValuesCount, Is.EqualTo(11));
        }

        [Test]
        public void AddItem_Should_ThrowException_When_VaultCellsDoesNotContainsTheProvidedKeyArgument()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("D1", item));
        }

        [Test]
        public void AddItem_Should_ThrowException_When_VaultCellValueIsNotNull()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item));
        }

        [Test]
        public void AddItem_Should_ThrowException_When_ProvidedItemAlreadyExist()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }

        [Test]
        public void AddItem_Should_ReturnString_When_ItemIsSavedSuccessfully()
        {
            string message = $"Item:{item.ItemId} saved successfully!";

            Assert.That(bankVault.AddItem("A1", item), Is.EqualTo(message));
        }

        [Test]
        public void RemoveItem_Sohuld_IncreaseNullValuesCount_When_ItemIsRemoved()
        {
            bankVault.AddItem("A1", item);

            bankVault.RemoveItem("A1", item);

            var nullValuesCount = bankVault.VaultCells.Where(x => x.Value == null).Count();

            Assert.That(nullValuesCount, Is.EqualTo(12));
        }

        [Test]
        public void RemoveItem_Should_ThrowException_When_ProvidedCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item));
        }

        [Test]
        public void RemoveItem_Should_ThrowException_When_ProvidedItemDoesNotExistInThatCell()
        {
            bankVault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", new Item("Tosho", "2")));
        }

        [Test]
        public void RemoveItem_Should_ReturnString_When_RemovingItemIsSuccessfull()
        {
            bankVault.AddItem("A1", item);

            string message = $"Remove item:{item.ItemId} successfully!";

            Assert.That(bankVault.RemoveItem("A1", item), Is.EqualTo(message));
        }
    }
}