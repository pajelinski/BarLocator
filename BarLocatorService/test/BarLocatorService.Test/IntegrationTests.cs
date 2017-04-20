using System.Net;
using System.Net.Http;
using Xunit;

namespace BarLocatorService.Test
{
    public class IntegrationTests : IClassFixture<IntegrationTestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(IntegrationTestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async void GivenLatitude50_0618971_Longitude19_934567_AndRadius_2000_GetAsyncReuestSentToBarLocatorServiceShouldReturnResponseWithStatusCodeOk()
        {
            var response = await _client.GetAsync("/api/bars/nearby?latitude=50.0618971&longitude=19.9345673&radius=2000");

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);
        }
    }
}