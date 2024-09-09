using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using Minesweeper.View;

namespace Minesweeper.Controller
{
    public class GameController
    {
        private Board board;
        private ConsoleView view;

        public GameController(
            Board board,
            ConsoleView view)
        {
            board = board;
            view = view;
        }
    }
}
