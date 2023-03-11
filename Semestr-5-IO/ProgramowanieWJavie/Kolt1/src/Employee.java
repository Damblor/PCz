import java.time.LocalDate;

public class Employee
{
    public int id_employee;
    public String name;
    public Workstation position;
    public int department;
    public LocalDate hireDay;

    public int getDepartment()
    {
        return department;
    }

    public double getSalary()
    {
        return position.salary;
    }

    public Employee(int id_employee, String name, Workstation position, int department, LocalDate hireDay)
    {
        this.id_employee = id_employee;
        this.name = name;
        this.position = position;
        this.department = department;
        this.hireDay = hireDay;
    }

    public void updateSalary(double salaryPercent)
    {
        position.salary += position.salary * salaryPercent / 100;
        position.num_hours += position.num_hours * (salaryPercent / 2) / 100;
    }

    public String toString()
    {
        return String.format("ID: %s, %s, %s, depart: %s, pracuje od %s", id_employee, name, position, department, hireDay);
    }
}
