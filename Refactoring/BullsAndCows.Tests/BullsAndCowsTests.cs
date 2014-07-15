namespace BullsAndCows.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BullsAndCowsTests
    {
        [TestMethod]
        public void ShouldBeEqual_ifGuessLengthHasExpectedLength()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 1, 1, 1 };
            string guess = "1234";

            // Act
            bool isValidGuess = game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.AreEqual(guess.Length == BullsAndCows.NUMBER_OF_DIGITS, isValidGuess);
        }

        // Документирани тестове
        [TestMethod]
        public void ProccessGues_Secret1234Guess5678_0Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "5678";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 0);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess4567_0Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "4567";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 1 && bulls == 0);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess3456_0Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "3456";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 2 && bulls == 0);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess2349_0Bull3Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "2349";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 3 && bulls == 0);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess2341_0Bull4Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "2341";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 4 && bulls == 0);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1999_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1999";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 1);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1299_2Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1299";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 2);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1239_3Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1239";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 3);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1234_4Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1234";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 4);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1499_1Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1499";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 1 && bulls == 1);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1249_2Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1249";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 1 && bulls == 2);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1923_1Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1923";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 2 && bulls == 1);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1243_2Bull2Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1243";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 2 && bulls == 2);
        }

        [TestMethod]
        public void ProccessGues_Secret1234Guess1342_1Bull3Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1342";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 3 && bulls == 1);
        }


        [TestMethod]
        public void ProccessGues_Secret1234Guess1234_ShouldNeverReturn3Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 1, 2, 3, 4 };
            string guess = "1234";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsFalse(cows == 3 && bulls == 1);
        }

        // Count a digit only ONCE
        /*Note that a single digit can either represent a bull, or a cow,
            but not two bulls, two cows or bull and cow in the same time.
            For example, if the secret number is 2424 and the guess number is 4144,
            the result is 1 bull and 1 cow.
        */
        [TestMethod]
        public void ProccessGues_Secret2424Guess4144_1Bull1Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 2, 4, 2, 4 };
            string guess = "4144";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 1 && bulls == 1);
        }

        [TestMethod]
        public void ProccessGues_Secret5694Guess5555_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 6, 9, 4 };
            string guess = "5555";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 1);
        }

        // Reversed previous test
        [TestMethod]
        public void ProccessGues_Secret5555Guess5694_1Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 5, 5, 5 };
            string guess = "5694";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 1);
        }

        [TestMethod]
        public void ProccessGues_Secret5555Guess5555_4Bull0Cow()
        {
            // Arrange
            BullsAndCows game = new BullsAndCows();
            int bulls = 0;
            int cows = 0;
            int[] secret = { 5, 5, 5, 5 };
            string guess = "5694";

            // Act
            game.ProccessGues(secret, guess, out bulls, out cows);

            // Assert
            Assert.IsTrue(cows == 0 && bulls == 4);
        }
    }
}

// Arrange
// Act
// Assert