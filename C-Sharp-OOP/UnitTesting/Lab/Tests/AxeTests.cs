using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void When_AxeTakesAttack_Should_DecreaseItsDurability()
        {
            Axe axe = new Axe(10,10);

            axe.Attack(new Dummy(5,5));

            Assert.That(axe.DurabilityPoints, Is.LessThan(10), "Axe does not decrease its durability.");
        }
    }
}
