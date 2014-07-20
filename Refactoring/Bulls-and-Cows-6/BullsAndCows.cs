using System;
using System.Linq;
using System.Collections.Generic;

//napisah go nabyrzo ama NE SAM GO TESTVALA! probwaj dali raboti, maj ima bug ako sa 4 bika parvonanchalno
namespace BullsAndCows
{
    public class BullsAndCows
    {
        private const int NUMBER_OF_DIGITS = 4;
        private const string START_EXPRESSION = "Welcome to “Bulls and Cows” game.Please try to guess my secret 4-digit number.\n" +
                                                "Use 'top' to view the top scoreboard, 'restart' to start a new game\n" +
                                                "and 'help' to cheat and 'exit' to quit the game.";
        private const string ENTER_GUESS = "Enter your guess or command: ";
        private const string HELP = "The number looks like";
        private const string HELP_UNAVAILABLE = "You cannot use more help.";
        private const string WRONG_GUES = "Wrong number! ";
        private const string WRONG_INPUT = "Wrong input format! ";
        private const string IN_SCOREBOARD = "Please enter your name for the top scoreboard: ";
        private const string OUT_SCOREBOARD = "You are not allowed to enter the top scoreboard.";
        private const string EXIT_GAME = "Good bye!";


        private Random r;
        private List<int> digits;
        private char[] helpExpression;

        public BullsAndCows()
        {
            this.r = new Random();
            SetDigits();
        }

        private void SetDigits()
        {
            this.digits = new List<int>();
            for (int index = 0; index < NUMBER_OF_DIGITS; index++)
            {
                digits.Add(r.Next(0, 10));
            }
            this.helpExpression = new char[NUMBER_OF_DIGITS];
            for (int index = 0; index < NUMBER_OF_DIGITS; index++)
            {
                helpExpression[index] = 'X';
            }





        }

        public bool ProccessGuess(IList<int> secret, string guess, out int bulls, out int cows)
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

            char[] secretDigits = secret.Select(x => x.ToString()[0]).ToArray();
            char[] guessDigits = guess.ToCharArray();

            bulls = CalculateBulls(secretDigits, guessDigits);
            cows = CalculateCows(secretDigits, guessDigits);

            return true;
        }
  
        private int CalculateCows(char[] secretDigits, char[] guessDigits)
        {
            int cows = 0;
            for (int i = 0; i < NUMBER_OF_DIGITS; i++)
            {
                for (int j = 0; j < NUMBER_OF_DIGITS; j++)
                {
                    if (secretDigits[i] != 'B' && secretDigits[i] != 'C')
                    {
                        if (secretDigits[i] == guessDigits[j])
                        {
                            cows++;
                            secretDigits[i] = 'C';
                            guessDigits[j] = 'C';
                            break;
                        }
                    }
                }
            }

            return cows;
        }
  
        private int CalculateBulls(char[] secretDigits, char[] guessDigits)
        {
            int bulls = 0;
            for (int index = 0; index < NUMBER_OF_DIGITS; index++)
            {
                if (secretDigits[index] == guessDigits[index])
                {
                    bulls++;
                    secretDigits[index] = 'B';
                    guessDigits[index] = 'B';
                }
            }
            return bulls;
        }

        private string Help()
        {
            int helpPosition = this.r.Next(NUMBER_OF_DIGITS);
            while (this.helpExpression[helpPosition] != 'X')
            {
                helpPosition = this.r.Next(NUMBER_OF_DIGITS);
            }
            this.helpExpression[helpPosition] = char.Parse(this.digits[helpPosition].ToString());
            return new string(this.helpExpression);
        }




        public void StartGame()
        {
            while (true)
            {
                bool flag1 = false;
                int count2 = 0;
                int playerAttemps = 0;
                Console.WriteLine(START_EXPRESSION);
                do
                {
                    Console.WriteLine(ENTER_GUESS);
                    string line = Console.ReadLine();

                    if (line.Trim().ToLower().CompareTo("help") == 0)
                    {
                        if (count2 == NUMBER_OF_DIGITS)
                        {
                            Console.WriteLine(HELP_UNAVAILABLE);
                            continue;




                        }
                        count2++;
                        string helpExpression = Help();
                        Console.WriteLine("{0} {1}", HELP, helpExpression);
                        continue;
                    }
                    else if (line.Trim().ToLower().CompareTo("top") == 0)
                    {
                        klasirane scoreboard = klasirane.GetInstance();
                        scoreboard.sort();
                    }
                    else if (line.Trim().ToLower().CompareTo("restart") == 0)
                    {
                        Console.WriteLine();
                        break;
                    }
                    else if (line.Trim().ToLower().CompareTo("exit") == 0)
                    {
                        flag1 = true;
                        Console.WriteLine(EXIT_GAME);
                        break;
                    }


                    int bulls = 0;
                    int cows = 0;
                    if (!ProccessGuess(new List<int>(this.digits), line.Trim(), out bulls, out cows))
                    {
                        Console.WriteLine(WRONG_INPUT);
                        continue;
                    }
                    playerAttemps++;
                    if (bulls == NUMBER_OF_DIGITS)
                    {
                        Console.WriteLine(count2 == 0 ? "Congratulations! You guessed the secret number in {0} attempts and {1} cheats." :
                            "Congratulations! You guessed the secret number in {0} attempts.", playerAttemps, count2);
                        Console.WriteLine(new string('-', 80));

                        klasirane scoreBoard = klasirane.GetInstance();
                        if (count2 == 0 && scoreBoard.IsHighScore(playerAttemps))
                        {
                            Console.WriteLine(IN_SCOREBOARD);
                            string name = Console.ReadLine();
                            scoreBoard.Add(name, playerAttemps);
                        }
                        else
                        {
                            Console.WriteLine(OUT_SCOREBOARD);



                        }
                        scoreBoard.sort();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0} Bulls: {1}, Cows: {2}", WRONG_GUES, bulls, cows);
                    }






                } while (true);

                if (flag1)
                {
                    break;
                }
                SetDigits();
            }
        }

        public static void Main()
        {
            BullsAndCows game = new BullsAndCows();
            game.StartGame();
        }
    }
}

