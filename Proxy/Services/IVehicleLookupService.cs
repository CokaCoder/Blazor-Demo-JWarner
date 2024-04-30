using ProxyServer.DomainEntities;

namespace ProxyServer.Services;

public interface IVehicleLookupService
{
    Task<IEnumerable<Vehicle>?> GetVehicleDetailsAsync(string registration);
}