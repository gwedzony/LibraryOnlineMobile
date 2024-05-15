using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using Database.Data.MobileApp;
using MauiApp1.Model;
using MauiApp1.Model.DTO;

namespace MauiApp1.Services;

public class MobileBooksPreviewsService
{
    private readonly HttpClient _httpClient;

   

    public MobileBooksPreviewsService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<LatestMobileBooksCard>?> GetMobileBooksPreviews()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        var BookPreviewsList = new List<LatestMobileBooksCard>();
        Uri uri = new Uri(Constants.ApiUrl, "api/LatestBooksCard");

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                string items = await responseMessage.Content.ReadAsStringAsync();
                BookPreviewsList = JsonSerializer.Deserialize<List<LatestMobileBooksCard>>(items,new JsonSerializerOptions
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

        return BookPreviewsList;
    }
}