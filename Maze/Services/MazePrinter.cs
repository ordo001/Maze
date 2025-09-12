namespace Maze;

/// <summary>
/// Класс для отрисовки лабиринта
/// </summary>
public class MazePrinter
{
    private const int FogRadius = 3;
    
    
    private int _playerX = 0;
    private int _playerY = 0;
    private Maze _maze;
    private int _width;
    private int _height;
    private bool _isFogEnabled = false;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="maze"></param>
    public MazePrinter(Maze maze)
    {
        _maze = maze;
        
        _width = maze.GetAllCells().Max(c => c.X) + 1;
        _height = maze.GetAllCells().Max(c => c.Y) + 1;
    }

    /// <summary>
    /// Отрисовка лабиринта
    /// </summary>
    public void Render()
    {
        int width = _maze.Width;
        int height = _maze.Height;

        int displayWidth = width * 2 + 1;
        int displayHeight = height * 2 + 1;

        char[,] output = new char[displayHeight, displayWidth];

        for (int y = 0; y < displayHeight; y++)
        {
            for (int x = 0; x < displayWidth; x++)
            {
                if (((x / 2 - _playerX) * (x / 2 - _playerX) + (y / 2 - _playerY) * (y / 2 - _playerY) <= FogRadius * FogRadius) || _isFogEnabled) 
                    output[y, x] = '\u2593';
                else 
                    output[y, x] = ' ';
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var cell = _maze.GetCell(x, y)!;

                int cx = x * 2 + 1;
                int cy = y * 2 + 1;

                output[cy, cx] = ' ';
                
                output[cy, cx] = _playerX == x && _playerY == y ? 'O' : ' ';

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
        
        for (int y = 0; y < displayHeight; y++)
        {
            for (int x = 0; x < displayWidth; x++)
                Console.Write(output[y, x]);
            Console.WriteLine();
        }
        
        Console.WriteLine();
        Console.WriteLine("Включить/выключить туман войны - F2");
    }

    /// <summary>
    /// Проверка условия выхода из лабиринта
    /// </summary>
    /// <returns></returns>
    public bool IsAtExit()
    {
        return _playerX == _width - 1 && _playerY == _height;
    }

    /// <summary>
    /// Движение персонажа
    /// </summary>
    /// <param name="key">Клавиша</param>
    public void Move(ConsoleKey key)
    {
        var cell = _maze.GetCell(_playerX, _playerY)!;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (!cell.Walls[Direction.Up] && _playerY > 0)
                    _playerY--;
                break;

            case ConsoleKey.DownArrow:
                if (_playerX == _width - 1 && _playerY == _height - 1 && !cell.Walls[Direction.Down])
                {
                    _playerY++;
                }
                else if (!cell.Walls[Direction.Down])
                {
                    _playerY++;
                }
                break;

            case ConsoleKey.LeftArrow:
                if (!cell.Walls[Direction.Left])
                    _playerX--;
                break;

            case ConsoleKey.RightArrow:
                if (!cell.Walls[Direction.Right])
                    _playerX++;
                break;
        }
    }

    /// <summary>
    /// Функционал меню
    /// </summary>
    /// <param name="key">Клавиша</param>
    public void MenuFunctionality(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.F2:
                if(_isFogEnabled)
                    _isFogEnabled = false;
                else
                    _isFogEnabled = true;
                break;
        }
    }
}