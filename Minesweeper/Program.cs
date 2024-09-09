using Minesweeper.Command;
using Minesweeper.Controller;
using Minesweeper.Model;
using Minesweeper.View;

Board board = new(10, 10);
ConsoleView view = new();

Console.Write("Enter the starting row (0 to 9): ");
int startRow;
int.TryParse(Console.ReadLine(), out startRow);

GameController controller = new(board, view, startRow);

view.DisplayBoard(board);

ConsoleKey key = Console.ReadKey(true).Key;
ICommand? command = null;

/*switch (key)
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
}*/

Console.ReadKey();