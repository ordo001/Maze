namespace Maze.Interfaces;

/// <summary>
/// Интерфейс сервиса лабиринта
/// </summary>
public interface IMazeService
{
    /// <summary>
    /// Сгенерировать лабиринт
    /// </summary>
    /// <returns></returns>
    public Maze GenerateMaze();
}