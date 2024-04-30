using Microsoft.AspNetCore.Components;

namespace Jon.FrontEnd.Spa.Blazor.Components;

public partial class ProfilePicture
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
