package pl.pcz.wimi.ki.KalkulatorAdv2;

import pl.pcz.wimi.ki.KalkulatorBaseAdvance.KalkulatorBaseAdvance;

import java.util.ArrayList;

import static java.lang.Math.sqrt;

public class KalkulatorAdv2 implements KalkulatorBaseAdvance {

    public KalkulatorAdv2(){
    }

    public float dziel(float a, float b) {
        return a % b;
    }

    public ArrayList<Float> pierwiastki(float a, float b, float c) {

        ArrayList<Float> result = new ArrayList<>();

        float delta = delta(a,b,c);


        if(delta > 0){
            float x1 = x1(a,b,delta);
            float x2 = x1(a,b,delta);
            result.add(x1);
            result.add(x2);
        } else {
            if (delta == 0){
                float x0 = x0(a,b);
                result.add(x0);

            }
        }


        return result;
    }

    private float delta (float a, float b, float c){

        float result;

        result = b*b-4*a*c;

        return result;
    }

    private float x0(float a, float b){

        float result = (-b ) / (2*a);

        return result;
    }

    private float x1(float a, float b, float delta){

        float result = (-b - (float)sqrt(delta)) / (2*a);

        return result;
    }

    private float x2(float a, float b, float delta){

        float result = (-b + (float)sqrt(delta)) / (2*a);

        return result;
    }
}