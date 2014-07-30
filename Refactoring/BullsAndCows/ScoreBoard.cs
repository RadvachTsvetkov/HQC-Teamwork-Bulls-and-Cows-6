namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ScoreBoard : IScoreBoard
    {
        public const int SCOREBOARD_SIZE = 5;
        public const string SCOREBOARD_EMPTY = "Scoreboard is empty!";
        public const string SCOREBOARD_TITLE = "Scoreboard:";
        public const string SCOREBOARD_INPUT_FORMAT = "{0}. {1} --> {2} guesses";

        private List<KeyValuePair<string, int>> scoreBoard;

        public ScoreBoard()
        {
            this.scoreBoard = new List<KeyValuePair<string, int>>();
        }

        public bool IsHighScore(int attempts)
        {
            if (this.scoreBoard.Count < SCOREBOARD_SIZE || this.scoreBoard.Last().Value < attempts)
            {
                return true;
            }

            return false;
        }

        public void Add(string name, int attempts)
        {
            var score = new KeyValuePair<string, int>(name, attempts);
            this.scoreBoard.Add(score);

            this.SortScoreBoard();
            if (this.scoreBoard.Count > SCOREBOARD_SIZE)
            {
                this.scoreBoard.RemoveAt(this.scoreBoard.Count - 1);
            }
        }

        public string GetScoreBoardAsString()
        {
            var output = new StringBuilder();
            if (this.scoreBoard.Count == 0)
            {
                output.AppendLine(SCOREBOARD_EMPTY);
                return output.ToString();
            }

            output.AppendLine(SCOREBOARD_TITLE);
            for (int index = 0; index < this.scoreBoard.Count; index++)
            {
                string name = this.scoreBoard[index].Key;
                int attempts = this.scoreBoard[index].Value;
                output.AppendFormat(SCOREBOARD_INPUT_FORMAT, index + 1, name, attempts);
                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }

        private void SortScoreBoard()
        {
            this.scoreBoard.Sort(
                (first, second) => first.Value.CompareTo(second.Value));
        }
    }
}