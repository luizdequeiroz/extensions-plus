using System;
using Xunit;
using static ExtensionsPlus.ComparerExtension;

namespace ExtensionsPlus.Tests
{
    public class ComparerExtensionTests
    {
        class User
        {
            public Guid Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        [Fact(DisplayName = "Testing equality between users with extension")]
        public void TestingEqualityBetweenUsersWithExtension()
        {
            var id = Guid.NewGuid();
            var user01 = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user01_repeated = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            Assert.True(user01.Equals<User>(user01_repeated));
        }

        [Fact(DisplayName = "Testing difference between users with extension")]
        public void TestingDifferenceBetweenUsersWithExtension()
        {
            var user01 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user02 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_two",
                Email = "user02@email.com",
                Phone = "0800 020 2020"
            };

            Assert.False(user01.Equals<User>(user02));
        }

        [Fact(DisplayName = "Testing difference between users with Comparer object")]
        public void TestingDifferenceBetweenUsersWithComparerObject()
        {
            var user01_expected = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user02_actual = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_two",
                Email = "user02@email.com",
                Phone = "0800 020 2020"
            };

            Assert.NotEqual(user01_expected, user02_actual, new GenericComparer<User>());
        }

        [Fact(DisplayName = "Testing equality between users with Comparer object")]
        public void TestingEqualityBetweenUsersWithComparerObject()
        {
            var id = Guid.NewGuid();
            var user01_expected = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user01_actual = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            Assert.Equal(user01_expected, user01_actual, new GenericComparer<User>());
        }
    }
}
