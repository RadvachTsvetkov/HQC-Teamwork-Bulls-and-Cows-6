using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScoreBoard
{
    public const int SCOREBOARD_SIZE = 5;
    public const string SCOREBOARD_EMPTY = "Scoreboard is empty!";

    private static ScoreBoard instance;
    private List<KeyValuePair<string, int>> scoreBoard;
    private ScoreBoard()
    {
        this.scoreBoard = new List<KeyValuePair<string, int>>();
    }
    public static ScoreBoard GetInstance()
    {
        if (instance == null)
        {
            instance = new ScoreBoard();
        }

        return instance;
    }
    private void SortScoreBoard()
    {
        this.scoreBoard.Sort(new Comparison<KeyValuePair<string, int>>(
            (first, second) => second.Value.CompareTo(first.Value)));
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
        this.scoreBoard.Add(new KeyValuePair<string, int>(name, attempts));
        SortScoreBoard();
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

        output.AppendLine("Scoreboard:");
        for (int index = 0; index < this.scoreBoard.Count; index++)
        {
            string name = this.scoreBoard[index].Key;
            int attempts = this.scoreBoard[index].Value;
            output.AppendFormat("{0}. {1} --> {2} guesses", index + 1, name, attempts);
            output.Append(Environment.NewLine);
        }

        return output.ToString();
    }
}