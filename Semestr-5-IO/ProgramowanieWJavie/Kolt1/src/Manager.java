import java.time.LocalDate;

public class Manager extends Employee
{
    public double bonus;
    public Manager(int id_employee, String name, Workstation position, int department, LocalDate hireDay, double bonus)
    {
        super(id_employee, name, position, department, hireDay);
        this.bonus = bonus;
    }

    public String toString()
    {
        return String.format("Manager: %s,\n\tbonus: %s zł.", super.toString(), bonus);
    }
}
