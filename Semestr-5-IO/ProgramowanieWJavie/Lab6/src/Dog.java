public class Dog extends Animal
{
    private int factor;

    public Dog(String name, double weight, int age, int factor)
    {
        super(name, weight, age);
        this.factor = factor;
        setBMI();
    }

    @Override
    public String toString()
    {
        return super.toString() + " pies poziom " + factor;
    }

    @Override
    public double getBMI()
    {
        return bmi;
    }

    @Override
    public void setBMI()
    {
        if (factor == 1)
            bmi = Math.pow(weight, 3);
        else if (factor == 2)
            bmi = Math.pow(weight, 2);
        else if (factor == 3)
            bmi = weight + 10;
    }

    @Override
    public double getAge()
    {
        return age;
    }

    @Override
    public String viewAlarm()
    {
        if(bmi > 30)
            return "ALARM. Otyłość! ";
        else
            return "";
    }
}
