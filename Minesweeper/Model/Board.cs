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
            InitializeCells();
        }

        public Cell GetCell(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                return Cells[x, y];
            }
            throw new ArgumentOutOfRangeException();
        }

        private void InitializeCells()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }
    }
}