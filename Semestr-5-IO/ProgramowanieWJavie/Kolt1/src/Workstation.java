public class Workstation
{
    public String name;
    public double salary;
    public int num_hours;

    public Workstation(String name, double salary, int num_hours)
    {
        this.name = name;
        this.salary = salary;
        this.num_hours = num_hours;
    }

    public String toString()
    {
        return String.format("(%s sal:  %s zł. pensum: %s h.)", name, salary, num_hours);
    }
}
