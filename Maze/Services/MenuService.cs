using Maze.Interfaces;

namespace Maze;

/// <summary>
/// Сервис главного меню
/// </summary>
public class MenuService : IMenuService
{
    private readonly IRenderer renderer;
    private bool Exit = false;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="renderer"></param>
    public MenuService(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public void ShowMainMenu()
    {
        while (!Exit)
        {
            string[] items =
            {
                "Начать игру",
                $"Изменить ширину (Сейчас: {GameSettings.Width})",
                $"Изменить высоту (Сейчас: {GameSettings.Height})",
                GameSettings.IsFogEnabled ? "Выключить туман войны" : "Включить туман войны",
                "Выход"
            };
            int selectedIndex = 0;
            bool exit = false;

            Console.Clear();
            renderer.RenderMenu(items, selectedIndex);

            var key = Console.ReadLine();
            switch (key)
            {
                case "1":
                    selectedIndex = 0;
                    Console.Clear();
                    HandleMenuChoice(selectedIndex);
                    break;

                case "2":
                    selectedIndex = 1;
                    Console.Clear();
                    HandleMenuChoice(selectedIndex);
                    break;
                case "3":
                    selectedIndex = 2;
                    Console.Clear();
                    HandleMenuChoice(selectedIndex);
                    break;
                case "4":
                    selectedIndex = 3;
                    Console.Clear();
                    HandleMenuChoice(selectedIndex);
                    break;
                case "5":
                    selectedIndex = 4;
                    Console.Clear();
                    HandleMenuChoice(selectedIndex);
                    break;
                case "6":
                    selectedIndex = 5;
                    Console.Clear();
                    HandleMenuChoice(selectedIndex);
                    break;
            }
        }
    }

    private void HandleMenuChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                Exit = true;
                break;

            case 1:
                Console.Write("Введите ширину: ");
                if (int.TryParse(Console.ReadLine(), out int width))
                    GameSettings.Width = width;
                break;

            case 2:
                Console.Write("Введите высоту: ");
                if (int.TryParse(Console.ReadLine(), out int height))
                    GameSettings.Height = height;
                break;

            case 3:
                GameSettings.IsFogEnabled = !GameSettings.IsFogEnabled;
                break;

            case 4:
                GameSettings.PathfinderEnabled = !GameSettings.PathfinderEnabled;
                break;

            case 5:
                Environment.Exit(0);
                break;
        }
    }
}