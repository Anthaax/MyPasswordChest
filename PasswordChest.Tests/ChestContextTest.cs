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
    }
}
