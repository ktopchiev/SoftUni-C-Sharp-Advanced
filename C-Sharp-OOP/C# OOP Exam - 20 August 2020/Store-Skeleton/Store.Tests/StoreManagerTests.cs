using NUnit.Framework;
using System;

namespace Store.Tests
{

    public class StoreManagerTests
    {
        private StoreManager storeManager;
        private Product product;
        private string name;
        private int quantity;
        private decimal price;

        [SetUp]
        public void Setup()
        {
            storeManager = new StoreManager();
            name = "Shirt";
            quantity = 1;
            price = 15;
            product = new Product(name, quantity, price);
            storeManager.AddProduct(product);
        }

        [Test]
        public void Ctor_WhenIsSet_ShouldBeSetProperly()
        {
            Assert.That(storeManager.Count, Is.EqualTo(1));
            Assert.That(storeManager.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddProduct_Should_IncreaseProductsListCount()
        {
            Product newProduct = new Product("Glass", 1, 5);

            storeManager.AddProduct(newProduct);

            Assert.That(storeManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddProduct_Should_ThrowException_When_ProductIsNull()
        {
            product = null;

            Assert.Throws<ArgumentNullException>(() => storeManager.AddProduct(product));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void AddProduct_Should_ThrowException_When_ProductQuantityIsEqualOrLessThanZero(int quantity)
        {
            product = new Product(name, quantity, price);

            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(product));
        }

        [Test]
        public void BuyProduct_Should_DecreaseProductQuantity()
        {
            storeManager.BuyProduct("Shirt", 1);

            Assert.That(product.Quantity, Is.EqualTo(0));
        }

        [Test]
        public void BuyProduct_Should_ThrowException_When_ProductIsNull()
        {

            Assert.Throws<ArgumentNullException>(() => storeManager.BuyProduct("Glass", 2));
        }

        [Test]
        public void BuyProduct_Should_ThrowException_When_ProductQuantityIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => storeManager.BuyProduct(name, 2));
        }

        [Test]
        public void BuyProduct_Should_ReturnFinalPrice_When_ProductIsBuyed()
        {
            Assert.That(storeManager.BuyProduct(name, quantity), Is.EqualTo(15));
        }

        [Test]
        public void GetMostExpensiveProduct_Should_ReturnMostExpensiveProduct()
        {
            Product mostExpensiveProduct = new Product("Rolex", 1, 20000);

            storeManager.AddProduct(mostExpensiveProduct);

            Assert.That(storeManager.GetTheMostExpensiveProduct().Price, Is.EqualTo(20000));
        }
    }
}