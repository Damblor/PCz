public abstract class Figure
{
    private String color;
    private double surface_area;
    private double circumference;

    public Figure()
    {
        this("Brak");
    }

    public Figure(String color)
    {
        this.color = color;
    }

    public String getColor()
    {
        return color;
    }

    public double getSurface_area()
    {
        return surface_area;
    }

    public double getCircumference()
    {
        return circumference;
    }

    public void setColor(String color)
    {
        this.color = color;
    }

    public void setSurface_area(double surface_area)
    {
        this.surface_area = surface_area;
    }

    public void setCircumference(double circumference)
    {
        this.circumference = circumference;
    }

    public abstract void viewData();
}
