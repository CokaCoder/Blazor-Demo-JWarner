using Jon.FrontEnd.Spa.Blazor.Entities;
using Jon.FrontEnd.Spa.Blazor.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Jon.FrontEnd.Spa.Blazor.Services;

public class VehicleDataService : IVehicleDataService
{
    private readonly ILogger<VehicleDataService> _logger;
    private readonly HttpClient _httpClient;

    public VehicleDataService(ILogger<VehicleDataService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }


    public async Task<IEnumerable<Vehicle>?> GetVehicleDetailsAsync(string registration)
    {
        try
        {
            var requestContent = new Vehicle { Registration = registration };
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"api/VehicleLookup/", requestContent);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(responseBody) ?? throw new Exception();
            }
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new Exception();
        }
    }
}
