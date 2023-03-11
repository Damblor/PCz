package com.lab8;

import java.util.Random;

public class Board
{
    private int x = 8;
    private int y = 8;
    private Point X;
    private Point A;
    private Point B;
    private String phisicalBoard[][] = new String[x][y];

    public void setA(Point a)
    {
        A = a;
    }

    public void setB(Point b)
    {
        B = b;
    }

    public Board(int x, int y)
    {
        this.x = x;
        this.y = y;
        Random rand = new Random();
        X = new Point(rand.nextInt((x - 1) + 1) + 1, rand.nextInt((y - 1) + 1) + 1);
    }

    public boolean checkPoints(com.lab8.Point point)
    {
        int distA = checkPointsDistance(A);
        int distB = checkPointsDistance(B);
        phisicalBoard[A.getX() - 1][A.getY() - 1] = Integer.toString(distA);
        phisicalBoard[B.getX() - 1][B.getY() - 1] = Integer.toString(distB);
        if(distA == 0 || distB == 0)
        {
            point.addScore(GameScoring.RoundScores[point.getNum_rounds() - 1]);
            phisicalBoard[X.getX() - 1][X.getY() - 1] = "X";
            return true;
        }
        else if(distA > distB)
        {
            point.addScore(GameScoring.getAdditionalScore(distB));
            System.out.println("Bliżej jest punkt (" + B.getX() + "," + B.getY() + ") odl=" + distB);
        }
        else if (distA < distB)
        {
            point.addScore(GameScoring.getAdditionalScore(distA));
            System.out.println("Bliżej jest punkt (" + A.getX() + "," + A.getY() + ") odl=" + distA);
        }
        else
        {
            point.addScore(GameScoring.getAdditionalScore(distB));
            System.out.println("Oba punkty są w takiej samej odległości (" + A.getY() + "," + A.getY() + ") odl=" + distA + " (" + B.getY() + "," + B.getY() + ") odl=" + distB);
        }
        return false;
    }

    public int checkPointsDistance(Point point)
    {
        return Math.abs(X.getX() - point.getX()) + Math.abs(X.getY() - point.getY());
    }

    public String getPointX()
    {
        return "Szukany punkt X(" + X.getX() + ", " + X.getY() + ")";
    }

    public void showBoard()
    {
        for (int i = x - 1; i >= 0; i--)
        {
            System.out.print(i + 1 + "|");
            for (int j = 0; j < y; j++)
            {
                if(phisicalBoard[j][i] == null)
                    System.out.print(" |");
                else
                    System.out.print(phisicalBoard[j][i] + "|");
            }
            System.out.print("\n");
        }
        System.out.println("  1 2 3 4 5 6 7 8");
    }

    public static class Point
    {
        private final int x;
        private final int y;

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
