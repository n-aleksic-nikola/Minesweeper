namespace Minesweeper.Model
{
    public class Board
    {
        public Cell[,] Cells;
        public int Width { get; set; }
        public int Height { get; set; }
        private readonly Random _random = new();

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
            throw new ArgumentOutOfRangeException($"Cell at ({x},{y}) is out of bounds.");
        }

        public void PlaceMines()
        {
            int totalCells = Width * Height;
            int mineCount = (int)(totalCells * 0.30);

            for (int i = 0; i < mineCount; i++)
            {
                int x, y;
                do
                {
                    x = _random.Next(Width);
                    y = _random.Next(Height);
                }
                while (Cells[x, y].IsMine);

                Cells[x, y].IsMine = true;
            }
        }

        public bool? RevealCell(int x, int y)
        {
            if (Cells[x, y].IsRevealed) return null;

            Cells[x, y].IsRevealed = true;

            if (Cells[x, y].IsMine)
            {
                return true;
            }

            return false;
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