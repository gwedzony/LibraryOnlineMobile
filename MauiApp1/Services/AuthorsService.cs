using System.Diagnostics;
using System.Text.Json;
using Database.Data.MobileApp;

namespace MauiApp1.Services;

public class AuthorsService
{
    private readonly HttpClient _httpClient;

    public AuthorsService()
    {
        _httpClient = new HttpClient();
    }
    
    public async Task<List<MobileBooksAuthorCard?>>GetAuthorsCards()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var authorsList = new List<MobileBooksAuthorCard>();
        Uri uri = new Uri(Constants.ApiUrl, "api/LatestMobileBooksAuthorCard/");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                string items = await responseMessage.Content.ReadAsStringAsync();
                authorsList  = JsonSerializer.Deserialize<List<MobileBooksAuthorCard>>(items,new JsonSerializerOptions
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

        return authorsList;
    }
    
}