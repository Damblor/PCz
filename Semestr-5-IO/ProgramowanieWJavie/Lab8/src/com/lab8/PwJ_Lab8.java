package com.lab8;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.HashMap;
import java.util.Scanner;

public class PwJ_Lab8
{
    public static void main(String[] args)
    {
        HashMap<Integer, Integer> score = loadData();
        Scanner in = new Scanner(System.in);
        System.out.print("Podaj liczbę gier: ");
        int games = Integer.parseInt(in.nextLine());

        Game game = new Game();
        Point[] points = new Point[games];

        for (int i = 0; i < games; i++)
        {
            System.out.println("***** Gra nr " + (i + 1) +" *****");
            System.out.print("Podaj liczbę rund: ");
            int rounds = Integer.parseInt(in.nextLine());
            game.setUp(i + 1, rounds);
            game.run(in);
            points[i] = game.getData();
            if(score.get(rounds) == null)
            {
                score.put(rounds, points[i].getScore());
            }
            else if (score.get(rounds) < points[i].getScore())
            {
                score.put(rounds, points[i].getScore());
            }
        }
        in.close();

        showScore(points);
        saveData(score);
    }

    public static void showScore(Point[] points)
    {
        int score = 0;
        System.out.println("##### PODSUMOWANIE #####");
        for(Point point : points)
        {
            System.out.println(point);
            score += point.getScore();
        }
        System.out.println("Łączna liczba punktów: " + score + " pkt");
    }

    public static HashMap<Integer, Integer> loadData()
    {
        String path = "Data.txt";
        File file = new File(path);
        var scores = new HashMap<Integer, Integer>();
        if (!file.exists()) return scores;
        try
        {
            Scanner scanner = new Scanner(file);
            while (scanner.hasNext())
            {
                int r = scanner.nextInt();
                int s = scanner.nextInt();
                scores.put(r, s);
            }
            scanner.close();
        }
        catch (Exception e)
        {
            System.out.println(e);
        }
        return scores;
    }

    public static void saveData(HashMap<Integer, Integer> score)
    {
        String path = "Data.txt";
        try
        {
            PrintWriter printWriter = new PrintWriter(path);
            score.entrySet().forEach(s -> {
                printWriter.println(s.getKey() + " " + s.getValue());
            });
            printWriter.close();
        }
        catch (FileNotFoundException e)
        {
            System.out.println(e);
        }
    }
}