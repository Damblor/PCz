public class Customer
{
    private int id;
    private String name;
    private String last_name;
    private String address;

    public int getId()
    {
        return id;
    }

    public Customer(int id, String name, String last_name, String address)
    {
        this.id = id;
        this.name = name;
        this.last_name = last_name;
        this.address = address;
    }

    public String getData()
    {
        return name + " " + last_name + " " + address;
    }

    @Override
    public String toString()
    {
        return "Customer: id=" + id + ", name=" + name + ", last_name=" + last_name + ", address=" + address;
    }
}
