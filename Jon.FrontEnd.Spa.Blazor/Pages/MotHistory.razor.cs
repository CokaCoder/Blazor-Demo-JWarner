using Jon.FrontEnd.Spa.Blazor.Entities;
using Jon.FrontEnd.Spa.Blazor.State;
using Microsoft.AspNetCore.Components;

namespace Jon.FrontEnd.Spa.Blazor.Pages;

public partial class MotHistory
{
    [Inject]
    public required ApplicationState ApplicationState { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    public Vehicle? Vehicle { get; set; } = null;

    protected override void OnInitialized()
    {
        Vehicle = ApplicationState.SelectedVehicle;
    }
}
