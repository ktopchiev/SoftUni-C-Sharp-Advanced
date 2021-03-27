//using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            name = "ShadowBlade";
            damage = 60;
            hp = 100;
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void Ctor_Arena_ShouldBeSetProperly()
        {
            Assert.That(arena.Warriors.Count, Is.EqualTo(0));
        }

        [Test]
        public void Warriors_CanBeEnrolledAnd_Should_HaveCount()
        {
            arena.Enroll(warrior);

            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_Should_ThrowException_WhenWarriorExists()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Fight_Should_FindTwoWarriorsByName_OneAttacker_And_OneDeffender()
        {
            arena.Enroll(new Warrior("Attacker", 80, 100));
            arena.Enroll(new Warrior("Deffender", 90, 100));

            arena.Fight("Attacker", "Deffender");

            var attacker = arena.Warriors.FirstOrDefault(x => x.Name == "Attacker");
            var deffender = arena.Warriors.FirstOrDefault(x => x.Name == "Deffender");

            Assert.IsTrue(arena.Warriors.Contains(attacker));
            Assert.IsTrue(arena.Warriors.Contains(deffender));
        }

        [Test]
        [TestCase(null)]
        public void Fight_Should_ThrowException_WhenAttackerArgumentIsNull(string attackerName)
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, warrior.Name));
        }

        [Test]
        [TestCase(null)]
        public void Fight_Should_ThrowException_WhenDeffenderArgumentIsNull(string deffenderName)
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, deffenderName));
        }

        [Test]
        public void Fight_Should_PerformAttackAndDecreaseWarriorHealth()
        {
            arena.Enroll(new Warrior("Blade", 50, 100));

            arena.Enroll(warrior);

            arena.Fight("Blade", warrior.Name);

            Assert.That(warrior.HP, Is.EqualTo(50));
        }
    }
}
