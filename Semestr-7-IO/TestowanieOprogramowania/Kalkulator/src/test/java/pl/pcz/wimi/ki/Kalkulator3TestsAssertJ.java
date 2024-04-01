package pl.pcz.wimi.ki;

import org.junit.Test;
import pl.pcz.wimi.ki.Kalkulator3.Kalkulator3;

import static org.assertj.core.api.Assertions.*;

public class Kalkulator3TestsAssertJ
{
    @Test
    public void testDodaj1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.dodaj(3, 2)).isEqualTo(5);
    }

    @Test
    public void testDodaj2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.dodaj(3, -2)).isEqualTo(1);
    }

    @Test
    public void testOdejmij1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.odejmij(2, 3)).isEqualTo(-1);
    }

    @Test
    public void testOdejmij2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.odejmij(3, -2)).isEqualTo(5);
    }

    @Test
    public void testMnozenie1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.mnozenie(2, 4)).isEqualTo(8);
    }

    @Test
    public void testMnozenie2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.mnozenie(2, -4)).isEqualTo(-8);
    }

    @Test
    public void testDzielenie1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.dzielenie(4, 2)).isEqualTo(2);
    }

    @Test
    public void testDzielenie2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThat(kalkulator.dzielenie(4, -2)).isEqualTo(-2);
    }

    @Test
    public void testDzieleniePrzezZero1() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThatExceptionOfType(ArithmeticException.class)
                .isThrownBy(() -> kalkulator.dzielenie(4, 0));
    }

    @Test
    public void testDzieleniePrzezZero2() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThatExceptionOfType(ArithmeticException.class)
                .isThrownBy(() -> kalkulator.dzielenie(-4, 0));
    }

    @Test
    public void testDzieleniePrzezZero3() {
        Kalkulator3 kalkulator = new Kalkulator3();
        assertThatExceptionOfType(ArithmeticException.class)
                .isThrownBy(() -> kalkulator.dzielenie(0, 0));
    }
}
