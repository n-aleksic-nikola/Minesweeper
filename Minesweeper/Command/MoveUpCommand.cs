using Minesweeper.Controller;

namespace Minesweeper.Command
{
    public class MoveUpCommand : ICommand
    {
        public void Execute(GameController controller)
        {
            controller.MoveCursor(-1, 0);
        }
    }
}
