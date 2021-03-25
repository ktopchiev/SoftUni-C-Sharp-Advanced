using NUnit.Framework;
using System;

namespace BankAccount.Test
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            BankAccount account = new BankAccount(1);

            Assert.That(account.Amount > 0);
        }
    }
}
