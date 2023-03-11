public class RallyCar extends Car
{
    public double consumptionChange;
    public double powerChange;

    public RallyCar(String VIN, String brand, Engine engine, String owner, int year, double mileage, double consumptionChange, double powerChange)
    {
        super(VIN, brand, engine, owner, year, mileage);
        this.consumptionChange = consumptionChange;
        this.powerChange = powerChange;
        this.engine.ChangeConsumption(consumptionChange);
        this.engine.ChangePower(powerChange);
    }

    public String toString()
    {
        return "RC: " +  super.toString() + " \n\tconsumption change: " + this.consumptionChange + " power change: " + this.powerChange;
    }
}
