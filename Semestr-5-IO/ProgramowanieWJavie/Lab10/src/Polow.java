import java.util.Calendar;
import java.util.Locale;

public class Polow
{
    private int dzienPolowu;
    private int miesiacPolowu;
    private int rokPolowu;
    private String nazwaGatunkuRyby;
    private String daneWedkarza;
    private double wagaRyby;
    private double dlugoscRyby;

    private Calendar date = Calendar.getInstance();

    public int getDzienPolowu()
    {
        return dzienPolowu;
    }

    public int getMiesiacPolowu()
    {
        return miesiacPolowu;
    }

    public int getRokPolowu()
    {
        return rokPolowu;
    }

    public String getNazwaGatunkuRyby()
    {
        return nazwaGatunkuRyby;
    }

    public String getDaneWedkarza()
    {
        return daneWedkarza;
    }

    public double getWagaRyby()
    {
        return wagaRyby;
    }

    public double getDlugoscRyby()
    {
        return dlugoscRyby;
    }

    public Calendar getDate()
    {
        return date;
    }

    public Polow(int dzienPolowu, int miesiacPolowu, int rokPolowu,
                 String nazwaGatunkuRyby, String daneWedkarza,
                 double wagaRyby, double dlugoscRyby)
    {
        this.dzienPolowu = dzienPolowu;
        this.miesiacPolowu = miesiacPolowu;
        this.rokPolowu = rokPolowu;
        this.nazwaGatunkuRyby = nazwaGatunkuRyby;
        this.daneWedkarza = daneWedkarza;
        this.wagaRyby = wagaRyby;
        this.dlugoscRyby = dlugoscRyby;

        date.set(rokPolowu, miesiacPolowu, dzienPolowu);
    }

    public String getDayOfTheWeek()
    {
        return date.getDisplayName(Calendar.DAY_OF_WEEK, Calendar.LONG, Locale.getDefault());
    }

    @Override
    public String toString()
    {
        return "Połów: " + dzienPolowu + "." + miesiacPolowu + "." + rokPolowu + " (" + getDayOfTheWeek() + "), gatunek: " + nazwaGatunkuRyby + ", wedkarz: " + daneWedkarza + ", waga: " + wagaRyby + "kg., długość: " + dlugoscRyby + "cm.";
    }
}
