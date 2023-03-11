import java.io.File;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Main
{
    public static void main(String[] args)
    {
        ArrayList<Car> cars = new ArrayList<>();
        LoadCars(cars, "RC_Data.txt");
        LoadCars(cars, "Cars_Data.txt");

        System.out.println("Lista wszystkich samochodów:");
        cars.forEach(System.out::println);

        Scanner in = new Scanner(System.in);
        System.out.println("\nPodaj wysokość zmiany przebiegu standardowych pojazdów (w procentach):");
        double mileageChangePercent = Double.parseDouble(in.nextLine());
        in.close();
        cars.stream()
                .filter(c -> !(c instanceof RallyCar))
                .forEach(c -> {
                    System.out.print("Przed zmianą: ");
                    System.out.println(c);
                    c.mileage += c.mileage * mileageChangePercent / 100;
                    System.out.print("\tPo zmianie: ");
                    System.out.println(c);
                });

        var fullMileage = cars.stream()
                .filter(c -> c.brand.equals("Ford") && c.year > 2018)
                .mapToDouble(c -> c.mileage)
                .sum();
        System.out.println("\nŁączny przebieg pojazdów marki FORD wyprodukowanych po 2018 roku to " + fullMileage + " km.");
        System.out.println("\nLista pojazdów:");
        cars.stream()
                .filter(c -> c.brand.equals("Ford") && c.year > 2018)
                .forEach(System.out::println);

        System.out.println("\nLista pojazdów posortowana kolejno po właścicielu, roku produkcji i przebiegu:");
        cars.stream()
                .sorted(Comparator.comparing(Car::getOwner)
                        .thenComparing(Car::getYear)
                        .thenComparing(Car::getMileage))
                .forEach(System.out::println);

        cars.stream().collect(Collectors.groupingBy(c -> c.owner))
                .forEach((owner, carsList) -> {
                    var averageMileage = carsList.stream()
                            .mapToDouble(c -> c.mileage)
                            .average()
                            .getAsDouble();
                    var oldestCar = carsList.stream()
                            .min(Comparator.comparing(Car::getYear))
                            .get().year;
                    var  newestCar = carsList.stream()
                            .max(Comparator.comparing(Car::getYear))
                            .get().year;
                    System.out.println("\n" + owner + " liczba pojazdów " + carsList.size() + " średni przebieg " + averageMileage + " najstarszy " + oldestCar + " najnowszy " + newestCar);
                    carsList.stream()
                            .sorted(Comparator.comparing(Car::getYear))
                            .forEach(System.out::println);
                });
    }

    public static void LoadCars(ArrayList<Car> cars, String path)
    {
        File file = new File(path);
        if(!file.exists())
        {
            System.out.println("File not found!");
            return;
        }
        try
        {
            Scanner scanner = new Scanner(file);
            while(scanner.hasNextLine())
            {
                String line = scanner.nextLine();
                String[] data = line.split(" ");
                String VIN = data[0];
                String brand = data[1];
                String engineName = data[2];
                double engineConsumption = Double.parseDouble(data[3]);
                double enginePower = Double.parseDouble(data[4]);
                String owner = data[5] + " " + data[6];
                int year = Integer.parseInt(data[7]);
                double mileage = Double.parseDouble(data[8]);
                if(data.length == 9)
                {
                    Car car = new Car(VIN, brand, new Engine(engineName, engineConsumption, enginePower), owner, year, mileage);
                    cars.add(car);
                }
                else if(data.length == 11)
                {
                    double consumptionChange = Double.parseDouble(data[9]);
                    double powerChange = Double.parseDouble(data[10]);
                    RallyCar car = new RallyCar(VIN, brand, new Engine(engineName, engineConsumption, enginePower), owner, year, mileage, consumptionChange, powerChange);
                    cars.add(car);
                }
            }
            scanner.close();
        }
        catch(Exception e)
        {
            System.out.println("Error: " + e.getMessage());
        }

    }
}