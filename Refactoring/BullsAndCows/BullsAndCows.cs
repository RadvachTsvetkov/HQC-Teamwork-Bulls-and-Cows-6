namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BullsAndCows
    {
        public const int NUMBER_OF_DIGITS = 4;
        public const string ENTER_GUESS = "Enter your guess or command: ";
        public const string HELP = "The number looks like";
        public const string HELP_UNAVAILABLE = "You cannot use more help.";
        public const string WRONG_GUESS = "Wrong number! ";
        public const string WRONG_INPUT_FORMAT = "Wrong input format! ";
        public const string ASK_NAME_FOR_SCOREBOARD = "Please enter your name for the top scoreboard: ";
        public const string NOT_FOR_SCOREBOARD = "You are not allowed to enter the top scoreboard.";
        public const string EXIT_GAME = "Good bye!";
        public const string START_EXPRESSION = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                                               "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat " +
                                               "and 'help' to cheat and 'exit' to quit the game.";
        public const string CONGRATULATIONS_WITHOUT_CHEATS = CONGRATULATIONS + ".";
        public const string CONGRATULATIONS_WITH_CHEATS = CONGRATULATIONS + " and {1} cheats.";
        private const string CONGRATULATIONS = "Congratulations! You guessed the secret number in {0} attempts";

        private readonly IRandomNumberProvider randomGenerator;
        private readonly IScoreBoard scoreBoard;
        private List<int> secretDigits;
        private char[] helpDigits;

        public BullsAndCows(IRandomNumberProvider randomNumberProvider, IScoreBoard scoreBoard)
        {
            this.randomGenerator = randomNumberProvider;
            this.scoreBoard = scoreBoard;
            this.SetNewDigits();
        }

        // Poor man's DI
        public BullsAndCows()
            : this(new RandomNumberProvider(), new ScoreBoard())
        {
        }

        public BullsAndCows(IRandomNumberProvider randomNumberProvider)
            : this(randomNumberProvider, new ScoreBoard())
        {
        }

        public static void Main()
        {
            BullsAndCows game = new BullsAndCows();
            game.StartGame();
        }

        public bool CalculateBullsAndCows(ICollection<int> secret, string guess, out int bulls, out int cows)
        {
            bulls = 0;
            cows = 0;

            if (guess.Length != NUMBER_OF_DIGITS)
            {
                return false;
            }

            bool containsOnlyDigits = guess.All(x => char.IsDigit(x));
            if (!containsOnlyDigits)
            {
                return false;
            }

            char[] secretAsChars = secret.Select(x => x.ToString()[0]).ToArray();
            char[] guessAsChars = guess.ToCharArray();

            bulls = this.CalculateBulls(secretAsChars, guessAsChars);
            cows = this.CalculateCows(secretAsChars, guessAsChars);

            return true;
        }

        public void StartGame()
        {
            while (true)
            {
                bool gameFinished = false;
                int usedCheats = 0;
                int playerAttemps = 0;
                Console.WriteLine(START_EXPRESSION);
                do
                {
                    Console.WriteLine(ENTER_GUESS);
                    string input = Console.ReadLine();
                    string line = input.Trim().ToLower();

                    if (line.CompareTo("help") == 0)
                    {
                        if (usedCheats == NUMBER_OF_DIGITS)
                        {
                            Console.WriteLine(HELP_UNAVAILABLE);
                            continue;
                        }

                        usedCheats++;
                        string helpExpression = this.Help();
                        Console.WriteLine("{0} {1}", HELP, helpExpression);
                        continue;
                    }
                    else if (line.CompareTo("top") == 0)
                    {
                        var scoreBoardAsString = this.scoreBoard.GetScoreBoardAsString();
                        Console.WriteLine(scoreBoardAsString);
                    }
                    else if (line.CompareTo("restart") == 0)
                    {
                        Console.WriteLine();
                        break;
                    }
                    else if (line.CompareTo("exit") == 0)
                    {
                        gameFinished = true;
                        Console.WriteLine(EXIT_GAME);
                        break;
                    }
                    else
                    {
                        int bulls = 0;
                        int cows = 0;
                        if (!this.CalculateBullsAndCows(this.secretDigits, line, out bulls, out cows))
                        {
                            Console.WriteLine(WRONG_INPUT_FORMAT);
                        }
                        else
                        {
                            playerAttemps++;
                            if (bulls == NUMBER_OF_DIGITS)
                            {
                                this.ProcessGuessedSecredDigits(usedCheats, playerAttemps);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("{0} Bulls: {1}, Cows: {2}", WRONG_GUESS, bulls, cows);
                            }
                        }
                    }
                }
                while (true);

                if (gameFinished)
                {
                    break;
                }

                this.SetNewDigits();
            }
        }

        private void ProcessGuessedSecredDigits(int usedCheats, int playerAttemps)
        {
            Console.WriteLine(usedCheats == 0 ? CONGRATULATIONS_WITHOUT_CHEATS : CONGRATULATIONS_WITH_CHEATS, playerAttemps, usedCheats);

            if (usedCheats == 0 && this.scoreBoard.IsHighScore(playerAttemps))
            {
                Console.WriteLine(ASK_NAME_FOR_SCOREBOARD);
                string name = Console.ReadLine();
                this.scoreBoard.Add(name, playerAttemps);
            }
            else
            {
                Console.WriteLine(NOT_FOR_SCOREBOARD);
            }

            var scoreBoardAsString = this.scoreBoard.GetScoreBoardAsString();
            Console.WriteLine(scoreBoardAsString);
        }

        private int CalculateCows(char[] secret, char[] guess)
        {
            int cows = 0;
            for (int i = 0; i < NUMBER_OF_DIGITS; i++)
            {
                for (int j = 0; j < NUMBER_OF_DIGITS; j++)
                {
                    if (char.IsDigit(secret[i]))
                    {
                        if (secret[i] == guess[j])
                        {
                            cows++;
                            secret[i] = 'C';
                            guess[j] = 'C';
                            break;
                        }
                    }
                }
            }

            return cows;
        }

        private int CalculateBulls(char[] secret, char[] guess)
        {
            int bulls = 0;
            for (int index = 0; index < NUMBER_OF_DIGITS; index++)
            {
                if (secret[index] == guess[index])
                {
                    bulls++;
                    secret[index] = 'B';
                    guess[index] = 'B';
                }
            }

            return bulls;
        }

        private string Help()
        {
            int helpPosition = 0;
            do
            {
                helpPosition = this.randomGenerator.GetRandomNumber(0, NUMBER_OF_DIGITS);
            }
            while (this.helpDigits[helpPosition] != 'X');

            string helpDigit = this.secretDigits[helpPosition].ToString();
            this.helpDigits[helpPosition] = char.Parse(helpDigit);

            return new string(this.helpDigits);
        }

        private void SetNewDigits()
        {
            this.secretDigits = new List<int>();
            this.helpDigits = new char[NUMBER_OF_DIGITS];
            for (int index = 0; index < NUMBER_OF_DIGITS; index++)
            {
                this.secretDigits.Add(this.randomGenerator.GetRandomNumber(0, 10));
                this.helpDigits[index] = 'X';
            }
        }
    }
}