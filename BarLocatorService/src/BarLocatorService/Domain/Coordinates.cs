using System;

namespace BarLocatorService.Domain
{
    public class Coordinates
    {
        private static readonly Func<float, bool> LongitudePredicate = longitude => longitude < -180 || longitude > 180;
        private static readonly Func<float, bool> LatitudePredicate = latitude => latitude < -90 || latitude > 90;

        public Coordinates(float latitude, float longitude)
        {
            Latitude = ValidateLatitude(latitude);
            Longitude = ValidateLongitude(longitude);
        }

        public float Latitude { get; }
        public float Longitude { get; }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }

        private static float ValidateLatitude(float latitude)
        {
            return ValidateCoordinate(latitude, LatitudePredicate, $"Latitude is out of range: {latitude}");
        }

        private static float ValidateLongitude(float longitude)
        {
            return ValidateCoordinate(longitude, LongitudePredicate, $"Longitude is out of range: {longitude}");
        }

        private static float ValidateCoordinate(float coordinate, Func<float, bool> predicate, string message)
        {
            if (predicate.Invoke(coordinate))
            {
                throw new ArgumentException(message);
            }

            return coordinate;
        }
    }
}