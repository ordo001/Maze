using Maze.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Maze;

/// <summary>
/// Конфигурация сервисов
/// </summary>
public static class ConfigureServices
{
    /// <summary>
    /// Сконфигурировать сервисы
    /// </summary>
    /// <param name="services">DI контейнер</param>
    public static void Configure(this IServiceCollection services)
    {
        services.AddScoped<IRenderer, ConsoleRenderer>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<IMazeService, MazeService>();
        services.AddScoped<IMenuService, MenuService>();
    }
}