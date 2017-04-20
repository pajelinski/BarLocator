using System.Threading.Tasks;
using BarLocatorService.Domain;
using BarLocatorService.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BarLocatorService.Controllers
{
    [Route("api/")]
    public class BarLocationController : Controller
    {
        private const string BarType = "bar";
        private readonly ISearchService _searchService;

        public BarLocationController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("bars/nearby")]
        public async Task<string> GetNearbyBars(float latitude, float longitude, int radius)
        {
            var location = new Coordinates(latitude, longitude);
            return await SearchNearbyAsync(radius, location, BarType);
        }

        private Task<string> SearchNearbyAsync(int radius, Coordinates location, string type)
        {
            return _searchService.NearbySearchAsync(location, radius, type).Result.Content.ReadAsStringAsync();
        }
    }
}