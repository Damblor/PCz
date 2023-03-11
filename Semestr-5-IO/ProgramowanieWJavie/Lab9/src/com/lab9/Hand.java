package com.lab9;

import static java.util.Comparator.comparing;

public record Hand(Player.POKERHAND pokerhand) implements Comparable<Hand> {

    @Override
    public int compareTo(Hand that) {
        return comparing(Hand::pokerhand).compare(this, that);
    }
}
