namespace travel_api.Module.Stores;
public class StoreConverter
{
    public static StoreResponseDto convertToResponse(Store store)
    {
        StoreResponseDto response = new StoreResponseDto();
        response.id = store.StoreId;
        response.name = store.Name;
        return response;
    }
}