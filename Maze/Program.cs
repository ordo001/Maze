namespace Maze;

class Program
{
    static void Main(string[] args)
    {
        var mazeGenerator = new MazeGenerator();

        var maze = mazeGenerator.Generate(10, 10);
        
        var renderer = new MazePrinter(maze); 

        while (!renderer.IsAtExit())
        {
            renderer.Render();
            var key = Console.ReadKey(true).Key;
            renderer.Move(key);
            renderer.MenuFunctionality(key);
            Console.Clear(); 
            
        }
        Console.Clear();
        Console.WriteLine("Ты выиграл, красава!");
        
        Console.ReadKey();
    }
}