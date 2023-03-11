public enum Produkt
{
    A(0),
    B(1),
    C(2);

    private int value;

    Produkt(int value)
    {
        this.value = value;
    }

    public int getValue()
    {
        return value;
    }
}
