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
        private int score = 1;
        private int lives = 3;
        private bool gameWon = false;

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

        public virtual void MoveCursor(int dx, int dy)
        {
            int newX = currentX + dx;
            int newY = currentY + dy;

            if (newX >= 0 && newX < _board.Width && newY >= 0 && newY < _board.Height)
            {
                currentX = newX;
                currentY = newY;

                score++;

                var hitMine = _board.RevealCell(currentX, currentY);
                if (hitMine == true && hitMine != null)
                {
                    lives--;
                    Console.WriteLine("Oops! You hit a mine.");

                    if (lives <= 0)
                    {
                        gameWon = true;
                        Console.WriteLine("Game over!");
                        return;
                    }
                }
            }
        }

        public void ExecuteCommand(ICommand command)
        {
            if (gameWon)
            {
                Console.WriteLine("You've already won the game!");
                return;
            }

            command.Execute(this);

            if (currentY == _board.Width - 1)
            {
                gameWon = true;
                Console.WriteLine("Congratulations! You've won the game by reaching the right end of the board.");
            }

            DisplayStats();
        }

        private void DisplayStats()
        {
            Console.WriteLine($"\nScore: {score} | Lives left: {lives}");

            Console.WriteLine($"Current position: row {currentX} column {currentY}");

            _view.DisplayBoard(_board);
        }

        private void RevealAndDisplayInitialCell()
        {
            var hitMine = _board.RevealCell(currentX, currentY);

            if (hitMine == true)
            {
                lives--;
                Console.WriteLine("Oops! You hit a mine.");
            }

            DisplayStats();
        }

        public bool IsGameWon()
        {
            return gameWon;
        }
    }
}
