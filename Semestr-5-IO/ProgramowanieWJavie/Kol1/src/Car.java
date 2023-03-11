public class Car
{
    public String VIN;
    public String brand;
    public Engine engine;
    public String owner;
    public int year;
    public double mileage;

    public String getOwner()
    {
        return owner;
    }

    public int getYear()
    {
        return year;
    }

    public double getMileage()
    {
        return mileage;
    }

    public Car(String VIN, String brand, Engine engine, String owner, int year, double mileage)
    {
        this.VIN = VIN;
        this.brand = brand;
        this.engine = engine;
        this.owner = owner;
        this.year = year;
        this.mileage = mileage;
    }

    public String toString()
    {
        return "VIN: " + this.VIN + " " + this.brand + " " + this.owner + " " + this.engine + " mileage: " + this.mileage + " production: " + this.year;
    }
}
