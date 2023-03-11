import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.*;

public class PwJ_Lab7
{
    public static void main(String[] args)
    {
//        var employees = new ArrayList<Employee>();
//        employees.add(new Employee("Nowak Jan", 1.0, 5200.0, 24, "Kierowca"));
//        employees.add(new Employee("Piech Anna", 0.7, 4800.0, 29, "Księgowa"));
//        employees.add(new Employee("Jach Ewa", 1.2, 6000.0, 27, "Księgowa"));
//        employees.add(new Employee("Rak Piotr", 1.25, 4000.0, 21, "Kierowca"));
//        employees.add(new Employee("Maj Jan", 0.5, 7000.0, 52, "Kierownik"));
//        employees.add(new Employee("Bąk Olga", 1.0, 6000.0, 29, "Księgowa"));

        var employees = LoadData();

        System.out.println("Na starcie");
        employees.forEach(e -> System.out.println(e));

        System.out.println("Po policzeniu pensji");
        employees.forEach(e -> e.countSalary());
        employees.forEach(e -> System.out.println(e));

        System.out.println("Po sortowaniu wg pensji (od najniższej)");
        employees.sort((e1, e2) -> Double.compare(e1.getNetSalary(), e2.getNetSalary()));
        employees.forEach(e -> System.out.println(e));

        System.out.println("Po sortowaniu wg stanowiska (alfabetycznie), wieku (nierosnąco) i pensji (nierosnąco)");
        employees.sort(((Comparator<Employee>) (e1, e2) -> e1.getPosition().compareTo(e2.getPosition()))
                .thenComparing(((Comparator<Employee>) (e1, e2) -> Integer.compare(e2.getAge(), e1.getAge()))
                        .thenComparing((e1, e2) -> Double.compare(e2.getNetSalary(), e1.getNetSalary()))));
        employees.forEach(e -> System.out.println(e));

        System.out.println("Po sortowaniu wg wieku (nierosnąco), stanowiska (alfabetycznie) i płacy (nierosnąco)");
        employees.sort(((Comparator.comparing(Employee::getAge)).reversed()
                .thenComparing(Comparator.comparing(Employee::getPosition)
                        .thenComparing(Comparator.comparing(Employee::getSalaryFTE).reversed()))));
        employees.forEach(e -> System.out.println(e));

        String path = "./Lambda.txt";
        try
        {
            PrintWriter printWriter = new PrintWriter(path);
            employees.forEach(e ->
            {
                printWriter.println(" **** zapis lambda ****");
                printWriter.println(e.fileData());
                printWriter.println(" --------------------------");
            });
            printWriter.close();
        }
        catch (FileNotFoundException e)
        {
            System.out.println(e);
        }
    }

    public static ArrayList<Employee> LoadData()
    {
        var employees = new ArrayList<Employee>();
        String path = "Data.txt";
        try
        {
            File file = new File(path);
            Scanner scanner = new Scanner(file);
            while (scanner.hasNext())
            {
                Employee employee = new Employee(scanner.next() + " " + scanner.next(), scanner.nextDouble(), scanner.nextDouble(), scanner.nextInt(),scanner.nextLine().strip());
                employees.add(employee);
            }
            scanner.close();
        }
        catch (Exception e)
        {
            System.out.println(e);
        }
        return employees;
    }
}