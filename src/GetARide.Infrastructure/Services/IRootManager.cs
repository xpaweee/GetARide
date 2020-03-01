using System.Threading.Tasks;

namespace GetARide.Infrastructure.Services
{
    public interface IRootManager : IService
    {
         Task<string> GetAddressAsync(double latitude,double longitude);
         double CalculateLength(double startLatitude, double startLongitude,double endLatitude, double endLongitude);
    }
}