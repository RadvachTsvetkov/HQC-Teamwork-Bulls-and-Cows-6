namespace BullsAndCowsGame.Tests
{
    using System;
    using System.IO;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void GetScoreBoardAsString_EmptyScoreBoard_IfTopCommandWorksCorrectly()
        {
            // Prepair input
            var input = new StringBuilder();
            input.AppendLine("top");
            input.AppendLine("exit");

            // Prepair expected
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(ScoreBoard.SCOREBOARD_EMPTY);
            expectedOutput.Append(Environment.NewLine);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(BullsAndCows.EXIT_GAME);
            
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            BullsAndCows.Main();
            
            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetScoreBoardAsStringMethod_IfScoreBoardIsSortedCorrectly()
        {
            // Prepair input
            var input = new StringBuilder();
            int peshoAttempts = 1;
            input.AppendLine("2222");
            input.AppendLine("Pesho");
            int goshoAttempts = 3;
            input.AppendLine("2223");
            input.AppendLine("2223");
            input.AppendLine("2222");
            input.AppendLine("Gosho");
            int miroslavAttempts = 2;
            input.AppendLine("2223");
            input.AppendLine("2222");
            input.AppendLine("Miroslav");
            //input.AppendLine("top");
            input.AppendLine("exit");

            // Prepair expected
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(String.Format(BullsAndCows.CONGRATULATIONS_WITHOUT_CHEATS, peshoAttempts));
            expectedOutput.AppendLine(BullsAndCows.ASK_NAME_FOR_SCOREBOARD);
            expectedOutput.AppendLine(ScoreBoard.SCOREBOARD_TITLE);
            expectedOutput.AppendLine(String.Format(ScoreBoard.SCOREBOARD_INPUT_FORMAT, 1, "Pesho", peshoAttempts));
            expectedOutput.AppendLine();

            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine("Wrong number!  Bulls: 3, Cows: 0");
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine("Wrong number!  Bulls: 3, Cows: 0");
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(String.Format(BullsAndCows.CONGRATULATIONS_WITHOUT_CHEATS, goshoAttempts));
            expectedOutput.AppendLine(BullsAndCows.ASK_NAME_FOR_SCOREBOARD);
            expectedOutput.AppendLine(ScoreBoard.SCOREBOARD_TITLE);
            expectedOutput.AppendLine(String.Format(ScoreBoard.SCOREBOARD_INPUT_FORMAT, 1, "Pesho", peshoAttempts));
            expectedOutput.AppendLine(String.Format(ScoreBoard.SCOREBOARD_INPUT_FORMAT, 2, "Gosho", goshoAttempts));
            expectedOutput.AppendLine();

            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine("Wrong number!  Bulls: 3, Cows: 0");
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(String.Format(BullsAndCows.CONGRATULATIONS_WITHOUT_CHEATS, miroslavAttempts));
            expectedOutput.AppendLine(BullsAndCows.ASK_NAME_FOR_SCOREBOARD);
            expectedOutput.AppendLine(ScoreBoard.SCOREBOARD_TITLE);
            expectedOutput.AppendLine(String.Format(ScoreBoard.SCOREBOARD_INPUT_FORMAT, 1, "Pesho", peshoAttempts));
            expectedOutput.AppendLine(String.Format(ScoreBoard.SCOREBOARD_INPUT_FORMAT, 2, "Miroslav", miroslavAttempts));
            expectedOutput.AppendLine(String.Format(ScoreBoard.SCOREBOARD_INPUT_FORMAT, 3, "Gosho", goshoAttempts));
            expectedOutput.AppendLine();

            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(BullsAndCows.EXIT_GAME);
            // Redirect Console
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // mock
            var mockedNumber = Mock.Create<IRandomNumberProvider>();
            Mock.Arrange(() => mockedNumber.GetRandomNumber(0, 10)).Returns(2);
            BullsAndCows game = new BullsAndCows(mockedNumber);
            game.StartGame();

            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}