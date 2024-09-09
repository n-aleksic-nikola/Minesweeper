using Minesweeper.Controller;

namespace Minesweeper.Command
{
    public interface ICommand
    {
        void Execute(GameController controller);
    }
}
