namespace BullsAndCowsGame
{
    public interface IScoreBoard
    {
        bool IsHighScore(int points);

        void Add(string name, int points);

        string GetScoreBoardAsString();
    }
}