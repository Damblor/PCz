package com.lab8;

public class Point
{
    private int game;
    private int score = 0;
    private int num_rounds = 0;

    public int getScore()
    {
        return score;
    }

    public int getNum_rounds()
    {
        return num_rounds;
    }

    public Point(int game)
    {
        this.game = game;
    }

    public Point(int score, int rounds)
    {
        this.score = score;
        this.num_rounds = rounds;
    }

    public void addScore(int score)
    {
        this.score += score;
    }

    public void increaseRound()
    {
        this.num_rounds += 1;
    }


    @Override
    public String toString()
    {
        return "Gra nr: " + game +", liczba zdobytych punktów: " + score + ", liczba rund: " + num_rounds;
    }
}
