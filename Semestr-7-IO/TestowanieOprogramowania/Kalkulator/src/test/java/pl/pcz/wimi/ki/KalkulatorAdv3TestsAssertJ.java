package pl.pcz.wimi.ki;

import org.junit.Test;
import pl.pcz.wimi.ki.KalkulatorAdv3.KalkulatorAdv3;

import static org.assertj.core.api.Assertions.*;

public class KalkulatorAdv3TestsAssertJ
{
    @Test
    public void testDzielenie1() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.dziel(2, 4)).isEqualTo(0.5f);
    }

    @Test
    public void testDzielenie2() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.dziel(2, -4)).isEqualTo(-0.5f);
    }

    @Test
    public void testDzieleniePrzezZero1() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.dziel(2, 0)).isEqualTo(Float.POSITIVE_INFINITY);
    }

    @Test
    public void testDzieleniePrzezZero2() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.dziel(-2, 0)).isEqualTo(Float.NEGATIVE_INFINITY);
    }

    @Test
    public void testDzieleniePrzezZero3() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.dziel(0, 0)).isEqualTo(Float.NaN);
    }

    @Test
    public void testPierwiastki1() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.pierwiastki(4, -2, -2)).containsExactly(-0.5f, 1f);
    }

    @Test
    public void testPierwiastki2() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.pierwiastki(1, 6, 9)).containsExactly(-3f);
    }

    @Test
    public void testPierwiastki3() {
        KalkulatorAdv3 kalkulator = new KalkulatorAdv3();
        assertThat(kalkulator.pierwiastki(3, 0, 4)).isEmpty();
    }
}
