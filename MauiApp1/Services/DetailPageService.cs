using System.Diagnostics;
using System.Text.Json;
using Database.Data.MobileApp;

namespace MauiApp1.Services;

public class DetailPageService
{
    
    private readonly HttpClient _httpClient;
 
    public DetailPageService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<DetailBookMobilePage?> GetItem(int id)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var item = new DetailBookMobilePage();
        Uri uri = new Uri(Constants.ApiUrl, $"api/Details/{id}");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
               Debug.WriteLine("success from details");
                string response = await responseMessage.Content.ReadAsStringAsync();
                item = JsonSerializer.Deserialize<DetailBookMobilePage>(response,new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
                });
               
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return item;
    }
}