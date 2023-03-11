public class Triangle extends Figure
{
    private double a, b, c;

    public void setA(double a)
    {
        this.a = a;
    }
    public void setC(double c)
    {
        this.c = c;
    }
    public void setB(double b)
    {
        this.b = b;
    }

    public Triangle()
    {
        super();
    }

    public Triangle(String color)
    {
        super(color);
    }

    public Triangle(String color, double a, double b, double c) throws Exception
    {
        super(color);
        if(a + b <= c || b + c <= a || a + c <= b)
        {
            throw new Exception("Nie mozna stworzyc trojkata");
        }
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void count_Circumference()
    {
        setCircumference(a + b + c);
    }

    public void count_surface()
    {
        double p = (a + b + c) / 2;
        //double p = getCircumference() / 2;
        setSurface_area(Math.sqrt(p * (p - a) * (p - b) * (p - c)));
    }

    @Override
    public void viewData()
    {
        System.out.println("Trojkat w kolorze " + getColor() + " ma obwod: " + getCircumference() + " a powierzchnia jego pola wynosi: " + getSurface_area());
    }
}
