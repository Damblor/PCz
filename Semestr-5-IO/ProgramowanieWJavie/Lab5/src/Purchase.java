import java.util.Enumeration;

public class Purchase
{
    private int id;
    private String name;
    private int quantity;
    private double price;

    public int getId()
    {
        return id;
    }

    public Purchase(int id, String name, int quantity, double price)
    {
        this.id = id;
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }

    public double CalculatePrice()
    {
        return quantity * price;
    }

    @Override
    public String toString()
    {
        return "Purchase: id=" + id + ", name=" + name + ", number=" + quantity + ", amount=" + price;
    }
}
