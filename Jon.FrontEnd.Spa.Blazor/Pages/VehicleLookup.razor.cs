using Jon.FrontEnd.Spa.Blazor.Entities;
using Jon.FrontEnd.Spa.Blazor.Interfaces;
using Jon.FrontEnd.Spa.Blazor.State;
using Microsoft.AspNetCore.Components;

namespace Jon.FrontEnd.Spa.Blazor.Pages;

public partial class VehicleLookup
{
    [Inject]
    public required IVehicleDataService VehicleDataService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required ApplicationState ApplicationState { get; set; } //might want to use this later if time...

    public Vehicle Vehicle { get; set; } = new Vehicle() { Registration = ""};

    private string? _errorMessage;

    private bool _loading;

    public IEnumerable<Vehicle>? _searchResult { get; set; } = null;

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;

    protected async Task HandleValidSubmit()
    {
        _errorMessage = null;
        _searchResult = null;
        _loading = true;

        _searchResult = Vehicle?.Registration != null ? 
            await VehicleDataService.GetVehicleDetailsAsync(Vehicle.Registration) : 
            throw new ArgumentNullException();

        if (_searchResult == null)
        {
            _errorMessage = "Vehicle not found. Please check the registration.";
        }
        //Thread.Sleep(3000); //handy to check the loading image is styled properly
        _loading = false;
    }

    protected void NavigateToHome()
    {
        NavigationManager.NavigateTo("/");
    }
}
