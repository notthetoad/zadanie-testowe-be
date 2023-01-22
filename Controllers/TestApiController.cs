using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TestApi.Models;
// TODO Change services to repository
using TestApi.Services;

namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestApiController : ControllerBase
{
    private IRandomUserService _service;
    public TestApiController(IRandomUserService service)
    {
        _service = service;
    }

    [Route("/users/{n}")]
    [HttpGet()]
    public async Task<RandomUserSet> GetRandomUserSet(int n)
    {
        return await _service.GetRandomUserSet(n);
    }
}
