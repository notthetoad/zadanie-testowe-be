using TestApi.Models;
using System.Text.Json;

namespace TestApi.Services;

public class RandomUserService : IRandomUserService
{
    private static HttpClient _sharedClient = new()
    {
        BaseAddress = new Uri("https://randomuser.me/api/")
    };

    public async Task<RandomUserSet> GetRandomUserSet(int numberOfUsers)
    {
        if (numberOfUsers < 1)
        {
            return new RandomUserSet();
        }
        using HttpResponseMessage response = await _sharedClient.GetAsync($"?results={numberOfUsers}"); 
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        RandomUserSet? user = JsonSerializer.Deserialize<RandomUserSet>(jsonResponse);

        return user!;
    }
}