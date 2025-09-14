using Maze.Interfaces;

namespace Maze;

/// <summary>
/// Сервис по отрисовке игровых элементов в консоли
/// </summary>
public class ConsoleRenderer : IRenderer
{
    public void RenderMaze(Maze maze)
    {
        int width = maze.Width;
        int height = maze.Height;

        int displayWidth = width * 2 + 1;
        int displayHeight = height * 2 + 1;

        char[,] output = new char[displayHeight, displayWidth];

        for (int y = 0; y < displayHeight; y++)
        {
            for (int x = 0; x < displayWidth; x++)
            {
                if ((x / 2 - maze.Player.X) * (x / 2 - maze.Player.X) +
                    (y / 2 - maze.Player.Y) * (y / 2 - maze.Player.Y)
                    <= GameSettings.FogRadius * GameSettings.FogRadius || !GameSettings.IsFogEnabled)
                    output[y, x] = '\u2593';
                else
                    output[y, x] = ' ';
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var cell = maze.GetCell(x, y)!;

                int cx = x * 2 + 1;
                int cy = y * 2 + 1;

                output[cy, cx] = ' ';

                output[cy, cx] = maze.Player.X == x && maze.Player.Y == y ? 'O' : ' ';
                

                if (!cell.Walls[Direction.Up])
                    output[cy - 1, cx] = ' ';
                if (!cell.Walls[Direction.Down])
                    output[cy + 1, cx] = ' ';
                if (!cell.Walls[Direction.Left])
                    output[cy, cx - 1] = ' ';
                if (!cell.Walls[Direction.Right])
                    output[cy, cx + 1] = ' ';
            }
        }
        
        output[height * 2, width * 2 - 1] = 'E'; // выход типа

        for (int y = 0; y < displayHeight; y++)
        {
            for (int x = 0; x < displayWidth; x++)
            {
                Console.Write(output[y, x]);
            }

            Console.WriteLine();
        }
        
    }

    public void RenderMenu(string[] items, int selectedIndex)
    {
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }
    }
}