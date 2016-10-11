using System.Threading.Tasks;
using BarLocatorService.Domain;
using BarLocatorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarLocatorService.Controllers
{
    [Route("api/")]
    public class BarLocationController : Controller
    {
        private const string BarType = "bar";
        private readonly SearchService _searchService;

        public BarLocationController()
        {
            _searchService = new SearchService(new QueryBuilder("AIzaSyBRlldhAClDuieSD7DBdiqky4N-lkhmb6A"));
        }

        [HttpGet("bars/nearby")]
        public string GetNearbyBars(float latitude, float longitude, int radius)
        {
            var location = new Coordinates(latitude, longitude);
            return SearchNearbyAsync(radius, location, BarType).Result;
        }

        private Task<string> SearchNearbyAsync(int radius, Coordinates location, string type)
        {
            return _searchService.NearbySearchAsync(location, radius, type).Result.Content.ReadAsStringAsync();
        }
    }
}