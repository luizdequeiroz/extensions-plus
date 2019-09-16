using ExtensionsPlus.Tests.Models;
using System;
using Xunit;

namespace ExtensionsPlus.Tests
{
    public class ObjectsExtensionTests
    {
        [Fact(DisplayName = "Testing applying properties from object to other object")]
        public void TestingApplyingPropertiesFromObjectToOtherObject()
        {
            var userFrom = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_from",
                Email = "user@from.com",
                Phone = "0800 000 1111"
            };

            var userTo = new User();
            userTo.SetProperties(userFrom);

            Assert.True(userFrom.Equals<User>(userTo));
        }

        [Fact(DisplayName = "Testing applying properties without exception property from object to other object")]
        public void TestingApplyingPropertiesWithoutExceptionPropertyFromObjectToOtherObject()
        {
            var userFrom = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_from",
                Email = "user@from.com",
                Phone = "0800 000 1111"
            };

            var userTo = new User();
            userTo.SetProperties(userFrom, "Id");

            Assert.Equal(userFrom.Username, userTo.Username);
            Assert.False(userFrom.Equals<User>(userTo));
        }

        [Fact(DisplayName = "Testing applying properties from object to different object")]
        public void TestingApplyingPropertiesFromObjectToDifferentObject()
        {
            var userFrom = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_from",
                Email = "user@from.com",
                Phone = "0800 000 1111"
            };

            var clientTo = new Client();
            clientTo.SetProperties(userFrom);

            Assert.Equal(userFrom.Username, clientTo.Username);
            Assert.Equal(userFrom.Email, clientTo.Email);
            Assert.Equal(userFrom.Phone, clientTo.Phone);
        }
    }
}
