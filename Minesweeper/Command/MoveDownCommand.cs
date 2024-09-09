using Minesweeper.Controller;

namespace Minesweeper.Command
{
    public class MoveDownCommand : ICommand
    {
        public void Execute(GameController controller)
        {
            controller.MoveCursor(1, 0);
        }
    }
}