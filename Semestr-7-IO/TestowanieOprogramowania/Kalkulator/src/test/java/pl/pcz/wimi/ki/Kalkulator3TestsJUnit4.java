package pl.pcz.wimi.ki;

import org.junit.Assert;
import org.junit.Test;

import pl.pcz.wimi.ki.Kalkulator3.Kalkulator3;

import static junit.framework.Assert.assertEquals;

public class Kalkulator3TestsJUnit4
{
    @Test
    public void testDodaj1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(5, kalkulator.dodaj(3, 2));
    }

    @Test
    public void testDodaj2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(1, kalkulator.dodaj(3, -2));
    }

    @Test
    public void testOdejmij1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(-1, kalkulator.odejmij(2, 3));
    }

    @Test
    public void testOdejmij2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(5, kalkulator.odejmij(3, -2));
    }

    @Test
    public void testMnozenie1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(8, kalkulator.mnozenie(2, 4));
    }

    @Test
    public void testMnozenie2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(-8, kalkulator.mnozenie(2, -4));
    }

    @Test
    public void testDzielenie1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(2, kalkulator.dzielenie(4, 2));
    }

    @Test
    public void testDzielenie2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertEquals(-2, kalkulator.dzielenie(4, -2));
    }

    @Test
    public void testDzieleniePrzezZero1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        Assert.assertThrows(ArithmeticException.class, () -> kalkulator.dzielenie(4, 0));
    }

    @Test
    public void testDzieleniePrzezZero2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        Assert.assertThrows(ArithmeticException.class, () -> kalkulator.dzielenie(-4, 0));
    }

    @Test
    public void testDzieleniePrzezZero3() {
        Kalkulator3 kalkulator = new Kalkulator3();
        Assert.assertThrows(ArithmeticException.class, () -> kalkulator.dzielenie(0, 0));
    }
}
