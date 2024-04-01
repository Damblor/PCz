package pl.pcz.wimi.ki;

import org.junit.Test;
import pl.pcz.wimi.ki.KalkulatorAdv3.KalkulatorAdv3;

import static junit.framework.Assert.assertEquals;

public class KalkulatorAdv3TestsJUnit4
{
    @Test
    public void testDzielenie1() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(0.5f, kalkulator.dziel(2, 4));
    }

    @Test
    public void testDzielenie2() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(-0.5f, kalkulator.dziel(2, -4));
    }

    @Test
    public void testDzieleniePrzezZero1() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(Float.POSITIVE_INFINITY, kalkulator.dziel(2, 0));
    }

    @Test
    public void testDzieleniePrzezZero2() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(Float.NEGATIVE_INFINITY, kalkulator.dziel(-2, 0));
    }

    @Test
    public void testDzieleniePrzezZero3() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(Float.NaN, kalkulator.dziel(0, 0));
    }

    @Test
    public void testPierwiastki1() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(-0.5f, kalkulator.pierwiastki(4, -2, -2).get(0));
        assertEquals(1f, kalkulator.pierwiastki(4, -2, -2).get(1));
    }

    @Test
    public void testPierwiastki2() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(-3f, kalkulator.pierwiastki(1, 6, 9).get(0));
    }

    @Test
    public void testPierwiastki3() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertEquals(0, kalkulator.pierwiastki(3, 0, 4).size());
    }
}
