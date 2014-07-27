namespace BullsAndCows
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class BullsAndCows
    {
        public const int NUMBER_OF_DIGITS = 4;
        public const string START_EXPRESSION = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\n" +
                                               "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat " +
                                               "and 'help' to cheat and 'exit' to quit the game.";
        public const string CONGRATULATIONS_WITHOUT_CHEATS = "Congratulations! You guessed the secret number in {0} attempts.";
        public const string CONGRATULATIONS_WITH_CHEATS = "Congratulations! You guessed the secret number in {0} attempts and {1} cheats.";
        public const string ENTER_GUESS = "Enter your guess or command: ";
        public const string HELP = "The number looks like";
        public const string HELP_UNAVAILABLE = "You cannot use more help.";
        public const string WRONG_GUESS = "Wrong number! ";
        public const string WRONG_INPUT_FORMAT = "Wrong input format! ";
        public const string ASK_NAME_FOR_SCOREBOARD = "Please enter your name for the top scoreboard: ";
        public const string NOT_FOR_SCOREBOARD = "You are not allowed to enter the top scoreboard.";
        public const string EXIT_GAME = "Good bye!";

        private Random randomGenerator;
        private List<int> secretDigits;
        private char[] helpDigits;

        public BullsAndCows()
        {
            this.randomGenerator = new Random();
            this.SetNewDigits();
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
                        ScoreBoard scoreboard = ScoreBoard.GetInstance();
                        var scoreBoardAsString = scoreboard.GetScoreBoardAsString();
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
                } while (true);

                if (gameFinished)
                {
                    break;
                }

                this.SetNewDigits();
            }
        }
 
        public static void Main()
        {
            BullsAndCows game = new BullsAndCows();
            game.StartGame();
        }

        private void ProcessGuessedSecredDigits(int usedCheats, int playerAttemps)
        {
            Console.WriteLine(usedCheats == 0 ? CONGRATULATIONS_WITHOUT_CHEATS : CONGRATULATIONS_WITH_CHEATS, playerAttemps, usedCheats);
            Console.WriteLine(new string('-', 80));

            ScoreBoard scoreBoard = ScoreBoard.GetInstance();
            if (usedCheats == 0 && scoreBoard.IsHighScore(playerAttemps))
            {
                Console.WriteLine(ASK_NAME_FOR_SCOREBOARD);
                string name = Console.ReadLine();
                scoreBoard.Add(name, playerAttemps);
            }
            else
            {
                Console.WriteLine(NOT_FOR_SCOREBOARD);
            }

            var scoreBoardAsString = scoreBoard.GetScoreBoardAsString();
            Console.WriteLine(scoreBoardAsString);
        }

        private int CalculateCows(char[] secret, char[] guess)
        {
            int cows = 0;
            for (int i = 0; i < NUMBER_OF_DIGITS; i++)
            {
                for (int j = 0; j < NUMBER_OF_DIGITS; j++)
                {
                    if (char.IsDigit(secret[i]))//(secret[i] != 'B' && secret[i] != 'C')
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
            int helpPosition = this.randomGenerator.Next(NUMBER_OF_DIGITS);
            while (this.helpDigits[helpPosition] != 'X')
            {
                helpPosition = this.randomGenerator.Next(NUMBER_OF_DIGITS);
            }

            this.helpDigits[helpPosition] = char.Parse(this.secretDigits[helpPosition].ToString());
            return new string(this.helpDigits);
        }

        private void SetNewDigits()
        {
            this.secretDigits = new List<int>();
            this.helpDigits = new char[NUMBER_OF_DIGITS];
            for (int index = 0; index < NUMBER_OF_DIGITS; index++)
            {
                this.secretDigits.Add(this.randomGenerator.Next(0, 10));
                this.helpDigits[index] = 'X';
            }
        }
    }
}