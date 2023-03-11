package com.lab9;

import java.util.*;

public class Pwj_Lab9
{
    public static void main(String[] args)
    {
        ArrayList<Card> deck = new ArrayList<>();
        deck.add(new Card(Card.RANK.NINE, Card.SUIT.HEART));
        deck.add(new Card(Card.RANK.TEN, Card.SUIT.HEART));
        deck.add(new Card(Card.RANK.JACK, Card.SUIT.HEART));
        deck.add(new Card(Card.RANK.QUEEN, Card.SUIT.HEART));
        deck.add(new Card(Card.RANK.KING, Card.SUIT.HEART));
        deck.add(new Card(Card.RANK.ACE, Card.SUIT.HEART));

        deck.add(new Card(Card.RANK.NINE, Card.SUIT.TILE));
        deck.add(new Card(Card.RANK.TEN, Card.SUIT.TILE));
        deck.add(new Card(Card.RANK.JACK, Card.SUIT.TILE));
        deck.add(new Card(Card.RANK.QUEEN, Card.SUIT.TILE));
        deck.add(new Card(Card.RANK.KING, Card.SUIT.TILE));
        deck.add(new Card(Card.RANK.ACE, Card.SUIT.TILE));

        deck.add(new Card(Card.RANK.NINE, Card.SUIT.CLOVER));
        deck.add(new Card(Card.RANK.TEN, Card.SUIT.CLOVER));
        deck.add(new Card(Card.RANK.JACK, Card.SUIT.CLOVER));
        deck.add(new Card(Card.RANK.QUEEN, Card.SUIT.CLOVER));
        deck.add(new Card(Card.RANK.KING, Card.SUIT.CLOVER));
        deck.add(new Card(Card.RANK.ACE, Card.SUIT.CLOVER));

        deck.add(new Card(Card.RANK.NINE, Card.SUIT.PIKE));
        deck.add(new Card(Card.RANK.TEN, Card.SUIT.PIKE));
        deck.add(new Card(Card.RANK.JACK, Card.SUIT.PIKE));
        deck.add(new Card(Card.RANK.QUEEN, Card.SUIT.PIKE));
        deck.add(new Card(Card.RANK.KING, Card.SUIT.PIKE));
        deck.add(new Card(Card.RANK.ACE, Card.SUIT.PIKE));

        System.out.println("Talia");
        deck.forEach(c -> System.out.print(c));
        System.out.println("\nPo tasowaniu");
        Collections.shuffle(deck);
        deck.forEach(c -> System.out.print(c));
        System.out.println();

        Player p1 = new Player(1);
        Player p2 = new Player(2);

        Iterator<Card> iter = deck.iterator();
        for (int i = 0; i < 10; i++)
        {
            Card card = iter.next();
            if(i % 2 == 0) p1.addCard(card);
            else p2.addCard(card);
            iter.remove();
        }
        Scanner in = new Scanner(System.in);
        System.out.print("Karty gracza " + p1.getNumber() + ": ");
        p1.getCards().forEach(c -> System.out.print(c));
        System.out.print("\nKarty gracza " + p2.getNumber() + ": ");
        p2.getCards().forEach(c -> System.out.print(c));
        System.out.println("\n * * * ");
        changeCards(p1, deck, in);
        changeCards(p2, deck, in);
        in.close();

//        p1.addCard(new Card(Card.RANK.ACE, Card.SUIT.HEART));
//        p1.addCard(new Card(Card.RANK.KING, Card.SUIT.HEART));
//        p1.addCard(new Card(Card.RANK.QUEEN, Card.SUIT.HEART));
//        p1.addCard(new Card(Card.RANK.JACK, Card.SUIT.HEART));
//        p1.addCard(new Card(Card.RANK.TEN, Card.SUIT.HEART));
//
//        p2.addCard(new Card(Card.RANK.ACE, Card.SUIT.PIKE));
//        p2.addCard(new Card(Card.RANK.KING, Card.SUIT.PIKE));
//        p2.addCard(new Card(Card.RANK.QUEEN, Card.SUIT.PIKE));
//        p2.addCard(new Card(Card.RANK.JACK, Card.SUIT.PIKE));
//        p2.addCard(new Card(Card.RANK.TEN, Card.SUIT.PIKE));

        p1.setCheckedCards();
        p2.setCheckedCards();
        if(p1.getHand().compareTo(p2.getHand()) > 0)
        {
            System.out.println("Wygrał gracz 1");
        }
        else if(p1.getHand().compareTo(p2.getHand()) < 0)
        {
            System.out.println("Wygrał gracz 2");
        }
        else
        {
            System.out.println("Remis");
        }
        System.out.println("Wynik gracza 1: " + p1.getHand().pokerhand());
        System.out.println("Wynik gracza 2: " + p2.getHand().pokerhand());
    }

    public static void changeCards(Player player, ArrayList<Card> deck, Scanner in)
    {
        System.out.println("\nRuch gracza " + player.getNumber());
        System.out.print("Podaj liczbę kart do wymiany: ");
        int doWymiany = 0;
        while (true)
        {
            try
            {
                doWymiany = Integer.parseInt(in.nextLine());
                if(doWymiany < 0 || doWymiany > 5) throw new Exception();
                break;
            }
            catch (Exception ex)
            {
                System.out.println("Błąd podaj wartość jeszcze raz: ");
            }
        }
        if(doWymiany == 0) return;
        int[] w = new int[doWymiany];
        var handSet = player.getCards();
        Iterator<Card> it;
        System.out.println("Wskaż karty do wymiany (od lewej):");
        while (true)
        {
            try
            {
                for(int i = 0; i < doWymiany; i++)
                {
                    w[i] = Integer.parseInt(in.next());
                    if(w[i] < 1 || w[i] > 5) throw new Exception();
                }
                in.nextLine();
                break;
            }
            catch (Exception ex)
            {
                System.out.println("Błąd podaj wartości jeszcze raz: ");
            }
        }
        for (int i = doWymiany - 1; i >= 0; i--)
        {
            it = handSet.iterator();
            for(int j = 1; j <= w[i]; j++ )
            {
                it.next();
            }
            it.remove();
        }
        System.out.print("Pozostałe karty gracza " + player.getNumber() + ": ");
        player.getCards().forEach(c -> System.out.print(c));

        Iterator<Card> iter = deck.iterator();
        for(int i = 0; i < doWymiany; i++)
        {
            Card card = iter.next();
            player.addCard(card);
            iter.remove();
        }

        System.out.print("\nPo dobraniu kart przez gracza " + player.getNumber() + ": ");
        player.getCards().forEach(c -> System.out.print(c));
    }
}