using System.ComponentModel;
using Xunit;

namespace ExtensionsPlus.Tests
{
    public class EnumExtensionTests
    {
        enum Streamers
        {
            [Description("Netflix")]
            NETFLIX = 1,
            [Description("PrimeVideo")]
            PRIME_VIDEO = 2,
            [Description("Telecine Play")]
            TELECINE_PLAY = 3,
            [Description("HBO GO")]
            HBO_GO = 4,
            [Description("Disney+")]
            DISNEY_PLUS = 5,
            DC_UNIVERSE = 6
        }

        [Theory(DisplayName = "Testing enum get by description")]
        [InlineData("Disney+")]
        [InlineData("")]
        [InlineData(null)]
        public void TestingEnumGetByDescription(string enumDescription)
        {
            var enumIndex = enumDescription.ToEnumIndex<Streamers>();

            Assert.Equal(string.IsNullOrEmpty(enumDescription) ? (int)Streamers.NETFLIX : (int)Streamers.DISNEY_PLUS, (int)enumIndex);
        }

        [Fact(DisplayName = "Testing enum get by enum name")]
        public void TestingEnumGetByEnumName()
        {
            var enumDescription = "DC_UNIVERSE";
            var enumIndex = enumDescription.ToEnumIndex<Streamers>();

            Assert.Equal((int)Streamers.DC_UNIVERSE, (int)enumIndex);
        }

        [Theory(DisplayName = "Testing enum get by index")]
        [InlineData("1", "Netflix")]
        [InlineData("2", "PrimeVideo")]
        [InlineData("3", "Telecine Play")]
        [InlineData("4", "HBO GO")]
        [InlineData("5", "Disney+")]
        public void TestingEnumGetByIndex(string index, string enumDescriptionExpected)
        {
            var enumIndex = (Streamers)int.Parse(index);
            var enumDescription = enumIndex.ToDescriptionString();

            Assert.Equal(enumDescriptionExpected, enumDescription);
        }
    }
}
