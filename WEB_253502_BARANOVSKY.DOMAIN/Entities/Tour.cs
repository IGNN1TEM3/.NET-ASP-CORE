namespace WEB_253502_BARANOVSKY.DOMAIN.Entities;

public class Tour
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public required string Description {get; set;}
    public decimal Price {get; set;}
    public string? ImagePath {get; set;}
    public string? MimeString {get; set;}
    public int? CategoryId {get; set;}
}