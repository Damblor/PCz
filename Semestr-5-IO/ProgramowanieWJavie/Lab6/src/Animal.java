public abstract class Animal implements Dietican
{
    protected String name;
    protected double weight;
    protected int age;
    public double bmi;

    public Animal(String name, double weight, int age)
    {
        this.name = name;
        this.weight = weight;
        this.age = age;
    }

    @Override
    public String toString()
    {
        return viewAlarm() +  "Zwierze " + name + " o wadze " + weight + " i wieku " + age + " ma BMI=" + bmi + ",";
    }
}
