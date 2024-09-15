namespace Physiqube.API.Filters;

public class Error
{
    public int StatusCode {get; set;}
    public string? StatusPhrase { get; set;}
    public DateTime Timestamp { get; set; }
}