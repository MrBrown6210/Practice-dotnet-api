namespace travel_api.Module.Stores;
public class StoreRepositoty
{

    private readonly StoreContext _context;
    public StoreRepositoty(StoreContext context)
    {
        _context = context;
    }

    public async Task<Store> Add(StoreRequestDto dto)
    {
        var store = new Store();
        store.Name = dto.name;
        var create = _context.Stores.Add(store);
        await _context.SaveChangesAsync();
        return create.Entity;
    }

    public List<Store> GetList(StoresRequestDto dto)
    {
        int page = dto.page ?? 1;
        int perPage = dto.perPage ?? 10;
        var result = _context.Stores
        .OrderBy(store => store.StoreId)
        .Skip(page - 1)
        .Take(perPage)
        .ToList();
        return result;
    }

    public async Task<StoreProduct> AddProductToStore()
    {
        StoreProduct storeProduct = new StoreProduct();
        storeProduct.Price = 100;
        _context.StoreProducts.Add(storeProduct);
        await _context.SaveChangesAsync();
        return storeProduct;
    }
}