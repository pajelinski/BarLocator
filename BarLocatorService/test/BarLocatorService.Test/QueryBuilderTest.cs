using System;
using BarLocatorService.Domain;
using BarLocatorService.Services;
using Xunit;

namespace BarLocatorService.Test
{
    public class QueryBuilderTest
    {
        [Fact]
        public void GivenApiKeyLocationRadiusAndType_BuildQuery_ShouldReturnCorrectUrl()
        {
            const string expected = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=10, 20&radius=5000&type=restaurant&key=someApiKey";
            var queryBuilder = new QueryBuilder("someApiKey");
            var result = queryBuilder.BuildQuery(new Coordinates(10, 20), 5000, "restaurant");
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenEmptyApiKey_QueryBuilderConstructor_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QueryBuilder(""));
        }

        [Fact]
        public void GivenNull_QueryBuilderConstructor_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new QueryBuilder(null));
        }
    }
}