using System.Net;
using BarLocatorService.Domain;
using BarLocatorService.Services;
using Xunit;

namespace BarLocatorService.Test
{
    public class SearchServiceTest
    {
        [Fact]
        public void GivenApiKeyLocationRadiusAndType_NearbySearchShouldCreateWebRequestAndReturnResponseWithOkStatusCode() 
        {
            const string apiKey = "AIzaSyBRlldhAClDuieSD7DBdiqky4N-lkhmb6A";

            var coordinates = new Coordinates(-33.8670522f, 151.1957362f);
            var searchService = new SearchService(new QueryBuilder(apiKey));
            var result = searchService.NearbySearchAsync(coordinates, 5000, "restaurant").Result;
            var httpContent = result.Content.ReadAsStringAsync().Result;

            Assert.NotNull(result);
            Assert.NotNull(httpContent);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
