public class PwJ_Lab12
{
    public static final int DELAY = 50;
    public static final int STEPS = 400;

    public static void main(String[] args)
    {
        Factory factory = new Factory();

        Runnable supplier = () ->
        {
            try
            {
                for (int i = 0; i < STEPS; i++)
                {
                    if(factory.sources[0] == 0 && factory.sources[1] == 0)
                    {
                        System.out.println(Thread.currentThread() + "Brak materiałów w źródłach");
                        return;
                    }
                    int source = (int) (Math.random() * 2) + 1;
                    int amount = (int) (Math.random() * 200) + 100;
                    factory.transferFromSourceToWarehouse(source, amount);
                    Thread.sleep((int) (Math.random() * DELAY));

                }
                System.out.println(Thread.currentThread() + "Koniec dostaw");
            }
            catch (InterruptedException e)
            {
                e.printStackTrace();
            }
        };

        Runnable producer = () ->
        {
            try
            {
                for (int i = 0; i < STEPS; i++)
                {
                    int product = (int) (Math.random() * 3);
                    if(factory.sources[0] == 0 && factory.sources[1] == 0 && factory.SourceWarehouse < factory.ProductCosts[product])
                    {
                        System.out.println(Thread.currentThread() + "Brak materiałów w źródłach i w magazynie");
                        return;
                    }
                    factory.produceProduct(Produkt.values()[product]);
                    Thread.sleep((int) (Math.random() * DELAY));
                }
            }
            catch (InterruptedException e)
            {
                e.printStackTrace();
            }
        };

        Thread[] threads = new Thread[5];

        for (int i = 0; i < 3; i++)
        {
            threads[i] = new Thread(supplier, "Supplier " + (i + 1));
        }

        for (int i = 3; i < 5; i++)
        {
            threads[i] = new Thread(producer, "Producer " + (i - 2));;
        }

        for (int i = 0; i < 5; i++)
        {
            threads[i].start();
        }

        for (int i = 0; i < 5; i++)
        {
            try
            {
                threads[i].join();
            }
            catch (InterruptedException e)
            {
                e.printStackTrace();
            }
        }
    }
}