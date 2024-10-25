namespace WEB_253502_BARANOVSKY.DOMAIN.Entities;


public class TourCategory
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public string? NormalizedName {get; set;}

    public ICollection<Tour> Tours { get; set; } = new List<Tour>();
}