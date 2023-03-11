package com.lab8;

import java.util.Scanner;

public class Game
{
    private int boardx = 8;
    private int boardy = 8;
    private int gameNumber;
    private int rounds;
    private Point point;
    private Board board;

    public Game() {}

    public void setUp(int gameNumber, int rounds)
    {
        this.rounds = rounds;
        this.gameNumber = gameNumber;
        board = new Board(boardx, boardy);
        point = new Point(gameNumber);
    }

    public void run(Scanner in)
    {
        point.increaseRound();
        board.showBoard();
        for (int i = 1; i <= rounds; i++)
        {
            System.out.println("Runda " + i);
            System.out.println("Podaj współrzędne punktu A");
            board.setA(setPoint(in));
            System.out.println("Podaj współrzędne punktu B");
            board.setB(setPoint(in));
            in.nextLine();
            if(board.checkPoints(point))
            {
                board.showBoard();
                System.out.println("Gratulacje! Cel trafiony w rundzie: " + point.getNum_rounds() + " liczba zdobytych punktów: " + point.getScore());
                break;
            }
            board.showBoard();
            if(i == rounds)
            {
                System.out.println("Koniec rund w grze: " + gameNumber+ " liczba zdobytych punktów: " + point.getScore());
                System.out.println(board.getPointX());
            }
        }
    }

    private Board.Point setPoint(Scanner in)
    {
        while (true)
        {
            try
            {
                int x = in.nextInt();
                int y = in.nextInt();
                if(x < 0 || x > boardx || y < 0 || y > boardy) throw new WrongInputException();
                return new Board.Point(x, y);
            }
            catch (Exception ex)
            {
                if(ex instanceof WrongInputException) System.out.println("Podałęś złe współrzędne. Podaj je jeszcze raz");
                else System.out.println(ex);
            }
        }
    }

    public Point getData()
    {
        return point;
    }

    private static class WrongInputException extends Exception {}
}
