using System.ComponentModel.DataAnnotations;

namespace travel_api.Module.Stores;

public class StoresRequestDto
{
    public int? page { get; set; }
    public int? perPage { get; set; }
}

public class StoreRequestDto
{
    [Required]
    public string name { get; set; }
}