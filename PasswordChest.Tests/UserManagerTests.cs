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
    public class UserManagerTests
    {
        [TearDown]
        public void Clean()
        {
            Extension.DeleteSave();
        }

        [Test]
        public void UserManager_Is_Created_With_No_Currebt_User()
        {
            ChestContext chestContext = new ChestContext();
            chestContext.Manager.Should().NotBeNull();
            chestContext.Manager.CurrentUser.Should().BeNull();
        }

        [Test]
        public void UserManager_CouldCreate_A_New_User()
        {
            ChestContext chestContext = new ChestContext();
            User user = chestContext.Manager.CreateNewUser("Guillaume", "Fimes", "Test");
            chestContext.Manager.CurrentUser.Should().Be(user);
        }

        [Test]
        public void UserManager_Create_Existant_User_Should_Return_Exception()
        {
            ChestContext chestContext = new ChestContext();
            chestContext.Manager.CreateNewUser("Guillaume", "Fimes", "Test");
            Action action = () => chestContext.Manager.CreateNewUser("Guillaume", "Fimes", "Test");
            action.ShouldThrow<InvalidOperationException>();
        }

        [Test]
        public void UserManager_Create_A_New_User_Should_Put_It_Inside_ChestContext()
        {
            ChestContext chestContext = new ChestContext();
            chestContext.Manager.CreateNewUser("Guillaume", "Fimes", "Test");
            chestContext.UsersName.Count().Should().Be(1);
        }
    }
}
