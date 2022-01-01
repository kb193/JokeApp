using Blazored.LocalStorage;
using JokeApp.Blazor.Contracts;
using JokeApp.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace JokeApp.Blazor.Pages
{
    public partial class Index
    {
        [Inject]
        private IJokeService JokeService { get; set; }

        [Inject]
        private ILocalStorageService _localStorageService { get; set; }

        private Joke Joke { get; set; } = new();

        private bool _saved { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GenerateJoke();
        }

        private async Task GenerateJoke()
        {
            _saved = false;
            Joke = await JokeService.GetAnyJoke();   
        }

        private async Task SaveJoke()
        {
           var Jokes =  await _localStorageService.GetItemAsync<List<Joke>>("JokeApp.Joke");

            if (Jokes is null)
            {
                Jokes = new List<Joke>();
            }

            Jokes.Add(Joke);

            await _localStorageService.SetItemAsync("JokeApp.Joke", Jokes);
            _saved = true;
        }
    }
}
