using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using Database.Data.MobileApp;
using MauiApp1.Model;
using MauiApp1.Model.DTO;

namespace MauiApp1.Services;

public class BooksService
{
  
    private readonly HttpClient _httpClient;
 
    public BooksService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<LatestMobileBooksCard>?> GetItems()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var items = new List<LatestMobileBooksCard>();
        Uri uri = new Uri(Constants.ApiUrl, "api/LatestBooksCard/");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                Debug.WriteLine("successs from bookservice");
                string response = await responseMessage.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<List<LatestMobileBooksCard>>(response,new JsonSerializerOptions
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


        return items;
    }
}