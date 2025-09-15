namespace Maze;

/// <summary>
/// Класс лабиринта
/// </summary>
public class Maze
{
    /// <summary>
    /// Ширина
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Высота
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Игрок в лабиринте
    /// </summary>
    public Player Player { get; set; }

    private Cell[,] MazeCells { get; }

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="width">Ширина</param>
    /// <param name="height">Высота</param>
    public Maze(int width, int height)
    {
        Width = width;
        Height = height;

        Player = new Player();
        MazeCells = new Cell[width, height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                MazeCells[x, y] = new Cell { X = x, Y = y };
            }
        }
    }

    /// <summary>
    /// Получить ячейку по координатам
    /// </summary>
    /// <returns></returns>
    public Cell? GetCell(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return null;

        return MazeCells[x, y];
    }

    /// <summary>
    /// Получить противоположное направление
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Direction GetReversDirection(Direction direction)
    {
        return direction switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    /// <summary>
    /// Получить соседние клетки
    /// </summary>
    /// <param name="cell"></param>
    /// <returns></returns>
    public IEnumerable<(Cell cell, Direction direction)> GetNeighbours(Cell cell)
    {
        var up = GetCell(cell.X, cell.Y - 1);
        if (up != null)
            yield return (up, Direction.Up);

        var down = GetCell(cell.X, cell.Y + 1);
        if (down != null)
            yield return (down, Direction.Down);

        var left = GetCell(cell.X - 1, cell.Y);
        if (left != null)
            yield return (left, Direction.Left);

        var right = GetCell(cell.X + 1, cell.Y);
        if (right != null)
            yield return (right, Direction.Right);
    }

    /// <summary>
    /// Удалить стену у двух соседних клеток
    /// </summary>
    /// <param name="currentCell">Текущая клетка</param>
    /// <param name="nextCell">Соседняя</param>
    /// <param name="direction">Направление</param>
    public void RemoveWall(Cell currentCell, Cell nextCell, Direction direction)
    {
        currentCell.RemoveWall(direction);
        nextCell.RemoveWall(GetReversDirection(direction));
    }

    /// <summary>
    /// Получить все клетки лабиринта
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Cell> GetAllCells()
    {
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                yield return MazeCells[i, j];
            }
        }
    }
}

// #######
// # # # #
// #######
// # # # #
// #######