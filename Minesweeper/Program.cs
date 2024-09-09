using Minesweeper.Controller;
using Minesweeper.Model;
using Minesweeper.View;

Board board = new(10, 10);
ConsoleView view = new();
GameController controller = new(board, view);
Console.ReadKey();