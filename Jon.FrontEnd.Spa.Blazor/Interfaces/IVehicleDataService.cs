using Jon.FrontEnd.Spa.Blazor.Entities;

namespace Jon.FrontEnd.Spa.Blazor.Interfaces;

public interface IVehicleDataService
{
    Task<IEnumerable<Vehicle>?> GetVehicleDetailsAsync(string registration);
}
