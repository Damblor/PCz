public class Human
{
    private int age;
    private double weight;
    private double height;
    private String name;
    private String gender;

    public Human()
    {
        this(0,0,0,"Brak","Brak");
    }

    public Human(int age, double weight, double height, String name, String gender)
    {
        this.age = age;
        this.weight = weight;
        this.height = height;
        this.name = name;
        this.gender = gender;
    }

    public int getAge() {return age;}
    public double getWeight() {return weight;}
    public double getHeight() {return Math.round(height);}
    public String getName() {return name;}
    public String getGender() {return gender;}

    public void setWeight(double weight) {this.weight += weight;}
    public void setHeight(double height) {this.height += height;}

    public void view()
    {
        System.out.println(getName() + " age:" + getAge() + " weight:" + getWeight() + " height:" + getHeight());
    }

    public String view(boolean isString)
    {
        return getName() + " age:" + getAge() + " weight:" + getWeight() + " height:" + getHeight();
    }
}
