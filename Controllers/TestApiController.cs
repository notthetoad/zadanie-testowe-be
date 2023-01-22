using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestApi.Models;

namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestApiController : ControllerBase
{
    private static HttpClient _sharedClient = new()
    {
        BaseAddress = new Uri("https://randomuser.me/api/")
    };

    [HttpGet()]
    public async Task<string> GetAsync()
    {
        using HttpResponseMessage response = await _sharedClient.GetAsync(""); 
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        return jsonResponse; 
    }
    
    [Route("/users/{n}")]
    [HttpGet()]
    public async Task<RandomUserSet> GetNUsers(int n)
    {
        using HttpResponseMessage response = await _sharedClient.GetAsync($"?results={n}"); 
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        RandomUserSet user = JsonSerializer.Deserialize<RandomUserSet>(jsonResponse);

        System.Console.WriteLine(jsonResponse);

        return user;
    }
}
