using TestApi.Models;
using System.Text.Json;

namespace TestApi.Services;

public class RandomUserService : IRandomUserService
{
    private static HttpClient _sharedClient = new()
    {
        BaseAddress = new Uri("https://randomuser.me/api/")
    };

    public async Task<RandomUserSet> GetRandomUserSet(int n)
    {
        using HttpResponseMessage response = await _sharedClient.GetAsync($"?results={n}"); 
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        RandomUserSet user = JsonSerializer.Deserialize<RandomUserSet>(jsonResponse);

        return user;
    }
}