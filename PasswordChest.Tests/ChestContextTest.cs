using FluentAssertions;
using NUnit.Framework;
using PasswordChest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChest.Tests
{
    [TestFixture]
    public class ChestContextTest
    {
        [TearDown]
        public void Clean()
        {
            Extension.DeleteSave();
        }

        [Test]
        public void ChestContext_Should_Be_Created_With_No_User_And_Not_Null()
        {
            ChestContext chestContext = new ChestContext();
            chestContext.UsersName.Should().NotBeNull();
            chestContext.UsersName.Count().Should().Be(0);
        }

        [Test]
        public void ChestContext_Could_Load_Previous_Data()
        {
            ChestContext chestContext = new ChestContext();
            chestContext.Manager.CreateNewUser("Guillaume", "Fimes", "Test");
            ChestContext chestContext2 = new ChestContext();
            chestContext2.UsersName.Count().Should().Be(1);
            chestContext2.UsersName.First().Should().Be("Guillaume Fimes");
        }
    }
}
