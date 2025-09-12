namespace Maze;

/// <summary>
/// Генератор лабиринта. Лабиринт генерируется случайным образом, основываясь на алгоритме DFS Backtracking
/// </summary>
public class MazeGenerator
{
    private Random _random = new Random();

    /// <summary>
    /// Генерация лабиринта
    /// </summary>
    /// <param name="width">ширина</param>
    /// <param name="height">высота</param>
    /// <returns></returns>
    public Maze Generate(int width, int height)
    {
        var maze = new Maze(width, height);

        int startX = _random.Next(width);
        int startY = _random.Next(height);

        var startCell = maze.GetCell(startX, startY);
        startCell!.Visited = true;

        var stack = new Stack<Cell>();
        var currentCell = startCell;
        
        int visitedCount = 1;
        int totalCells = width * height;

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
        maze.GetCell(width - 1, height - 1)!.Walls[Direction.Down] = false;

        return maze;
    }
}