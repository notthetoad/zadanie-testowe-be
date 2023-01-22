using TestApi.Models;

namespace TestApi.Services;

public interface IRandomUserService
{
    public Task<RandomUserSet> GetRandomUserSet(int n);
}