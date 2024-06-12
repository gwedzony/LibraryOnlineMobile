using System.Diagnostics;
using System.Text.Json;
using Database.Data.MobileApp;


namespace MauiApp1.Services;

public class MobileBookCardsService
{
  
    private readonly HttpClient _httpClient;
 
    public MobileBookCardsService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<LatestMobileBooksCard>?> GetItems()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            Debug.WriteLine($"Brak polaczenia");
            return null;
        }
        else
        {
            Debug.WriteLine($"Połaczony!");
        }

        var items = new List<LatestMobileBooksCard>();
        Uri uri = new Uri(Constants.ApiUrl, "api/MobileBookCards/");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                Debug.WriteLine("successs from mobilebookscards");
                string response = await responseMessage.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<List<LatestMobileBooksCard>>(response,new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
                });
            }

            else
            {
                Debug.WriteLine($"{responseMessage.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }


        return items;
    }
}