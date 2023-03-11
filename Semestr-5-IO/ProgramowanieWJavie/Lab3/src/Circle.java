public class Circle extends Figure
{
    private double r;

    public void setR(double r)
    {
        this.r = r;
    }

    public Circle()
    {
        super();
    }

    public Circle(String color)
    {
        super(color);
    }

    public Circle(String color, double r)
    {
        super(color);
        this.r = r;
    }

    public void count_Circumference()
    {
        setCircumference(Math.PI * r * 2);
    }

    public void count_surface()
    {
        setSurface_area(Math.PI * Math.pow(r,2));
    }

    @Override
    public void viewData()
    {
        System.out.println("Kolo w kolorze " + getColor() + " ma obwod: " + getCircumference() + " a powierzchnia jego pola wynosi: " + getSurface_area());
    }
}
