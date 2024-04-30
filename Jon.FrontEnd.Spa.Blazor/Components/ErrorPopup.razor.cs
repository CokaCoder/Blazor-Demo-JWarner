using Microsoft.AspNetCore.Components;

namespace Jon.FrontEnd.Spa.Blazor.Components;

public partial class ErrorPopup
{
    private string? _errorMessage;

    [Parameter]
    public string? ErrorMessage { get; set; }

    protected override void OnParametersSet()
    {
        _errorMessage = ErrorMessage;
    }

    public void Close()
    {
        _errorMessage = null;
    }
}
