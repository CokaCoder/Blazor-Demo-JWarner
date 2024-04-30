namespace ProxyServer.DomainEntities;

public class Mottest
{
    public DateTime? CompletedDate { get; set; }
    public string? TestResult { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? OdometerValue { get; set; }
    public string? OdometerUnit { get; set; }
    public string? MotTestNumber { get; set; }
    public Rfrandcomment[]? RfrAndComments { get; set; }
}
