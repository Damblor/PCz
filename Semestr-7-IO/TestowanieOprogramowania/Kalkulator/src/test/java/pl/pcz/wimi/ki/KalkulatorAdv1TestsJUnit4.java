package pl.pcz.wimi.ki;

import org.junit.Test;
import pl.pcz.wimi.ki.KalkulatorAdv1.KalkulatorAdv1;

import static junit.framework.Assert.assertEquals;

public class KalkulatorAdv1TestsJUnit4
{
    @Test
    public void testDzielenie1() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(0.5f, kalkulator.dziel(2, 4));
    }

    @Test
    public void testDzielenie2() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(-0.5f, kalkulator.dziel(2, -4));
    }

    @Test
    public void testDzieleniePrzezZero1() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(Float.POSITIVE_INFINITY, kalkulator.dziel(2, 0));
    }

    @Test
    public void testDzieleniePrzezZero2() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(Float.NEGATIVE_INFINITY, kalkulator.dziel(-2, 0));
    }

    @Test
    public void testDzieleniePrzezZero3() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(Float.NaN, kalkulator.dziel(0, 0));
    }

    @Test
    public void testPierwiastki1() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(-0.5f, kalkulator.pierwiastki(4, -2, -2).get(0));
        assertEquals(1f, kalkulator.pierwiastki(4, -2, -2).get(1));
    }

    @Test
    public void testPierwiastki2() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(-3f, kalkulator.pierwiastki(1, 6, 9).get(0));
    }

    @Test
    public void testPierwiastki3() {
        KalkulatorAdv1 kalkulator = new KalkulatorAdv1();
        assertEquals(0, kalkulator.pierwiastki(3, 0, 4).size());
    }
}
