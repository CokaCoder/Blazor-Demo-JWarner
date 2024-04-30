using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ProxyServer.DomainEntities;
using ProxyServer.Services;
using System.Net.Mime;

namespace ProxyServer.Controllers;


[ApiVersion("1.0")]
[ApiController]
[Route("api/[controller]")]
public class VehicleLookupController : Controller
{
    private readonly ILogger<VehicleLookupController> _logger;
    private readonly IVehicleLookupService _vehicleLookupService;

    public VehicleLookupController(ILogger<VehicleLookupController> logger, IVehicleLookupService vehicleLookupService)
    {
        _logger = logger;
        _vehicleLookupService = vehicleLookupService;
    }


    [HttpPost]
    [MapToApiVersion("1.0")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetVehicleByRegistration([FromBody] Vehicle vehicle)
    {
        ArgumentException.ThrowIfNullOrEmpty(vehicle.Registration);

        var response = await _vehicleLookupService.GetVehicleDetailsAsync(vehicle.Registration);
        return response == null ? NotFound() : Ok(response);
    }
}
