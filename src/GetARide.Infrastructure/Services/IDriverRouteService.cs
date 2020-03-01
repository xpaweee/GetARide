using System;
using System.Threading.Tasks;

namespace GetARide.Infrastructure.Services
{
    public interface IDriverRouteService
    {
         Task AddAsync(Guid userId,string name,double startLatitude, double startLongitude,double endLatitude, double endLongitude);
         Task DeleteAsync(Guid userId,string name);
    }
}