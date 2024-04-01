package pl.pcz.wimi.ki;

import org.junit.Test;
import pl.pcz.wimi.ki.Kalkulator2.Kalkulator2;

import static org.assertj.core.api.Assertions.*;

public class Kalkulator2TestsAssertJ
{
    @Test
    public void testDodaj1() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.dodaj(3, 2)).isEqualTo(5);
    }

    @Test
    public void testDodaj2() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.dodaj(3, -2)).isEqualTo(1);
    }

    @Test
    public void testOdejmij1() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.odejmij(2, 3)).isEqualTo(-1);
    }

    @Test
    public void testOdejmij2() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.odejmij(3, -2)).isEqualTo(5);
    }

    @Test
    public void testMnozenie1() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.mnozenie(2, 4)).isEqualTo(8);
    }

    @Test
    public void testMnozenie2() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.mnozenie(2, -4)).isEqualTo(-8);
    }

    @Test
    public void testDzielenie1() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.dzielenie(4, 2)).isEqualTo(2);
    }

    @Test
    public void testDzielenie2() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThat(kalkulator.dzielenie(4, -2)).isEqualTo(-2);
    }

    @Test
    public void testDzieleniePrzezZero1() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThatExceptionOfType(ArithmeticException.class)
                .isThrownBy(() -> kalkulator.dzielenie(4, 0));
    }

    @Test
    public void testDzieleniePrzezZero2() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThatExceptionOfType(ArithmeticException.class)
                .isThrownBy(() -> kalkulator.dzielenie(-4, 0));
    }

    @Test
    public void testDzieleniePrzezZero3() {
        Kalkulator2 kalkulator = new Kalkulator2();
        assertThatExceptionOfType(ArithmeticException.class)
                .isThrownBy(() -> kalkulator.dzielenie(0, 0));
    }
}
