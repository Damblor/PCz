import java.util.Scanner;

public class PwJ_Lab3
{
    public static void main(String[] args)
    {
        double r, a, b, c;
        String color;
        Scanner in = new Scanner(System.in);

        System.out.print("Podaj kolor kola: ");
        color = in.nextLine();
        System.out.print("Podaj promien kola: ");
        r = in.nextDouble();
        Circle circle = new Circle(color, r);
        circle.count_Circumference();
        circle.count_surface();
        circle.viewData();

        in.nextLine();
        System.out.print("Podaj kolor prostokata: ");
        color = in.nextLine();
        System.out.print("Podaj wymiar boku A: ");
        a = in.nextDouble();
        System.out.print("Podaj wymiar boku B: ");
        b = in.nextDouble();
        Rectangle rectangle = new Rectangle(color, a ,b);
        rectangle.count_Circumference();
        rectangle.count_surface();
        rectangle.viewData();

        in.nextLine();
        System.out.print("Podaj kolor trojkata: ");
        color = in.nextLine();
        System.out.print("Podaj wymiar boku A: ");
        a = in.nextDouble();
        System.out.print("Podaj wymiar boku B: ");
        b = in.nextDouble();
        System.out.print("Podaj wymiar boku C: ");
        c = in.nextDouble();
        try
        {
            Triangle triangle = new Triangle(color, a, b, c);
            triangle.count_Circumference();
            triangle.count_surface();
            triangle.viewData();
        }
        catch (Exception ex)
        {
            System.out.println(ex);
        }

        in.close();
    }
}
