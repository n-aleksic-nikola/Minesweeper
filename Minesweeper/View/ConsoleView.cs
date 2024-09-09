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
                    var cell = board.GetCell(x, y);
                    if (cell.IsRevealed)
                    {
                        if (cell.IsMine)
                        {
                            Console.Write("* ");
                        }
                        else
                        {
                            Console.Write(". ");
                        }
                    }
                    else
                    {
                        Console.Write("# ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
