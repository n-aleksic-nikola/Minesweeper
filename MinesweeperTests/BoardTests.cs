using System;
using Xunit;
using Minesweeper.Model;

namespace MinesweeperTests
{
    public class BoardTests
    {
        [Fact]
        public void PlaceMines_ShouldPlaceMinesInThirtyPercentOfCells()
        {
            var board = new Board(10, 10);

            board.PlaceMines();

            int mineCount = 0;
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (board.GetCell(x, y).IsMine)
                    {
                        mineCount++;
                    }
                }
            }

            Assert.Equal(30, mineCount);
        }

        [Fact]
        public void RevealCell_ShouldReturnTrueIfMineIsRevealed()
        {
            var board = new Board(5, 5);
            board.PlaceMines();
            var (x, y) = GetMineCell(board);

            bool? result = board.RevealCell(x, y);

            Assert.True(result);
        }

        private static (int x, int y) GetMineCell(Board board)
        {
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (board.GetCell(x, y).IsMine)
                    {
                        return (x, y);
                    }
                }
            }
            throw new Exception("No mines found on board!");
        }
    }
}