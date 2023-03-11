import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;

public class PwJ_Lab10
{
    public static void main(String[] args)
    {
        ArrayList<Polow> polowy = loadData("fishing.txt");

        System.out.println("Dane połowów ryb (układ pierwotny):");
        polowy.stream().forEach(System.out::println);

        System.out.println("\nDane posortowane po wedkarzu i dacie polowu:");
        Function<Polow, String> byFisherman = Polow::getDaneWedkarza;
        Function<Polow, Calendar> byDate = Polow::getDate;
        Comparator<Polow> byFishermanThenDate = Comparator.comparing(byFisherman).thenComparing(byDate);
        polowy.stream().sorted(byFishermanThenDate).forEach(System.out::println);

        System.out.println("\nUnikatowe nazwy ryb alfabetycznie:");
        polowy.stream().map(Polow::getNazwaGatunkuRyby).distinct().sorted().forEach(System.out::println);

        System.out.println("\nDane połowów szczupaków o wadze od 1kd do 2kg (od najnowszego połowu:");
        polowy.stream().filter(p -> p.getNazwaGatunkuRyby().contentEquals("szczupak"))
                .filter(p -> p.getWagaRyby() >= 1 && p.getWagaRyby() <= 2).forEach(System.out::println);

//        System.out.println("\nDane połowów szczupaków o wadze od 1kd do 2kg (od najnowszego połowu:");
//        polowy.stream().filter(p -> p.getNazwaGatunkuRyby().contentEquals("szczupak"))
//                .filter(p -> p.getWagaRyby() >= 1 && p.getWagaRyby() <= 2)
//                .sorted(Comparator.comparing(Polow::getDate).reversed())
//                .forEach(System.out::println);

        System.out.println("\nPołowy pogrupowane po dniu tygodnia:");
        polowy.stream().collect(Collectors.groupingBy(Polow::getDayOfTheWeek))
                .forEach( (dayOfTheWeek, pol) -> {
                    System.out.println(dayOfTheWeek);
                    pol.forEach( p -> System.out.println(p));
                });

        System.out.println("\nLiczba ryb powyżej 50 cm:");
        polowy.stream().filter(p -> p.getDlugoscRyby() >= 50)
                .collect(Collectors.groupingBy(Polow::getDaneWedkarza, Collectors.counting()))
                .forEach( (fisherman, count) -> {
                    System.out.println("Wedkarz " + fisherman + " złowił " + count + " ryby");
                });

        System.out.println("\nŁączna waga szczupaków i sandaczy:");
        var c = polowy.stream().filter(p -> p.getNazwaGatunkuRyby().contentEquals("szczupak") || p.getNazwaGatunkuRyby().contentEquals("sandacz"))
                .map(Polow::getWagaRyby)
                .reduce(0.0, (x, y) -> x + y );
        System.out.println("Łączna waga złowionych szczupaków i szndaczy to " + c + "kg.");

        System.out.println("\nŚrednie długości ryb złowionych w poszczególne dni tygodnia:");
        polowy.stream().collect(Collectors.groupingBy(Polow::getDayOfTheWeek))
                .forEach( (dayOfTheWeek, pol) -> {
                    System.out.println(dayOfTheWeek);
                    var avg = pol.stream().map(Polow::getDlugoscRyby).reduce(0.0, (x, y) -> x + y) / pol.size();
                    var count = pol.stream().count();
                    var min = pol.stream().map(Polow::getDlugoscRyby).min(Double::compare).get();
                    var max = pol.stream().map(Polow::getDlugoscRyby).max(Double::compare).get();
                    System.out.println("Średnia długość ryb " + avg + "cm., liczba ryb: " + count + ", min: " + min + "cm., max: " + max + "cm.");
                });
    }

    public static ArrayList<Polow> loadData(String path)
    {
        ArrayList<Polow> polowy = new ArrayList<>();
        var file = new File(path);
        try
        {
            Scanner in = new Scanner(file, "UTF-8");
            in.useLocale(new Locale("en"));
            while (in.hasNext())
            {
                var pol = new Polow(in.nextInt(), in.nextInt(), in.nextInt(), in.next(), in.next(), in.nextDouble(), in.nextDouble());
                polowy.add(pol);
            }
            in.close();
        }
        catch (FileNotFoundException e)
        {
            throw new RuntimeException(e);
        }

        return polowy;
    }
}