using NUnit.Framework;
using System;

namespace DummyTests
{
    [TestFixture]
    public class DummyTests
    {

        [Test]
        public void When_DummyIsAttacked_Should_LoseHealth()
        {
            Dummy dummy = new Dummy(100, 100);

            dummy.TakeAttack(50);

            Assert.That(dummy.Health, Is.LessThan(100), "Dummy does not decrease health points.");
        }

        [Test]
        public void When_DummyIsDead_Should_ThrowExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }

        [Test]
        public void When_DummyIsDead_Should_CanGiveExperience()
        {
            Dummy dummy = new Dummy(0, 100);

            Assert.That(dummy.GiveExperience, Is.EqualTo(100));
        }

        [Test]
        public void When_DummyIsAlive_Should_CannotGiveExperience()
        {
            Dummy dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
