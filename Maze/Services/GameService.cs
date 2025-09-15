using Maze.Interfaces;

namespace Maze;

/// <summary>
/// Сервис игры
/// </summary>
public class GameService(IMazeService mazeService, IMenuService menuService, IRenderer renderer) : IGameService
{
    private readonly IMazeService MazeService = mazeService;
    private readonly IMenuService MenuService = menuService;
    private readonly IRenderer Renderer = renderer;
    private Maze MazeEntity;

    public void InitializeGame()
    {
        MenuService.ShowMainMenu();
        MazeEntity = MazeService.GenerateMaze();
    }

    public void StartGame()
    {
        while (!IsExit())
        {
            Renderer.RenderMaze(MazeEntity);
            var key = Console.ReadKey(true).Key;
            Move(key);
            Console.Clear();
        }

        EndGame();
    }

    private void Move(ConsoleKey key)
    {
        var cell = MazeEntity.GetCell(MazeEntity.Player.X, MazeEntity.Player.Y)!;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (!cell.Walls[Direction.Up] && MazeEntity.Player.Y > 0)
                    MazeEntity.Player.Y--;
                break;

            case ConsoleKey.DownArrow:
                if (MazeEntity.Player.X == MazeEntity.Width - 1 && MazeEntity.Player.Y == MazeEntity.Height - 1 &&
                    !cell.Walls[Direction.Down])
                {
                    MazeEntity.Player.Y++;
                }
                else if (!cell.Walls[Direction.Down])
                {
                    MazeEntity.Player.Y++;
                }

                break;

            case ConsoleKey.LeftArrow:
                if (!cell.Walls[Direction.Left])
                    MazeEntity.Player.X--;
                break;

            case ConsoleKey.RightArrow:
                if (!cell.Walls[Direction.Right])
                    MazeEntity.Player.X++;
                break;
        }
    }

    private bool IsExit()
    {
        return MazeEntity.Player.X == GameSettings.Width - 1 && MazeEntity.Player.Y == GameSettings.Height;
    }

    public void EndGame()
    {
        Console.Clear();
        Console.WriteLine("Ты выиграл, красава!");
    }
}