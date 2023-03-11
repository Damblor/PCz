public class Engine
{
    public String name;
    public double consumption;
    public double power;

    public Engine(String name, double consumption, double power)
    {
        this.name = name;
        this.consumption = consumption;
        this.power = power;
    }

    public void ChangeConsumption(double consumptionChangePercent)
    {
        this.consumption += this.consumption * consumptionChangePercent / 100;
    }

    public void ChangePower(double powerChangePercent)
    {
        this.power += this.power * powerChangePercent / 100;
    }

    public String toString()
    {
        return "engine: (" + this.name + " " + this.consumption + " " + this.power + " KM)";
    }
}
