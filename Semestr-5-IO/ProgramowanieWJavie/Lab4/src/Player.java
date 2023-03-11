public class Player
{
    private String name;
    private String team_name;
    private int age;
    private int n_goals;
    private double ave_n_minutes;

    public static int DefaultAge = 16;
    public static int DefaultNGoals = 0;
    public static double DefaultAvgNMinutes = 0;

    public Player(String name, String team_name, int age, int n_goals, double ave_n_minutes)
    {
        this.name = name;
        this.team_name = team_name;
        this.age = age;
        this.n_goals = n_goals;
        this.ave_n_minutes = ave_n_minutes;
    }

    @Override
    public String toString()
    {
        return "Player: name=" + name +
                ", team=" + team_name +
                ", age=" + age +
                ", goals=" + n_goals +
                ", avg. minutes=" + ave_n_minutes;
    }
}
