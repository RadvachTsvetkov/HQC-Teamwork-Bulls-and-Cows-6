namespace BullsAndCowsGame
{
    using System;

    public class RandomNumberProvider : IRandomNumberProvider
    {
        public RandomNumberProvider()
        {
            this.RandomGenerator = new Random();
        }
        
        private Random RandomGenerator { get; set; }
        
        public int GetRandomNumber(int minValue, int maxValue)
        {
            return this.RandomGenerator.Next(minValue, maxValue);
        }
    }
}