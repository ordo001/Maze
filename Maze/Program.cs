using Maze.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Maze;

public static class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.Configure();
        var provider = services.BuildServiceProvider();

        var game = provider.GetRequiredService<IGameService>();

        game.InitializeGame();
        game.StartGame();

        Console.ReadKey();
    }
}