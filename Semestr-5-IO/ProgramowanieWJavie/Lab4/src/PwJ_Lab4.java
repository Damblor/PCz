import java.util.ArrayList;
import java.util.Collections;
import java.util.Objects;
import java.util.Scanner;

public class PwJ_Lab4
{
    public static void main(String[] args)
    {
        ArrayList<String> teams = new ArrayList<>();
        teams.add("Warta Czestochowa");
        teams.add("Gryf Poznan");
        teams.add("Wisla Katowice");
        teams.add("Pilica Piotrkow Trybunalski");
        teams.add("San Krakow");
        System.out.println("Lista (referencyjna) klubow:");
        System.out.println("Przed sortowaniem");
        for (String team : teams)
        {
            System.out.print(team + ", ");
        }
        System.out.println("\nPo sortowaniu");
        Collections.sort(teams);
        for (String team : teams)
        {
            System.out.print(team + ", ");
        }
        System.out.println();

        ArrayList<Player> players = new ArrayList<>();
        Scanner in = new Scanner(System.in);

        while (true)
        {
            try
            {
                Player p = AddPlayer(in, teams);
                players.add(p);
            }
            catch (Exception ex)
            {
                System.out.println(ex.getMessage());
            }

            System.out.println("Chcesz wprowadzic dane kolejnego zawodnika (t/n)?");
            String bool = in.nextLine();

            if(Objects.equals(bool, "n")) break;
        }

        players.forEach(System.out::println);
        in.close();
    }

    private static Player AddPlayer(Scanner in, ArrayList<String> teams) throws Exception
    {
        String name, team_name, ex = "Anulowanie wpisu! Nieprawidlowe dane zawodnika: ";
        int age, n_goals;
        double avg_n_minutes;
        System.out.println("Podaj personalia");
        name = in.nextLine();
        System.out.println("Podaj nazwe druzyny");
        team_name = in.nextLine();
        System.out.println("Podaj wiek zawodnika");
        age = GetAge(in);
        System.out.println("Podaj liczbe zdobytych bramek przez zawodnika");
        n_goals = GetGoals(in);
        System.out.println("Podaj srednia liczbe minut spedzonych przez zawodnika na boisku");
        avg_n_minutes = GetMinutes(in);
        //in.nextLine();
        if(Objects.equals(name, "")) throw new Exception(ex + "Brak informacji o danych personalnych zawodnika.");
        if(!teams.contains(team_name)) throw new Exception(ex + "Nazwa druzyny nie znajduje sie na liscie druzyn.");
        if(age < 16 || age > 60) throw new Exception(ex + "Dopuszczalny wiek zawodnika to od 16 do 60 lat.");
        if(n_goals < 0) throw new Exception(ex + "Liczba goli nie moze byc ujemna.");
        if(avg_n_minutes < 0 || avg_n_minutes > 90) throw new Exception(ex + "Dopuszczalny czas spedzony na boisku to od 0 do 90 min.");

        return new Player(name, team_name, age, n_goals, avg_n_minutes);
    }

    private static int GetAge(Scanner in)
    {
        try
        {
            return Integer.parseInt(in.nextLine());
        }
        catch (Exception e1)
        {
            try
            {
                System.out.println("Uwaga. Zastosowano nieprawidlowy format danych!");
                System.out.println("Jeszcze raz podaj wiek zawodnika (inaczej zostanie przypisana wartosc " + Player.DefaultAge);
                return Integer.parseInt(in.nextLine());
            }
            catch (Exception e2)
            {
                System.out.println("Uwaga po drugiej blednej wartosci wiek ustalono na poziomie domyslnym " + Player.DefaultAge + " lat.");
                return Player.DefaultAge;
            }
        }
    }

    private static int GetGoals(Scanner in)
    {
        try
        {
            return Integer.parseInt(in.nextLine());
        }
        catch (Exception e1)
        {
            try
            {
                System.out.println("Uwaga. Zastosowano nieprawidlowy format danych!");
                System.out.println("Jeszcze raz podaj liczbe bramek zawodnika (inaczej zostanie przypisana wartosc " + Player.DefaultNGoals);
                return Integer.parseInt(in.nextLine());
            }
            catch (Exception e2)
            {
                System.out.println("Uwaga po drugiej blednej wartosci liczbe bramek ustalono na poziomie domyslnym " + Player.DefaultNGoals);
                return Player.DefaultNGoals;
            }
        }
    }

    private static double GetMinutes(Scanner in)
    {
        try
        {
            return Double.parseDouble(in.nextLine());
        }
        catch (Exception e1)
        {
            try
            {
                System.out.println("Uwaga. Zastosowano nieprawidlowy format danych!");
                System.out.println("Jeszcze raz podaj srednia liczbe minut (inaczej zostanie przypisana wartosc " + Player.DefaultAvgNMinutes);
                return Double.parseDouble(in.nextLine());
            }
            catch (Exception e2)
            {
                System.out.println("Uwaga po drugiej blednej wartosci srednia liczbe minut  ustalono na poziomie domyslnym " + Player.DefaultAvgNMinutes);
                return Player.DefaultAvgNMinutes;
            }
        }
    }



}