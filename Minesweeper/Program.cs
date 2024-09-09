using Minesweeper.Command;
using Minesweeper.Controller;
using Minesweeper.Model;
using Minesweeper.View;

do
{
    Console.Clear();
    StartGame();
}
while (AskToStartNewGame());

static void StartGame()
{
    Board board = new(10, 10);
    board.PlaceMines();
    ConsoleView view = new();

    int startRow = GetValidStartRow();

    GameController controller = new(board, view, startRow);

    while (!controller.IsGameWon())
    {
        ConsoleKey key = Console.ReadKey(true).Key;
        ICommand? command = null;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                command = new MoveUpCommand();
                break;
            case ConsoleKey.DownArrow:
                command = new MoveDownCommand();
                break;
            case ConsoleKey.LeftArrow:
                command = new MoveLeftCommand();
                break;
            case ConsoleKey.RightArrow:
                command = new MoveRightCommand();
                break;
        }

        if (command != null)
        {
            controller.ExecuteCommand(command);
        }
    }

    static int GetValidStartRow()
    {
        int startRow;
        Console.Write("Enter the starting row (0 to 9): ");

        while (!int.TryParse(Console.ReadLine(), out startRow) || startRow < 0 || startRow > 9)
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 9.");
            Console.Write("Enter the starting row (0 to 9): ");
        }

        return startRow;
    }
}

static bool AskToStartNewGame()
{
    Console.Write("Do you want to start a new game? (y/n): ");
    string? response = Console.ReadLine()?.Trim().ToLower();

    if (string.IsNullOrEmpty(response))
    {
        return false;
    }

    return response == "y" || response == "yes";
}