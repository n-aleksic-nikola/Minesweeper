using Minesweeper.Command;
using Minesweeper.Model;
using Minesweeper.View;

namespace Minesweeper.Controller
{
    public class GameController
    {
        private readonly Board _board;
        private readonly ConsoleView _view;
        private int currentX;
        private int currentY;

        public GameController(
            Board board,
            ConsoleView view,
            int startX)
        {
            _board = board;
            _view = view;

            currentX = startX;
            currentY = 0;

            RevealAndDisplayInitialCell();
        }

        public void MoveCursor(int dx, int dy)
        {
            int newX = currentX + dx;
            int newY = currentY + dy;

            if (newX >= 0 && newX < _board.Width && newY >= 0 && newY < _board.Height)
            {
                currentX = newX;
                currentY = newY;

                var hitMine = _board.RevealCell(currentX, currentY);
                if (hitMine == true)
                {
                    Console.WriteLine("Oops! You hit a mine.");
                }
            }
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute(this);
        }

        private void RevealAndDisplayInitialCell()
        {
            _board.RevealCell(currentX, currentY);
        }
    }
}
