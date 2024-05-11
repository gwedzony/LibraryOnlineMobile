using System.Net.Http.Json;
using MauiApp1.Model;
using MauiApp1.Model.DTO;

namespace MauiApp1.Services;

public class MobileBooksPreviewsService
{
    private readonly HttpClient _httpClient;

    public MobileBooksPreviewsService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.ApiUrl);
        
    }

    public async Task<MobileBookPreview> GetMobileBooksPreviews()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        return await _httpClient.GetFromJsonAsync<MobileBookPreview> ($"/api/BookPreview");
    }
    
}