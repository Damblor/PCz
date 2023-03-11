public class Rectangle extends Figure
{
    private double a, b;

    public void setA(double a)
    {
        this.a = a;
    }
    public void setB(double b)
    {
        this.b = b;
    }

    public Rectangle()
    {
        super();
    }

    public Rectangle(String color)
    {
        super(color);
    }
    public Rectangle(String color, double a, double b)
    {
        super(color);
        this.a = a;
        this.b = b;
    }

    public void count_Circumference()
    {
        setCircumference(2 * a + 2 * b);
    }

    public void count_surface()
    {
        setSurface_area(a * b);
    }

    @Override
    public void viewData()
    {
        System.out.println("Prostokat w kolorze " + getColor() + " ma obwod: " + getCircumference() + " a powierzchnia jego pola wynosi: " + getSurface_area());
    }
}
