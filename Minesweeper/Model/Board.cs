namespace Minesweeper.Model
{
    public class Board
    {
        public Cell[,] Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}