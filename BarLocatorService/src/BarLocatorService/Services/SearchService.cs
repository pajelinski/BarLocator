using System.Net.Http;
using System.Threading.Tasks;
using BarLocatorService.Domain;
using BarLocatorService.Services.Abstract;

namespace BarLocatorService.Services
{
    public class SearchService : ISearchService
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly HttpClient _httpClient;

        public SearchService(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
            _httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> NearbySearchAsync(Coordinates location, int radius, string type)
        {
            return _httpClient.GetAsync(_queryBuilder.BuildQuery(location, radius, type));
        }
    }
}