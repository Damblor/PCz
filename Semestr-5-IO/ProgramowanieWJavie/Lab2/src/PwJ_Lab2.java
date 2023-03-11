public class PwJ_Lab2
{
    public static void main(String[] args)
    {
        Human[] humans = new Human[5];
        humans[0] = new Human(32,78.4,175,"Jan Nowak","Mr");
        humans[1] = new Human(34,62.1,167,"Olga Polak","Ms");
        humans[2] = new Human(21,58.3,164,"Anna Jaworska","Ms");
        humans[3] = new Human(56,89.4,181,"Tomasz Adamczyk","Mr");
        humans[4] = new Human(19,76.9,183,"Roman Tokarz","Mr");

        for (Human human : humans)
        {
            human.view();
        }
        viewAvgWeight(humans);
        System.out.println("******************************************************");
        for (Human human : humans)
        {
            System.out.println("Po aktualizacji wagi i wzrostu");
            human.setWeight(valueChange(-10, 10));
            human.setHeight(valueChange(-20, 20));
            System.out.println(" -> " + human.view(true));
            //human.view();
        }
        viewAvgWeight(humans);
        for(int i = 0; i < humans.length - 1; i++)
        {
            for(int j = 0; j < humans.length - i - 1; j++)
            {
                if(humans[j].getHeight() < humans[j + 1].getHeight())
                {
                    Human temp = humans[j];
                    humans[j] = humans[j + 1];
                    humans[j + 1] = temp;
                }
            }
        }
        for (Human human : humans)
        {
            human.view();
        }
    }

    public static double valueChange(double min, double max)
    {
        return (Math.random() * (max - min) + min);
    }

    public static double avgWeight(Human[] humans, String gender)
    {
        double avg = 0;
        int l = 0;
        if(gender.equals("All"))
        {
            for (Human human : humans)
            {
                avg += human.getWeight();
                l++;
            }
        }
        else
        {
            for (Human human : humans)
            {
                if (human.getGender().equals(gender))
                {
                    avg += human.getWeight();
                    l++;
                }
            }
        }

        return l == 0 ? 0 : avg / l;
    }

    public static void viewAvgWeight(Human[] humans)
    {
        System.out.println(" *** Srednia waga mezczyzn: " + avgWeight(humans, "Mr"));
        System.out.println(" *** Srednia waga kobiet: " + avgWeight(humans, "Ms"));
        System.out.println(" *** Srednia waga wszystkich: " + avgWeight(humans, "All"));
    }
}
