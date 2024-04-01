package pl.pcz.wimi.ki;

import org.apache.log4j.BasicConfigurator;
import pl.pcz.wimi.ki.Kalkulator1.Kalkulator1;
import pl.pcz.wimi.ki.Kalkulator2.Kalkulator2;
import pl.pcz.wimi.ki.Kalkulator3.Kalkulator3;
import pl.pcz.wimi.ki.KalkulatorAdv1.KalkulatorAdv1;
import pl.pcz.wimi.ki.KalkulatorAdv2.KalkulatorAdv2;
import pl.pcz.wimi.ki.KalkulatorAdv3.KalkulatorAdv3;
import pl.pcz.wimi.ki.KalkulatorBase.KalkulatorBase;
import pl.pcz.wimi.ki.KalkulatorBaseAdvance.KalkulatorBaseAdvance;

import java.util.ArrayList;

/**
 * Hello world!
 *
 */
public class Kalkulator {

    public static void main( String[] args ) {
        BasicConfigurator.configure();
        System.out.println( "Program testowy 1. Kalkulator" );
        Kalkulator kalkulator = new Kalkulator();

        kalkulator.start();
    }

    public void start() {
        System.out.println("Uruchomienie testowych Kalkulatorow");
        Kalkulator1 k1 = new Kalkulator1();
        Kalkulator2 k2 = new Kalkulator2();
        Kalkulator3 k3 = new Kalkulator3();
        KalkulatorAdv1 ka1 = new KalkulatorAdv1();
        KalkulatorAdv2 ka2 = new KalkulatorAdv2();
        KalkulatorAdv3 ka3 = new KalkulatorAdv3();

        wywolajKalkulatorBase(k1);
        wywolajKalkulatorBase(k2);
        wywolajKalkulatorBase(k3);

        wywolajKalkulatorAdv(ka1);
        wywolajKalkulatorAdv(ka2);
        wywolajKalkulatorAdv(ka3);

    }

    public void wywolajKalkulatorBase(KalkulatorBase kalkulator){
        final int a = 21;
        final int b = 10;
        System.out.println("Wywolanie metod z wartosciami 20 oraz 9: ");

        System.out.println(kalkulator.dodaj(a, b));
        System.out.println(kalkulator.odejmij(a, b));
        System.out.println(kalkulator.mnozenie(a, b));
        System.out.println(kalkulator.dzielenie(a, b));
    }

    public void wywolajKalkulatorAdv(KalkulatorBaseAdvance kalkulator){
        float a=1;
        float b=1;
        Float c=-2f;
        System.out.println("Wywolanie metod z klasy KalkulatorBaseAdvance");
        System.out.println(kalkulator.dziel(a, b));

        ArrayList<Float> result = kalkulator.pierwiastki(a,b,c);
        for (int i = 0; i < result.size(); ++i) {
            System.out.println(result.get(i));
        }

        a = -2; b = 4; c = -2f;
        result = kalkulator.pierwiastki(a,b,c);
        for (int i = 0; i < result.size(); ++i) {
            System.out.println(result.get(i));
        }

        a = 1; b = 1; c = 1f;
        result = kalkulator.pierwiastki(a,b,c);
        for (int i = 0; i < result.size(); ++i) {
            System.out.println(result.get(i));
        }

    }
}
