public class Zad3
{
    public static void main(String[] args)
    {
        String st = "To jest wybrany napis.";
        System.out.println(st);
        System.out.println("Dlugosc = " + st.length());
        System.out.println("Dlugosc bez spacji = " + st.strip().length());
        System.out.println("Znak na pozycji 5 = " + st.charAt(4));
    }
}
