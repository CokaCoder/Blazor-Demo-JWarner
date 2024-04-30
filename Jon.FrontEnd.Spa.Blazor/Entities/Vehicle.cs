using System.ComponentModel.DataAnnotations;

namespace Jon.FrontEnd.Spa.Blazor.Entities;

public class Vehicle
{
    [Required(ErrorMessage = "Please enter a registration before searching.")]
    [RegularExpression(@"^(?=.{1,7})(([a-zA-Z]?){1,3}(\d){1,3}([a-zA-Z]?){1,3})$", ErrorMessage = "Please enter a valid UK registration, omitting any spaces.")]
    public string? Registration { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? FirstUsedDate { get; set; }
    public string? FuelType { get; set; }
    public string? PrimaryColour { get; set; }
    public Mottest[]? MotTests { get; set; }
}
