package com.lab9;

import java.util.HashSet;
import java.util.Map;
import java.util.TreeSet;

import static java.util.Comparator.comparing;
import static java.util.stream.Collectors.counting;
import static java.util.stream.Collectors.groupingBy;

public class Player
{
    public enum POKERHAND {HIGH_CARD, ONE_PAIR, TWO_PAIR, THREE_OF_A_KIND, STRAIGHT, FLUSH, FULL_HOUSE, FOUR_OF_A_KIND, STRAIGHT_FLUSH, ROYAL_FLUSH}

    private int number;
    private TreeSet<Card> cards = new TreeSet<>();
    private Hand hand;

    public int getNumber()
    {
        return number;
    }
    public TreeSet<Card> getCards()
    {
        return cards;
    }

    public Hand getHand()
    {
        return hand;
    }

    public Player(int number)
    {
        this.number = number;
    }

    public void addCard(Card card)
    {
        cards.add(card);
    }

    public void setCheckedCards()
    {
        this.hand = checkCards();
    }

    private Hand checkCards()
    {
        var cards = new HashSet<>(this.cards);
        if (cards.size() != 5) {
            throw new IllegalArgumentException();
        }
        var flush = cards.stream().map(Card::getSuit).distinct().count() == 1;
        var counts = cards.stream().collect(groupingBy(Card::getRank, counting()));
        var ranks = counts.entrySet().stream().sorted(
                comparing(Map.Entry<Card.RANK, Long>::getValue).thenComparing(Map.Entry::getKey).reversed()
        ).map(Map.Entry::getKey).toArray(Card.RANK[]::new);
        if (ranks.length == 4) {
            return new Hand(POKERHAND.ONE_PAIR);
        } else if (ranks.length == 3) {
            return new Hand(counts.get(ranks[0]) == 2 ? POKERHAND.TWO_PAIR : POKERHAND.THREE_OF_A_KIND);
        } else if (ranks.length == 2) {
            return new Hand(counts.get(ranks[0]) == 3 ? POKERHAND.FULL_HOUSE : POKERHAND.FOUR_OF_A_KIND);
        } else if (ranks[0].equals(Card.RANK.ACE) && ranks[4].equals(Card.RANK.TEN)) {
            return new Hand(flush ? POKERHAND.ROYAL_FLUSH : POKERHAND.STRAIGHT);
        } else if (ranks[0].ordinal() - ranks[4].ordinal() == 4) {
            return new Hand(flush ? POKERHAND.STRAIGHT_FLUSH : POKERHAND.STRAIGHT);
        } else {
            return new Hand(flush ? POKERHAND.FLUSH : POKERHAND.HIGH_CARD);
        }
    }
}
