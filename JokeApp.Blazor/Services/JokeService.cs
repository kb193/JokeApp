using JokeApp.Blazor.Contracts;
using JokeApp.Blazor.ViewModels;
using JokeApp.Domain.Entities;
using System.Text.Json;

namespace JokeApp.Blazor.Services
{
    public class JokeService : IJokeService
    {
        protected HttpClient _httpClient;
        public JokeService(HttpClient client)
        {
            this._httpClient = client;  
        }

        public async Task<Joke> GetAnyJoke()
        {
            var stringTask = _httpClient.GetStringAsync("https://v2.jokeapi.dev/joke/Any?safe-mode");
            var msg = await stringTask;

            var JokeObj = JsonSerializer.Deserialize<Joke>(msg);

            return JokeObj ?? new Joke();
        }
    }
}
