public class Person implements Dietican
{
    private String personalData;
    private int age;
    private double height;
    private double weight;
    private  double bmi;

    public Person(String personalData, int age, double height, double weight)
    {
        this.personalData = personalData;
        this.age = age;
        this.height = height;
        this.weight = weight;
        setBMI();
    }

    @Override
    public String toString()
    {
        return viewAlarm() + "Osoba: " + personalData + " (" + age + " lat; " + weight + " kg.; " + height + " cm.) BMI=" + bmi;
    }

    @Override
    public double getBMI()
    {
        return bmi;
    }

    @Override
    public void setBMI()
    {
        bmi = (weight) / (Math.pow((height * 0.01), 2));
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
