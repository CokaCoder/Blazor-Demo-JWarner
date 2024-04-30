using Newtonsoft.Json;
using ProxyServer.DomainEntities;

namespace ProxyServer.Services;

public class VehicleLookupService : IVehicleLookupService
{
    private readonly ILogger<VehicleLookupService> _logger;
    private readonly HttpClient _httpClient;

    public VehicleLookupService(ILogger<VehicleLookupService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }


    public async Task<IEnumerable<Vehicle>?> GetVehicleDetailsAsync(string registration)
    {
        if (registration == null)
        {
            throw new ArgumentNullException(nameof(registration));
        }

        //Add request header. This value should be pulled from Azure secure vault through config.
        _httpClient.DefaultRequestHeaders.Add("x-api-key", "fZi8YcjrZN1cGkQeZP7Uaa4rTxua8HovaswPuIno");

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/trade/vehicles/mot-tests?registration={registration}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(responseBody) ?? throw new Exception();
            }
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError("GetVehicleDetailsAsync threw an exception while trying to call the Mot Service api. The exception message was - " + ex.Message);
            throw new Exception();
        }
    }

}
