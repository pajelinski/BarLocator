using System;
using BarLocatorService.Domain;
using Xunit;

namespace BarLocatorService.Test
{
    public class CoordinatesTest
    {
        [Fact]
        public void GivenLatitude5Andlongitude10_ToSrtingShouldReturnFormatedSting()
        {
            const string expected = "5, 10";
            var coordinates = new Coordinates(5, 10);
            Assert.Equal(expected, coordinates.ToString());
        }

        [Fact]
        public void GivenLatitude91Andlongitude0_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Coordinates(91, 0));
        }

        [Fact]
        public void GivenLatitudeMinus91Andlongitude0_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Coordinates(-91, 0));
        }

        [Fact]
        public void GivenLatitude0Andlongitude181_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Coordinates(0, 181));
        }

        [Fact]
        public void GivenLatitude0AndlongitudeMinus181_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Coordinates(0, -181));
        }

        [Fact]
        public void GivenLatitude0AndlongitudeMinus170_ShouldNotThrowArgumentException()
        {
            Assert.NotNull(new Coordinates(0, -170));
        }
    }
}