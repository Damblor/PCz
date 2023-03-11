package com.lab8;

public interface GameScoring
{
    public int [] RoundScores = {100, 50, 30, 20, 10};

    public static int getAdditionalScore(int distance)
    {
        if(distance > 10) return 0;
        else return 10 - distance;
    }
}
