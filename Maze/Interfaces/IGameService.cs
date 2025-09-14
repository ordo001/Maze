namespace Maze.Interfaces;

/// <summary>
/// Интерфейс основного игрового сервиса
/// </summary>
public interface IGameService
{
    /// <summary>
    /// Инициализация и настройка игры
    /// </summary>
    public void InitializeGame();
    
    /// <summary>
    /// Начать игру
    /// </summary>
    public void StartGame();
    
    /// <summary>
    /// Завершение игры
    /// </summary>
    public void EndGame();
}