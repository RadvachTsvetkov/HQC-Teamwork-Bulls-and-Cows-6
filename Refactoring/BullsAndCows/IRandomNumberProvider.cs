﻿namespace BullsAndCowsGame
{
    public interface IRandomNumberProvider
    {
        int GetRandomNumber(int minValue, int maxValue);
    }
}