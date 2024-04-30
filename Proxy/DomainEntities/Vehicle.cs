using System.ComponentModel.DataAnnotations;

namespace ProxyServer.DomainEntities;

public class Vehicle
{
    [Required]
    public string? Registration { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? FirstUsedDate { get; set; }
    public string? FuelType { get; set; }
    public string? PrimaryColour { get; set; }
    public Mottest[]? MotTests { get; set; }
}
