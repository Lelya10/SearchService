using LoadsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace SearchService.Controllers;

[ApiController]
[Authorize]
[Route("search")]
public class SearchController : ControllerBase
{
    private readonly ILogger<SearchController> _logger;
    private readonly Services.LoadsService _loadsService;

    public SearchController(ILogger<SearchController> logger, Services.LoadsService loadsService)
    {
        _logger = logger;
        _loadsService = loadsService;
    }
    
    
    [HttpPost]
    public async Task<IResult> SearchLoads(FilterForLoad filter)
    {
        try
        {
            if (filter.LoadingCity != null) filter.LoadingCityId = Cities.GetCityId(filter.LoadingCity);
            if (filter.UnloadingCity != null) filter.UnloadingCityId = Cities.GetCityId(filter.UnloadingCity);
            var res = await _loadsService.GetLoadsSearch(filter);
            
            if (res == null) return Results.StatusCode(500);
            return  Results.Json(res);
        }
        catch (Exception e)
        {
            _logger.LogError("Ошибка при выполнении запроса: " + e);
            return Results.StatusCode(500);
        }
    }
}