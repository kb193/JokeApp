using JokeApp.Domain.Entities;
using System.Text.Json;

public class Program
{
    private static readonly HttpClient client = new HttpClient();
    public async static Task Main()
    {
        client.DefaultRequestHeaders.Accept.Clear();

        var stringTask = client.GetStringAsync("https://v2.jokeapi.dev/joke/Any");
        var msg = await stringTask;

        var JokeObj = JsonSerializer.Deserialize<Joke>(msg);

        Console.Write(msg);
        Console.ReadLine();    
    }
}