using Microsoft.AspNetCore.Components;

namespace Jon.FrontEnd.Spa.Blazor.Components;

public partial class BusyIndicator
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool Busy { get; set; }

    private bool _busy;

    protected override void OnParametersSet()
    {
        _busy = Busy;
    }
}
