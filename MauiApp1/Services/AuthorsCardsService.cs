using System.Diagnostics;
using System.Text.Json;
using Database.Data.MobileApp;

namespace MauiApp1.Services;

public class AuthorsCardsService
{
    private readonly HttpClient _httpClient;

    public AuthorsCardsService()
    {
        _httpClient = new HttpClient();
    }
    
    public async Task<List<MobileBooksAuthorCard?>>GetItems()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var items = new List<MobileBooksAuthorCard>();
        Uri uri = new Uri(Constants.ApiUrl, "api/AuthorsCards/");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                string response = await responseMessage.Content.ReadAsStringAsync();
                items  = JsonSerializer.Deserialize<List<MobileBooksAuthorCard>>(response,new JsonSerializerOptions
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