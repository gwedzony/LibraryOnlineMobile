using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Database.Data.BookStructure;
using Database.Data.MobileApp;

namespace MauiApp1.Services;

public class BookcaseService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions? _serializerOptions;


    public BookcaseService()
    {
        _httpClient = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //PropertyNameCaseInsensitive = true,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
        };
    }

    public async Task<Bookcase> GetItem()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var bookcase = new Bookcase();
        try
        {
            Uri uri = new Uri(Constants.ApiUrl, "api/Bookcase/1");
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);

            if (responseMessage.IsSuccessStatusCode)
            {
                Debug.WriteLine("successs from bookcaseservice");
                string response = await responseMessage.Content.ReadAsStringAsync();
                bookcase = JsonSerializer.Deserialize<Bookcase>(response, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }


        return bookcase;
    }

    public async Task SaveToBookcaseAsync(Bookcase? bookcase)
    {
        string json = null;
        Uri uri = new Uri(Constants.ApiUrl, "api/Bookcase/1");
        try
        {
            json = JsonSerializer.Serialize(bookcase, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            Debug.WriteLine(content.ReadAsStringAsync().Result);

            HttpResponseMessage response = await _httpClient.PutAsync(uri, content);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task DeleteTodoItemAsync(int id)
    {
        Uri uri = new Uri(Constants.ApiUrl, $"api/Bookcase/{id}");

        try
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
                Debug.WriteLine(@"ksiazka zostala usunieta");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }
}