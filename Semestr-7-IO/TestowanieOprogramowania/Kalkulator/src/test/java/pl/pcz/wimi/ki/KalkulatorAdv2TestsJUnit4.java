package pl.pcz.wimi.ki;

import org.junit.Test;
import pl.pcz.wimi.ki.KalkulatorAdv2.KalkulatorAdv2;

import static junit.framework.Assert.assertEquals;

public class KalkulatorAdv2TestsJUnit4
{
    @Test
    public void testDzielenie1() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(0.5f, kalkulator.dziel(2, 4));
    }

    @Test
    public void testDzielenie2() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(-0.5f, kalkulator.dziel(2, -4));
    }

    @Test
    public void testDzieleniePrzezZero1() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(Float.POSITIVE_INFINITY, kalkulator.dziel(2, 0));
    }

    @Test
    public void testDzieleniePrzezZero2() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(Float.NEGATIVE_INFINITY, kalkulator.dziel(-2, 0));
    }

    @Test
    public void testDzieleniePrzezZero3() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(Float.NaN, kalkulator.dziel(0, 0));
    }

    @Test
    public void testPierwiastki1() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(-0.5f, kalkulator.pierwiastki(4, -2, -2).get(0));
        assertEquals(1f, kalkulator.pierwiastki(4, -2, -2).get(1));
    }

    @Test
    public void testPierwiastki2() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(-3f, kalkulator.pierwiastki(1, 6, 9).get(0));
    }

    @Test
    public void testPierwiastki3() {
        KalkulatorAdv2 kalkulator = new KalkulatorAdv2();
        assertEquals(0, kalkulator.pierwiastki(3, 0, 4).size());
    }
}
