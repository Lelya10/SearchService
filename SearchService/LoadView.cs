namespace SearchService;

public class LoadView
{
    public Guid Id { get; set; }
    
    public Guid FirmId { get; set; }

    public DateTime UpdateTime { get; set; }

    public string Name { get; set; }
    
    public float Weight { get; set; }
    
    public float Volume { get; set; }
    
    public int LoadingCityId { get; set; }
    
    public int UnloadingCityId { get; set; }
    
    public DateTime LoadingTime { get; set; }
    
    public DateTime UnloadingTime { get; set; }
    
    public double Price { get; set; }
    
}