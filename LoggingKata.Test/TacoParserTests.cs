using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {      
        [Theory]
        [InlineData("0, 0, Taco Bell Warrior", 0, 0, "Taco Bell Warrior")]
        [InlineData("-90, 180, Taco Bell North Ridge", 90, 180, "Taco Bell North Ridge")]
        [InlineData("90, -180, Taco Bell Smithers", 67.723, 85.976, "Taco Bell Smithers")]
        public void ShouldParse(string str, double expectedLat, double expectedLon, string expectedName)
        {
            // TODO: Complete Should Parse
            TacoParser parsed = new TacoParser();

            ITrackable actual = parsed.Parse(str);

            Assert.Equal(expectedLat, actual.Location.Latitude);
            Assert.Equal(expectedLon, actual.Location.Longitude);
            Assert.Equal(expectedName, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Taco, Bell")]
        [InlineData("-91, 50, Taco Bell Warrior")]
        [InlineData("50, -181, Taco Bell Warrior")]
        [InlineData("50, bell, Taco Mama")]
        [InlineData("91, 50, Taco Bell Warrior")]
        [InlineData("50, 181, Taco Bell Sanchez")]
        [InlineData("12")]
        [InlineData("0,112")]
        public void ShouldFailParse(string str)
        {
            TacoParser notparse = new TacoParser();

            ITrackable actual = notparse.Parse(str);

            Assert.Null(actual);
        }
    }
}
