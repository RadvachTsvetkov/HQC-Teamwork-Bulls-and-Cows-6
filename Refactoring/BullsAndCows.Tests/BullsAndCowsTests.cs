namespace BullsAndCowsGame.Tests
{
    using System;
    using System.IO;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BullsAndCowsTests
    {
        private readonly IRandomNumberProvider randomGenerator;

        public BullsAndCowsTests(IRandomNumberProvider randomNumberProvider)
        {
            this.randomGenerator = randomNumberProvider;
        }
        public BullsAndCowsTests()
            : this(new RandomNumberProvider())
        {
        }

        private string GetRandomNumberAsString(int count = 4)
        {
            var output = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                output.Append(this.randomGenerator.GetRandomNumber(0, 10));
            }

            return output.ToString();
        }

        [TestMethod]
        public void CalculateBullsAndCows_ifGuessLengthEqualsToNUMBER_OF_DIGITSAndGuessNumberParseSucceed_ShouldReturnTrue()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string guess = GetRandomNumberAsString(BullsAndCows.NUMBER_OF_DIGITS);

            // Act
            bool isValidGuess = game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(isValidGuess);
        }

        [TestMethod]
        public void CalculateBullsAndCows_IfGuessNumberParseFails_ShouldReturnFalse()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string[] guesses = { "G123", "1G34", "12G4", "123G" };

            for (int i = 0; i < guesses.Length; i++)
            {
                string guess = guesses[i];
                bool isValidGuess = game.CalculateBullsAndCows(secret, guess, out bulls, out cows);
                Assert.IsFalse(isValidGuess);
            }

        }

        [TestMethod]
        public void CalculateBullsAndCows_ifGuessLengthIsBiggerThanNUMBER_OF_DIGITS_ShouldReturnFalse()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string guess = GetRandomNumberAsString(BullsAndCows.NUMBER_OF_DIGITS + 1);

            // Act
            bool isValidGuess = game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsFalse(isValidGuess);
        }

        [TestMethod]
        public void CalculateBullsAndCows_ifGuessLengthIsSmallerThanNUMBER_OF_DIGITS_ShouldReturnFalse()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string guess = GetRandomNumberAsString(BullsAndCows.NUMBER_OF_DIGITS - 1);

            // Act
            bool isValidGuess = game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsFalse(isValidGuess);
        }

        // Документирани тестове
        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess5678_0Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "5678";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess4567_0Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "4567";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess3456_0Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "3456";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(2, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess2349_0Bull3Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "2349";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(3, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess2341_0Bull4Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "2341";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(4, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1999_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1999";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1299_2Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1299";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(2, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1239_3Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1239";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(3, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1234_4Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1234";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(4, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1499_1Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1499";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1249_2Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1249";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(2, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1923_1Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1923";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(2, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1243_2Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1243";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(2, bulls);
            Assert.AreEqual(2, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess1342_1Bull3Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1342";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(3, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret0987Guess0987_ShouldNeverReturn3Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 0, 9, 8, 7 };
            string guess = "0987";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsFalse(bulls == 3 && cows == 1);
        }

        // Count a digit only ONCE
        /*Note that a single digit can either represent a bull, or a cow,
            but not two bulls, two cows or bull and cow in the same time.
            For example, if the secret number is 2424 and the guess number is 4144,
            the result is 1 bull and 1 cow.
        */
        [TestMethod]
        public void CalculateBullsAndCows_Secret2424Guess4144_1Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 2, 4, 2, 4 };
            string guess = "4144";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret5694Guess5555_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 6, 9, 4 };
            string guess = "5555";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret5555Guess5694_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 5, 5, 5 };
            string guess = "5694";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret5555Guess5555_4Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 5, 5, 5 };
            string guess = "5555";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(4, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret4440Guess1234_0Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 4, 4, 4, 0 };
            string guess = "1234";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void CalculateBullsAndCows_Secret1234Guess4440_0Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "4440";

            // Act
            game.CalculateBullsAndCows(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void StartGameMethod_IfRestartCommandWorksCorrectly()
        {
            // Prepair input
            var input = new StringBuilder();
            input.AppendLine("restart");
            input.AppendLine("exit");

            // Prepair expected
            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine(BullsAndCows.START_EXPRESSION);
            expectedOutput.AppendLine(BullsAndCows.ENTER_GUESS);
            expectedOutput.Append(Environment.NewLine);
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
            Assert.AreEqual(expected, actual);
        }
    }
}