using System;
using System.Threading.Tasks;

namespace GetARide.Infrastructure.Services
{
    public class RouteManager : IRootManager
    {
        private static readonly Random random = new Random();
        public double CalculateLength(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
            => random.Next(500,10000);

        public async Task<string> GetAddressAsync(double latitude, double longitude)
            => await Task.FromResult($"Sample address {random.Next(100)}.");
    }
}