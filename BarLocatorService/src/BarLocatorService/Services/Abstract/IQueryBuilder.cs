using BarLocatorService.Domain;

namespace BarLocatorService.Services.Abstract
{
    public interface IQueryBuilder
    {
        string BuildQuery(Coordinates coordinates, int radius, string type);
    }
}