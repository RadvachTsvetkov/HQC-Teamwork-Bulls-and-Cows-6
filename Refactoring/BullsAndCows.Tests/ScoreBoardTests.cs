using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class ScoreBoardTests
    {
        [TestMethod]
        public void MainMethod_EmptyScoreBoard_IfTopCommandWorksCorrectly()
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
            expectedOutput.AppendLine(Environment.NewLine);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(BullsAndCows.EXIT_GAME);
            // input.....
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            BullsAndCows.Main();
            
            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            StringAssert.Equals(expected, actual);
        }

        [TestMethod]
        public void MainMethod_IfRestartCommandWorksCorrectly()
        {
            // Prepair input
            var input = new StringBuilder();
            input.AppendLine("restart");
            input.AppendLine("exit");

            // Prepair expected
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(Environment.NewLine);
            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.AppendLine(BullsAndCows.EXIT_GAME);
            // input.....
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            BullsAndCows.Main();

            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            StringAssert.Equals(expected, actual);
        }
    }
}
