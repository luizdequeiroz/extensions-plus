using ExtensionsPlus.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static ExtensionsPlus.ComparerExtension;

namespace ExtensionsPlus.Tests
{
    public class ConvertersExtensionTests
    {
        [Fact(DisplayName = "Testing conversion from IEnumerable of user to DataTable object")]
        public void TestingConversionFromIEnumerableOfUserToDataTableObject()
        {
            IEnumerable<User> users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "user_zero_one",
                    Email = "user01@email.com",
                    Phone = "0800 010 1010"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "user_zero_two",
                    Email = "user02@email.com",
                    Phone = "0800 020 2020"
                }
            };

            var dataTableUser = users.ToDataTable();

            Assert.Equal(users.First().Id, (Guid)dataTableUser.Rows[0][0], new GenericComparer<Guid>());
            Assert.Equal(users.Last().Id, (Guid)dataTableUser.Rows[1][0], new GenericComparer<Guid>());

            Assert.Equal(users.First().Username, (string)dataTableUser.Rows[0][1]);
            Assert.Equal(users.Last().Username, (string)dataTableUser.Rows[1][1]);

            Assert.Equal(users.First().Email, (string)dataTableUser.Rows[0][2]);
            Assert.Equal(users.Last().Email, (string)dataTableUser.Rows[1][2]);

            Assert.Equal(users.First().Phone, (string)dataTableUser.Rows[0][3]);
            Assert.Equal(users.Last().Phone, (string)dataTableUser.Rows[1][3]);
        }

        [Fact(DisplayName = "Testing throws by conversion from IEnumerable of dynamic to DataTable object")]
        public void TestingThrowsByConversionFromIEnumerableOfDynamicToDataTableObject()
        {
            IEnumerable<dynamic> dynamics = new List<dynamic>
            {
                new
                {
                    Latitude = 23.600000,
                    Longitude = -3.400000
                },
                new
                {
                    Latitude = 12.123456,
                    Longitude = 20.654321
                }
            };

            Assert.Throws<NotImplementedException>(() => dynamics.ToDataTable());
        }

        [Fact(DisplayName = "Testing conversion from IEnumerable of object to DataTable object")]
        public void TestingConversionFromIEnumerableOfObjectToDataTableObject()
        {
            IEnumerable<object> objects = new List<object>
            {
                new
                {
                    Name = "Luiz",
                    Lastname = "de Queiroz"
                },
                new
                {
                    Name = "Wladigley",
                    Lastname = "Simão"
                },
                new
                {
                    Name = "Pascoal",
                    Lastname = "Bruno"
                }
            };

            //Assert.Equal((string)objects.First().GetType().GetField("Name").GetValue(objects.First()), (string)dataTableObject.Rows[0][0]); 
            //Assert.Equal((string)objects.First().GetType().GetField("Lastname").GetValue(objects.First()), (string)dataTableObject.Rows[0][1]);

            //Assert.Equal((string)objects.ElementAt(1).GetType().GetField("Name").GetValue(objects.First()), (string)dataTableObject.Rows[1][0]);
            //Assert.Equal((string)objects.ElementAt(1).GetType().GetField("Lastname").GetValue(objects.First()), (string)dataTableObject.Rows[1][1]);

            //Assert.Equal((string)objects.Last().GetType().GetField("Name").GetValue(objects.First()), (string)dataTableObject.Rows[2][0]);
            //Assert.Equal((string)objects.Last().GetType().GetField("Lastname").GetValue(objects.First()), (string)dataTableObject.Rows[2][1]);

            Assert.Throws<NotImplementedException>(() => objects.ToDataTable());

        }
    }
}
