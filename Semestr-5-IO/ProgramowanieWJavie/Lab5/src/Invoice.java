import java.util.ArrayList;

public class Invoice
{
    private double sum = 0;
    private Customer customer;
    private ArrayList<Purchase> purchases;

    public Invoice(Customer customer, ArrayList<Purchase> purchases)
    {
        this.customer = customer;
        this.purchases = purchases;
        CalculatePrices();
    }

    private void CalculatePrices()
    {
        for (Purchase purchase : purchases)
        {
            sum += purchase.CalculatePrice();
        }
    }

    @Override
    public String toString()
    {
        return "Invoice. id_customer " + customer.getId() + "\n" + customer.getData() + "\nnumber trans. " + purchases.size() + ", sum amount " + sum + " PLN";
    }
}
