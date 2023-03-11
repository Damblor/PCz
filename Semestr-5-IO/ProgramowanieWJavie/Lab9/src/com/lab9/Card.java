package com.lab9;

public class Card implements Comparable<Card>
{
    public enum RANK
    {
        NINE("9"), TEN("10"), JACK("J"), QUEEN("Q"), KING("K"), ACE("A");
        String rank;
        RANK(String r) { rank = r; }

        @Override
        public String toString() { return rank; }
    }

    public enum SUIT
    {
        HEART("H"), TILE("T"), CLOVER("C"), PIKE("P");
        String suit;
        SUIT(String s) { suit = s; }

        @Override
        public String toString() { return suit; }
    }

    public RANK rank;
    public SUIT suit;

    public RANK getRank()
    {
        return rank;
    }

    public SUIT getSuit()
    {
        return suit;
    }

    public Card(RANK rank, SUIT suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    @Override
    public int compareTo(Card c)
    {
        if(this.rank.compareTo(c.getRank()) > 0)
            return -1;
        else if(this.rank.compareTo(c.getRank()) < 0)
            return 1;
        else
        {
            return Integer.compare(0, this.suit.compareTo(c.getSuit()));
        }
    }

    @Override
    public String toString()
    {
        return rank.toString() + "(" + suit.toString() + ")";
    }
}
