package pl.pcz.wimi.ki.Kalkulator1;

import pl.pcz.wimi.ki.KalkulatorBase.KalkulatorBase;

public class Kalkulator1 implements KalkulatorBase {



    public Kalkulator1(){

    }

    public int dodaj (int a, int b) {

        return a + b;
    }

    public int odejmij (int a, int b) {

        return a - b;
    }

    public int mnozenie (int a, int b) {

        return a * b;
    }

    public int dzielenie (int a, int b) {

        return a / b;
    }

}
