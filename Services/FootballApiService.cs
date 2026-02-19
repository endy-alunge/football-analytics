using System.Net.Http.Headers;
using System.Text.Json;

public class FootballApiService
{
    private readonly HttpClient _httpClient;

    public FootballApiService()
    {
        _httpClient = new HttpClient();
        // _httpClient.DefaultRequestHeaders.Add("x-apisports-key", "4b026970a0914e5389b8d8987108736a");
        // _httpClient.DefaultRequestHeaders.Add("x-apisports-host", "v3.football.api-sports.io"); 

        _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "e7bc94463bmsh141eac47ea7a4cfp1ee7f6jsna8944625625");
        _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "api-football-v1.p.rapidapi.com");


    }

    public async Task<string> GetLastFiveMatches(string teamId)
    {
        string url = "https://api-football-v1.p.rapidapi.com";
        var response = await _httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}