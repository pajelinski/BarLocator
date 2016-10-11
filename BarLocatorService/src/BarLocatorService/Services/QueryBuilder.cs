using System;
using BarLocatorService.Domain;

namespace BarLocatorService.Services
{
    public class QueryBuilder
    {
        private const string GoolePlacesApiUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
        private readonly string _apiKey;

        public QueryBuilder(string apiKey)
        {
            _apiKey = ValidateApiKey(apiKey);
        }

        public string BuildQuery(Coordinates coordinates, int radius, string type)
        {
            return $"{GoolePlacesApiUrl}location={coordinates}&radius={radius}&type={type}&key={_apiKey}";
        }

        private static string ValidateApiKey(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException();
            }

            return apiKey;
        }
    }
}