import java.util.Scanner;

public class Main
{
    public static void main(String[] args)
    {
        System.out.println("Działania podawanie w formacie: <liczba1> <operator> <liczba2>");
        System.out.println("Np: 2.5 + 3.2 lub 1.2 * 2");
        System.out.println("Uwaga: Lokalizacja dziesiętna to kropka! Polskie przecinki nie są obsługiwane!");
        System.out.println("Dostępne operatory: +, -, *, /");
        System.out.println("Aby zakończyć działanie programu wpisz q");
        Scanner scanner = new Scanner(System.in);
        while (true) {
            System.out.print("Podaj działanie: ");
            String input = scanner.nextLine();
            String[] inputArray = input.split(" ");
            if (inputArray[0].equals("q")) break;
            if (inputArray.length != 3) {
                System.out.println("Nieprawidłowa liczba argumentów!");
                continue;
            }
            double d1, d2;
            try {
                d1 = Double.parseDouble(inputArray[0]);
            } catch (NumberFormatException e) {
                System.out.println("Błąd: Nieprawidłowy format pierwszej liczby!");
                continue;
            }
            try {
                d2 = Double.parseDouble(inputArray[2]);
            } catch (NumberFormatException e) {
                System.out.println("Błąd: Nieprawidłowy format drugiej liczby!");
                continue;
            }
            char op = inputArray[1].charAt(0);
            Calculator calc = new Calculator();
            try {
                double result = calc.Calculate(d1, d2, op);
                System.out.println("Wynik: " + result);
            } catch (IllegalArgumentException | ArithmeticException e) {
                System.out.println("Błąd: " + e.getMessage());
            }
        }
    }
}