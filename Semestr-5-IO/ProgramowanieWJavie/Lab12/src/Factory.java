public class Factory
{
    public int[] sources = {50000, 50000};
    public int SourceWarehouse = 0;
    public int SourceWarehouseMaxCapacity = 5000;
    public int[] ProductWarehouses = {0, 0, 0};
    public int[] ProductCosts = { 120, 250, 500 };

    public synchronized void transferFromSourceToWarehouse(int source, int amount) throws InterruptedException
    {
        if (sources[source - 1] < amount)
        {
            amount = sources[source - 1];
            sources[source - 1] = 0;
        }
        else sources[source - 1] -= amount;

        System.out.println(Thread.currentThread() + ": pobrałem " + amount + " jednostek ze źródła nr " + source + "(w magazynie pozostało: " + sources[source - 1] + " sztuk)");

        while (SourceWarehouse + amount > SourceWarehouseMaxCapacity)
        {
            System.out.println(" <-> " + Thread.currentThread() + "Czekam z dostawą " + amount + " szt. do magazynu surowców (akt. w magazynie " + SourceWarehouse + ").");
            wait();
        }

        SourceWarehouse += amount;
        System.out.println(Thread.currentThread() + ": Dostarczyłęm " + amount + " szt. Stan magazynu to surowców to " + SourceWarehouse + " szt.");

        notifyAll();
    }

    public synchronized void produceProduct(Produkt produkt) throws InterruptedException
    {
        while (SourceWarehouse < ProductCosts[produkt.getValue()])
        {
            System.out.println("  !!   " + Thread.currentThread() + ": Czekam na materiały, chcę wyprodukować Produkt " + produkt);
            if(sources[0] == 0 && sources[1] == 0 && SourceWarehouse < ProductCosts[produkt.getValue()])
            {
                return;
            }
            wait();
        }

        SourceWarehouse -= ProductCosts[produkt.getValue()];
        System.out.println("  (+)  " + Thread.currentThread() + ": Wyprodukowałem Produkt " + produkt);
        ProductWarehouses[produkt.getValue()]++;
        System.out.println("  (+)  " + Thread.currentThread() + ": Złożyłem w magazynie Produkt " + produkt + " Bilans produkcji: A " + ProductWarehouses[0] + "szt., B " + ProductWarehouses[1] + "szt., C " + ProductWarehouses[2] + "szt.");

        notifyAll();
    }
}
