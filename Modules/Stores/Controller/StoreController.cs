using Microsoft.AspNetCore.Mvc;

namespace travel_api.Module.Stores;

[Route("stores")]
[Produces("application/json")]
public class StoreController : ControllerBase
{

    private readonly ILogger<StoreController> logger;
    private readonly StoreRepository repositoty;

    public StoreController(ILogger<StoreController> logger)
    {
        this.logger = logger;
        this.repositoty = new StoreRepository(new StoreContext());
    }

    [HttpGet()]
    public List<StoreResponseDto> GetAll([FromQuery] StoresRequestDto dto)
    {
        logger.LogDebug("hello");
        List<Store> stores = repositoty.GetList(dto);
        return stores.Select(store => StoreConverter.convertToResponse(store)).ToList();
    }

    [HttpPost]
    public async Task<StoreResponseDto> Add([FromBody] StoreRequestDto dto)
    {
        var store = await repositoty.Add(dto);
        return StoreConverter.convertToResponse(store);
    }

    [HttpPost("{id}/product")]
    public async void AddProductToStore()
    {
        throw new NotImplementedException();
    }
}