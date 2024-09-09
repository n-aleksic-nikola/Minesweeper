using Minesweeper.Model;

namespace Minesweeper.View
{
    public class ConsoleView
    {
        public void DisplayBoard(Board board)
        {
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    Console.Write("# ");
                }
            }
        }
    }
}
