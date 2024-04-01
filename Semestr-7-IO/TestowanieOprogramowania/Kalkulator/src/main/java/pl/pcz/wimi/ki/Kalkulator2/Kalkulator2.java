package pl.pcz.wimi.ki.Kalkulator2;

import org.apache.log4j.Level;
import org.apache.log4j.Logger;
import pl.pcz.wimi.ki.KalkulatorBase.KalkulatorBase;

public class Kalkulator2 implements KalkulatorBase {



    public Kalkulator2(){

    }

    public int dodaj (int b, int a) {
         return a + b;
    }

    public int odejmij (int b, int a) {
        return a - b;
    }

    public int mnozenie (int a, int b) {
        return a * b;
    }

    public int dzielenie (int a, int b) {
        return a / b;
    }

}
