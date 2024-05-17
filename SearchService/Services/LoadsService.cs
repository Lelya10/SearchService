using LoadsService;

namespace SearchService.Services;

public class LoadsService
{
    private readonly HttpClient _client = new();
    private readonly ILogger<LoadsService> _logger;

    public LoadsService(ILogger<LoadsService> logger)
    {
        _logger = logger;
    }
    
    public async Task<IEnumerable<LoadView>?> GetLoadsSearch(FilterForLoad filter)
    {
        try
        {
            var url = "http://localhost:5173/internal/loads/search";
            
            JsonContent content = JsonContent.Create(filter);
            using var response = await _client.PostAsync(url, content);

             if (!response.IsSuccessStatusCode)
             {
                 _logger.LogError("Получили плохой ответ при запросе к сервису Loads ");
                 return null;
             }
            
            return await response.Content.ReadFromJsonAsync<IEnumerable<LoadView>>();
        }
        catch (Exception e)
        {
            _logger.LogError("Произошла ошибка при запросе к сервису Loads " + e);
            return null;
        }
        
    }
}