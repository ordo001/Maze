using Maze.Interfaces;

namespace Maze;

/// <summary>
/// Сервис лабиринта
/// </summary>
public class MazeService : IMazeService
{
    private Random _random = new Random();

    /// <summary>
    /// Сгенерировать лабиринт. Лабиринт генерируется случайным образом, основываясь на алгоритме DFS Backtracking
    /// </summary>
    /// <returns></returns>
    public Maze GenerateMaze()
    {
        var maze = new Maze(GameSettings.Width, GameSettings.Height);

        int startX = _random.Next(GameSettings.Width);
        int startY = _random.Next(GameSettings.Height);

        var startCell = maze.GetCell(startX, startY);
        startCell!.Visited = true;

        var stack = new Stack<Cell>();
        var currentCell = startCell;

        int visitedCount = 1;
        int totalCells = GameSettings.Width * GameSettings.Height;

        while (visitedCount < totalCells)
        {
            var unvisitedNeighbours = maze
                .GetNeighbours(currentCell)
                .Where(n => !n.cell.Visited)
                .ToList();

            if (unvisitedNeighbours.Count > 0)
            {
                var (nextCell, direction) = unvisitedNeighbours[_random.Next(unvisitedNeighbours.Count)];
                maze.RemoveWall(currentCell, nextCell, direction);

                stack.Push(currentCell);

                nextCell.Visited = true;
                visitedCount++;

                currentCell = nextCell;
            }
            else if (stack.Count > 0)
            {
                currentCell = stack.Pop();
            }
        }

        maze.GetCell(0, 0)!.Walls[Direction.Up] = false;
        maze.GetCell(GameSettings.Width - 1, GameSettings.Height - 1)!.Walls[Direction.Down] = false;

        return maze;
    }
}