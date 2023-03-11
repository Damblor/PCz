public class Employee implements Accountant
{
    private String name;
    private String position;
    private int age;
    private double fte;
    private double salaryFTE;
    private double netSalary;

    public String getPosition()
    {
        return position;
    }
    public int getAge()
    {
        return age;
    }
    public double getSalaryFTE()
    {
        return salaryFTE;
    }
    public double getNetSalary()
    {
        return netSalary;
    }

    public Employee(String name, double fte, double salaryFTE, int age, String position)
    {
        this.name = name;
        this.fte = fte;
        this.salaryFTE = salaryFTE;
        this.age = age;
        this.position = position;
    }

    public String fileData()
    {
        return name + " lat: " + age + "\n\t" + position + " etat: " + fte + "\n\tplaca_pod=" + salaryFTE + "PLN -> pensja=" + netSalary + " PLN";
    }

    @Override
    public String toString()
    {
        return name + " lat: " + age + " " + position + " etat:" + fte + " placa_pod=" + salaryFTE + " pensja=" + netSalary;
    }

    @Override
    public void countSalary()
    {
        if(age <= ageLimit)
            netSalary = Math.round(salaryFTE * fte * (1 - hcc));
        else
            netSalary = Math.round(salaryFTE * fte * (1 - ratePIT - hcc));
    }
}
