namespace Maze.Interfaces;

/// <summary>
/// Интерфейс отрисовки игровых элементов
/// </summary>
public interface IRenderer
{
    /// <summary>
    /// Отрисовать лабиринт
    /// </summary>
    public void RenderMaze(Maze maze);
    
    /// <summary>
    /// Отрисовать главное меню
    /// </summary>
    public void RenderMenu(string[] items, int selectedIndex);
    
}