namespace Maze;

/// <summary>
/// Статический класс с настройками игры
/// </summary>
public static class GameSettings
{
    /// <summary>
    /// Значение ширины лабиринта
    /// </summary>
    public static int Width { get; set; } = 10;

    /// <summary>
    /// Значение высоты лабиринта
    /// </summary>
    public static int Height { get; set; } = 10;

    /// <summary>
    /// Туман войны
    /// </summary>
    public static bool IsFogEnabled { get; set; } = false;

    /// <summary>
    /// Радиус тумана войны
    /// </summary>
    public static int FogRadius { get; set; } = 3;

    /// <summary>
    /// Поиск пути
    /// </summary>
    public static bool PathfinderEnabled { get; set; } = false;
}