using System.Diagnostics;
using System.Text.Json;
using Database.Data.BookStructure;
using Database.Data.MobileApp;

namespace MauiApp1.Services;

public class BookcaseService
{
    private readonly HttpClient _httpClient;

    public BookcaseService()
    {
        _httpClient = new HttpClient();
    }
    
    public async Task<Bookcase?> GetItem()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var item = new Bookcase(){Name = "Bookcase"};
        Uri uri = new Uri(Constants.ApiUrl, "api/Bookcase/1");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                Debug.WriteLine("successs from bookcaseservice");
                string response = await responseMessage.Content.ReadAsStringAsync();
                item = JsonSerializer.Deserialize<Bookcase>(response,new JsonSerializerOptions
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
    
    
    
