using Blazored.LocalStorage;
using JokeApp.Blazor.Contracts;
using JokeApp.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace JokeApp.Blazor.Pages
{
    public partial class MyJokes
    {
        [Inject]
        private IJokeService JokeService { get; set; }

        [Inject]
        private ILocalStorageService _localStorageService { get; set; }

        private List<Joke> Jokes { get; set; } = new();

        private Joke? ActiveJoke { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Jokes = await _localStorageService.GetItemAsync<List<Joke>>("JokeApp.Joke");

            ActiveJoke = Jokes.First();
        }

        private void OnClickRow(Joke joke)
        {
            ActiveJoke = joke;
        }

        private async void DeleteJoke(Joke joke)
        {
            Jokes.Remove(joke);

            ActiveJoke = Jokes.FirstOrDefault();

            await _localStorageService.SetItemAsync("JokeApp.Joke", Jokes);
        }
    }
}
