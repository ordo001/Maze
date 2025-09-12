namespace Maze;

/// <summary>
/// Клетка лабиринта
/// </summary>
public class Cell
{
    /// <summary>
    /// Координата клетки по X
    /// </summary>
    public int X { get; set; }
    
    /// <summary>
    /// Координата клетки по Y
    /// </summary>
    public int Y { get; set; }
    
    /// <summary>
    /// Посещена ли клетка
    /// </summary>
    public bool Visited { get; set; } = false;

    /// <summary>
    /// Наличие стены у клетки
    /// </summary>
    public Dictionary<Direction, bool> Walls { get; set; } = new Dictionary<Direction, bool>
    {
        { Direction.Up, true },
        { Direction.Down, true },
        { Direction.Right, true },
        { Direction.Left, true }
    };

    /// <summary>
    /// Метод удаление стены
    /// </summary>
    /// <param name="direction">Направление стены</param>
    public void RemoveWall(Direction direction)
    {
        Walls[direction] = false;
    }
}