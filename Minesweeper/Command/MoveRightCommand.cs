using Minesweeper.Controller;

namespace Minesweeper.Command
{
    public class MoveRightCommand : ICommand
    {
        public void Execute(GameController controller)
        {
            controller.MoveCursor(0, 1);
        }
    }
}