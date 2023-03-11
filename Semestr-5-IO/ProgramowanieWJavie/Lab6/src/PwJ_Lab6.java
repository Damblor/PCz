import java.util.Arrays;
import java.util.Comparator;

public class PwJ_Lab6
{
    public static void main(String[] args)
    {
        Dietican[] tab = new Dietican[]
                {
                        new Person("Kowalski Jan", 45, 178, 83),
                        new Dog("Yeti", 6.0, 4, 2),
                        new Dog("Sonia", 5.1, 7, 2),
                        new Person("Mucha Joanna", 24, 169, 61),
                        new Dog("Azor", 11.3, 5, 3),
                        new Person("Gala Piotr", 34, 184, 91),
                        new Person("Piech Anna", 56, 163, 88),
                        new Dog("Meps", 16.9, 8, 3),
                        new Person("Adamus Jacek", 21, 176, 94),
                        new Dog("Reks", 2.8, 3, 1)
                };

        System.out.println("Lista w pierwotnej kolejności\n");
        for (Dietican dietican : tab)
            System.out.println(dietican);

        //Arrays.sort(tab, (o1, o2) -> Double.compare(o1.getBMI(), o2.getBMI()));

        Arrays.sort(tab, new Comparator<Dietican>()
        {
            @Override
            public int compare(Dietican o1, Dietican o2)
            {
                return Double.compare(o1.getBMI(), o2.getBMI());
            }
        });

        System.out.println("\nLista uporządkowana wg wartości BMI\n");
        for (Dietican dietican : tab)
            System.out.println(dietican);

//        Arrays.sort(tab, ((Comparator<Dietican>) (o1, o2) ->
//        {
//            if (o1 instanceof Animal && o2 instanceof Person)
//                return -1;
//            else if (o1 instanceof Person && o2 instanceof Animal)
//                return 1;
//            else
//                return 0;
//        }).thenComparing((o1, o2) -> Double.compare(o1.getAge(), o2.getAge())));

        Arrays.sort(tab, new Comparator<Dietican>()
        {
            @Override
            public int compare(Dietican o1, Dietican o2)
            {
                if(o1 instanceof Animal && o2 instanceof Person)
                    return -1;
                else if(o1 instanceof Person && o2 instanceof Animal)
                    return 1;
                else
                    return 0;
            }
        }.thenComparing(new Comparator<Dietican>()
        {
            @Override
            public int compare(Dietican o1, Dietican o2)
            {
                return Double.compare(o1.getAge(), o2.getAge());
            }
        }));

        System.out.println("\nLista uporządkowana kolejno wg gatónków i wieku\n");
        for (Dietican dietican : tab)
            System.out.println(dietican);
    }
}