namespace BullsAndCows.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;

    [TestClass]
    public class BullsAndCowsTests
    {
        private const int NUMBER_OF_DIGITS = 4;
        private static Random randomGenerator;
        public BullsAndCowsTests()
        {
            randomGenerator = new Random();
        }

        private string GetRandomNumberAsString(int count = 4)
        {
            var output = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                output.Append(randomGenerator.Next(0, 10));
            }

            return output.ToString();
        }

        [TestMethod]
        public void ProccessGuess_ifGuessLengthEqualsToNUMBER_OF_DIGITSAndGuessNumberParseSucceed_ShouldReturnTrue()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string guess = GetRandomNumberAsString(NUMBER_OF_DIGITS);

            // Act
            bool isValidGuess = game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(isValidGuess);
        }

        [TestMethod]
        public void ProccessGuess_IfGuessNumberParseFails_ShouldReturnFalse()
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
                bool isValidGuess = game.ProccessGuess(secret, guess, out bulls, out cows);
                Assert.IsFalse(isValidGuess);
            }

        }

        [TestMethod]
        public void ProccessGuess_ifGuessLengthIsBiggerThanNUMBER_OF_DIGITS_ShouldReturnFalse()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string guess = GetRandomNumberAsString(NUMBER_OF_DIGITS + 1);

            // Act
            bool isValidGuess = game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsFalse(isValidGuess);
        }

        [TestMethod]
        public void ProccessGuess_ifGuessLengthIsSmallerThanNUMBER_OF_DIGITS_ShouldReturnFalse()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string guess = GetRandomNumberAsString(NUMBER_OF_DIGITS - 1);

            // Act
            bool isValidGuess = game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsFalse(isValidGuess);
        }

        // Документирани тестове
        [TestMethod]
        public void ProccessGuess_Secret1234Guess5678_0Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "5678";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess4567_0Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "4567";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess3456_0Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "3456";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(2, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess2349_0Bull3Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "2349";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(3, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess2341_0Bull4Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "2341";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(4, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1999_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1999";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1299_2Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1299";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(2, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1239_3Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1239";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(3, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1234_4Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1234";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(4, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1499_1Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1499";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1249_2Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1249";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(2, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1923_1Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1923";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(2, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1243_2Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1243";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(2, bulls);
            Assert.AreEqual(2, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret1234Guess1342_1Bull3Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1342";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(3, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret0987Guess0987_ShouldNeverReturn3Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 0, 9, 8, 7 };
            string guess = "0987";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

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
        public void ProccessGuess_Secret2424Guess4144_1Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 2, 4, 2, 4 };
            string guess = "4144";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(1, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret5694Guess5555_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 6, 9, 4 };
            string guess = "5555";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret5555Guess5694_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 5, 5, 5 };
            string guess = "5694";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(1, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret5555Guess5555_4Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 5, 5, 5 };
            string guess = "5555";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(4, bulls);
            Assert.AreEqual(0, cows);
        }

        [TestMethod]
        public void ProccessGuess_Secret4440Guess1234_0Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 4, 4, 4, 0 };
            string guess = "1234";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(1, cows);
        }


        [TestMethod]
        public void ProccessGuess_Secret1234Guess4440_0Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "4440";

            // Act
            game.ProccessGuess(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(0, bulls);
            Assert.AreEqual(1, cows);
        }
    }
}

// Arrange
// Act
// Assert