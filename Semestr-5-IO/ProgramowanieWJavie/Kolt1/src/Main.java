import java.io.File;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Comparator;
import java.util.Scanner;
import java.util.function.Function;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Main
{
    public static void main(String[] args)
    {
        ArrayList<Employee> employees = loadDataFromFile("Employees.txt");
        ArrayList<Employee> managers = loadDataFromFile("Managers.txt");
        ArrayList<Employee> company = Stream.concat(employees.stream(), managers.stream()).collect(Collectors.toCollection(ArrayList::new));
        company.forEach(System.out::println);

        Scanner in = new Scanner(System.in);
        System.out.println("Podaj wartość podwyżki dla pracowników obsługi ( w procentach):");
        int percentage = in.nextInt();

        company.stream().filter(e -> !(e instanceof Manager)).forEach(e -> {
            System.out.print("Przed podwyżką: ");
            System.out.println(e);
            e.updateSalary(percentage);
            System.out.print("\tPo podwyżce: ");
            System.out.println(e);
        });

        var pensja = company.stream().filter(e -> e.department == 10 && e.position.salary > 5000).collect(Collectors.toSet());
        var sumPensja = pensja.stream().map(e -> e.position.salary).reduce(0.0, Double::sum);
        System.out.println("Suma pensji pracowników z działu 10, których pensja jest większa niż 5000: " + sumPensja);
        pensja.forEach(e -> System.out.println(e.position.salary));

        company.stream().sorted(Comparator.comparing(Employee::getDepartment).thenComparing(Comparator.comparing(Employee::getSalary).reversed())).forEach(System.out::println);
    }

    public static ArrayList<Employee> loadDataFromFile(String path)
    {
        ArrayList<Employee> employees = new ArrayList<>();
        File file = new File(path);
        if (!file.exists()) return employees;
        try
        {
            Scanner scanner = new Scanner(file);
            while (scanner.hasNext())
            {
                String line = scanner.nextLine();
                String[] data = line.split(" ");
                int id_employee = Integer.parseInt(data[0]);
                String name = data[1] + " " + data[2];
                Workstation position = new Workstation(data[3], Double.parseDouble(data[4]), Integer.parseInt(data[5]));
                int department = Integer.parseInt(data[6]);
                LocalDate hireDay = LocalDate.of(Integer.parseInt(data[7]), Integer.parseInt(data[8]), Integer.parseInt(data[9]));
                if (data.length == 11)
                {
                    double bonus = Double.parseDouble(data[10]);
                    employees.add(new Manager(id_employee, name, position, department, hireDay, bonus));
                }
                else
                {
                    employees.add(new Employee(id_employee, name, position, department, hireDay));
                }

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