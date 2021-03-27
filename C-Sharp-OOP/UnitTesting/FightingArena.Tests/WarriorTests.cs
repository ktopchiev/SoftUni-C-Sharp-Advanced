using NUnit.Framework;
//using FightingArena;
using System;


namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Axe", 75, 100);
        }

        [Test]
        public void Ctor_Warrior_SetProperly()
        {
            Assert.That(warrior.Name, Is.EqualTo("Axe"));
            Assert.That(warrior.Damage, Is.EqualTo(75));
            Assert.That(warrior.HP, Is.EqualTo(100));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Name_Property_Should_ThrowException_WhenArgumentIsNullOrEmptyOrWhitespace(string name)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, 75, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Damage_Property_ShouldThrowException_WhenArgumentIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Pesho", damage, 100));
        }

        [Test]
        public void HP_Property_Should_ThrowException_WhenArgumentIsNegative()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Pesho", 20, -5));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void Attack_Should_ThrowException_WhenAttackerHPIsBelowOrEqualToMinAttackHP(int hp)
        {
            warrior = new Warrior("ShadowBlade", 60, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("LightBlade", 20, 40)));
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void Attack_Should_ThrowException_WhenDeffenderHPIsBelowOrEqualToMinAttackHP(int hp)
        {
            warrior = new Warrior("ShadowBlade", 60, 50);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("LightBlade", 20, hp)));
        }

        [Test]
        public void Attack_Should_ThrowException_WhenAttackerHPIsLowerThanDeffenderDamage()
        {
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("LightBlade", 120, 100)));
        }

        [Test]
        public void Attack_Should_DecreaseAttackerHPByDeffenderDamage()
        {
            warrior.Attack(new Warrior("LightBlade", 20, 100));
            Assert.That(warrior.HP, Is.EqualTo(80));
        }

        [Test]
        public void Attack_Should_SetToZeroDeffenderDamage_WhenAttackerDamageIsBiggerThanDeffenderHP()
        {
            var deffender = new Warrior("LightBlade", 20, 70);
            warrior.Attack(deffender);
            Assert.That(deffender.HP, Is.Zero);
        }

        [Test]
        public void Attack_Should_DecreaseDeffenderHPByAttackerDamageValue()
        {
            var deffender = new Warrior("LightBlade", 20, 100);
            warrior.Attack(deffender);
            Assert.That(deffender.HP, Is.EqualTo(25));
        }
    }
}