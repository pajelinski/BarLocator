using System.Net.Http;
using System.Threading.Tasks;
using BarLocatorService.Domain;

namespace BarLocatorService.Services.Abstract
{
    public interface ISearchService
    {
        Task<HttpResponseMessage> NearbySearchAsync(Coordinates location, int radius, string type);
    }
}