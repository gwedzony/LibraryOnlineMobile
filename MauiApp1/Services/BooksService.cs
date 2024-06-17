using System.Diagnostics;
using System.Text.Json;
using Database.Data.BookStructure;
using Database.Data.MobileApp;

namespace MauiApp1.Services;

public class BooksService
{
    private readonly HttpClient _httpClient;
 
    public BooksService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Book>?> GetItems()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var items = new List<Book>();
        Uri uri = new Uri(Constants.ApiUrl, "api/Books/");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                string response = await responseMessage.Content.ReadAsStringAsync();
                items = JsonSerializer.Deserialize<List<Book>>(response,new JsonSerializerOptions
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