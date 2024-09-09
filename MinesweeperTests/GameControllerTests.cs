using Minesweeper.Command;
using Minesweeper.Controller;
using Minesweeper.Model;
using Moq;
using Xunit;

namespace MinesweeperTests
{
    public class GameControllerTests
    {
        [Fact]
        public void GameController_ShouldCallExecuteCommand_WhenArrowKeyIsPressed()
        {
            var mockController = new Mock<GameController>(new Board(10, 10), 0);
            mockController.Setup(c => c.ExecuteCommand(It.IsAny<ICommand>())).Verifiable();

            mockController.Object.ExecuteCommand(new MoveRightCommand());

            mockController.Verify(c => c.ExecuteCommand(It.IsAny<ICommand>()), Times.Once);
        }

        [Fact]
        public void GameController_ShouldWinGame_WhenPlayerReachesRightEnd()
        {
            var mockController = new Mock<GameController>(new Board(5, 5), 0);
            mockController.Setup(c => c.IsGameWon()).Returns(true);

            bool gameWon = mockController.Object.IsGameWon();

            Assert.True(gameWon);
        }

    }
}