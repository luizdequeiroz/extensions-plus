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

        [Fact(DisplayName = "Testing applying different properties from object to other object")]
        public void TestingApplyingDifferentPropertiesFromObjectToOtherObject()
        {
            var userPayload = new User
            {
                Username = "user_payload",
                Email = "user@payload.com",
                Phone = null
            };

            var userTarget = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_target",
                Email = "user@target.com",
                Phone = "0800 000 1111"
            };

            userTarget.SetDifferentProperties(userPayload);

            Assert.False(userTarget.Id.ToString() == Guid.Empty.ToString());
            Assert.Equal(userPayload.Username, userTarget.Username);
            Assert.Equal(userPayload.Email, userTarget.Email);
            Assert.Equal("0800 000 1111", userTarget.Phone);
        }

        [Fact(DisplayName = "Testing applying different properties from object to different object")]
        public void TestingApplyingDifferentPropertiesFromObjectToDifferentObject()
        {
            var userPayload = new User
            {
                Username = "user_payload",
                Email = "user@payload.com",
                Phone = null
            };

            var clientTarget = new Client
            {
                Id = Guid.NewGuid(),
                Username = "client_target",
                Email = "client@target.com",
                Phone = "0800 000 1111"
            };

            clientTarget.SetDifferentProperties(userPayload);

            Assert.False(clientTarget.Id.ToString() == Guid.Empty.ToString());
            Assert.Equal(userPayload.Username, clientTarget.Username);
            Assert.Equal(userPayload.Email, clientTarget.Email);
            Assert.Equal("0800 000 1111", clientTarget.Phone);
        }
    }
}
