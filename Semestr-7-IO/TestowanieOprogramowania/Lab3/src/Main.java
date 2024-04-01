public class Main
{
    public static void main(String[] args)
    {
        int value = 782;
        String roman = "MCMXCX";
        //String roman = "MCHXCX";
        LiczbaRzymska l1 = new LiczbaRzymska();
        LiczbaRzymska l2 = new LiczbaRzymska();
        l1.initialize(value);
        l2.initialize(roman);
        System.out.println(l1.Add(l2).ToFullValue());
        System.out.println(l2.Subtract(l1).ToFullValue());
        System.out.println(l1.Add(l2).toString());
        System.out.println(l2.Subtract(l1).toString());
    }
}