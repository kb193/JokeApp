using JokeApp.Domain.Entities;

namespace JokeApp.Blazor.Contracts
{
    public interface IJokeService
    {
        Task<Joke> GetAnyJoke();
    }
}
