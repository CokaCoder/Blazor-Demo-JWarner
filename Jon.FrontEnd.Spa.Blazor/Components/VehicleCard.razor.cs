using Jon.FrontEnd.Spa.Blazor.Entities;
using Jon.FrontEnd.Spa.Blazor.State;
using Microsoft.AspNetCore.Components;

namespace Jon.FrontEnd.Spa.Blazor.Components;

public partial class VehicleCard
{
    [Inject]
    public required ApplicationState ApplicationState { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    public Vehicle? Vehicle { get; set; }

    private Vehicle? _vehicle;

    protected override void OnParametersSet()
    {
        _vehicle = Vehicle;
    }

    public void Close()
    {
        _vehicle = null;
    }

    public void NavigateToDetails(Vehicle _vehicle)
    {
        //put current vehicle in state, to be picked up in details component.
        ApplicationState.SelectedVehicle = _vehicle;

        NavigationManager.NavigateTo($"/mothistory");
    }
}
