using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
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

    [Route("/users/{numberOfUsers}")]
    [HttpGet()]
    public async Task<RandomUserSet> GetRandomUserSet(int numberOfUsers)
    {
        return await _service.GetRandomUserSet(numberOfUsers);
    }
}
