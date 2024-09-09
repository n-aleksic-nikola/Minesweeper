using Minesweeper.Command;
using Minesweeper.Controller;
using Minesweeper.Model;
using Minesweeper.View;

Console.Write("Enter the starting row (0 to 9): ");
int startRow;
int.TryParse(Console.ReadLine(), out startRow);

Board board = new(10, 10);
board.PlaceMines();
ConsoleView view = new();

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

Console.ReadKey();