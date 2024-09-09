namespace Minesweeper.Model
{
    public class Board
    {
        public Cell[,] Cells;
        public int Width { get; set; }
        public int Height { get; set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
        }
    }
}