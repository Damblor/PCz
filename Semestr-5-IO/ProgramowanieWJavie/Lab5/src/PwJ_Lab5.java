import  javax.swing.JOptionPane;
import java.io.*;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.stream.Collectors;

public class PwJ_Lab5
{
    public static void main(String[] args)
    {
        ArrayList<Customer> customers = new ArrayList<>();
        ArrayList<Purchase> purchases = new ArrayList<>();
        ArrayList<Invoice> invoices = new ArrayList<>();

        while (true)
        {
            String customersPath = JOptionPane.showInputDialog("Podaj nazwę pliku zawierającego dane klientów:");
            try
            {
                File customersFile = new File(customersPath);
                Scanner inputCustomersFile = new Scanner(customersFile);
                while (inputCustomersFile.hasNext())
                {
                    Customer customer = new Customer(inputCustomersFile.nextInt(), inputCustomersFile.next(), inputCustomersFile.next(), inputCustomersFile.nextLine());
                    customers.add(customer);
                }
                inputCustomersFile.close();
                break;
            }
            catch (NullPointerException nex)
            {
                System.exit(1);
            }
            catch (Exception ex)
            {
                int selection = JOptionPane.showConfirmDialog(null, "Brak podanego pliku" + customersPath + "\nCzy chcesz podać nazwę jeszcze raz?\nOpcja NO spowoduje wyłączenie programu.", "Błąd otwarcia pliku", JOptionPane.YES_NO_OPTION, JOptionPane.NO_OPTION);
                if (selection == 1) System.exit(1);
            }
        }

        for (Customer customer : customers)
            System.out.println(customer);


        while (true)
        {
            String purchasePath = JOptionPane.showInputDialog("Podaj nazwę pliku zawierającego dane zakupów:");
            try
            {
                File purchaseFile = new File(purchasePath);
                Scanner inputPurchaseFile = new Scanner(purchaseFile);
                while (inputPurchaseFile.hasNext())
                {
                    Purchase purchase = new Purchase(inputPurchaseFile.nextInt(),inputPurchaseFile.next(),inputPurchaseFile.nextInt(),inputPurchaseFile.nextDouble());
                    if(customers.stream().anyMatch(o -> o.getId() == purchase.getId()))
                        purchases.add(purchase);
                    else
                        JOptionPane.showMessageDialog(null,"Wyjątek. Uwaga! Brak kupujęcego o id = " + purchase.getId() + " pomijam ten wpis. " + purchase);
                }
                inputPurchaseFile.close();
                break;
            }
            catch (NullPointerException nex)
            {
                System.exit(1);
            }
            catch (Exception ex)
            {
                int selection = JOptionPane.showConfirmDialog(null, "Brak podanego pliku" + purchasePath + "\nCzy chcesz podać nazwę jeszcze raz?\nOpcja NO spowoduje wyłączenie programu.", "Błąd otwarcia pliku", JOptionPane.YES_NO_OPTION, JOptionPane.NO_OPTION);
                if (selection == 1) System.exit(1);
            }
        }

        for (Purchase purchase : purchases)
            System.out.println(purchase);

        for (Customer customer : customers)
        {
            if(purchases.stream().anyMatch(p -> p.getId() == customer.getId()))
            {
                Invoice invoice = new Invoice(customer, new ArrayList<>(purchases.stream().filter(p -> p.getId() == customer.getId()).collect(Collectors.toList())));
                invoices.add(invoice);
            }
        }

        for (Invoice invoice : invoices)
            System.out.println(invoice);

        while (true)
        {
            String invoicePath = JOptionPane.showInputDialog("Podaj nazwę pliku do zapisu danych faktur:");
            try
            {
                File invoiceFile = new File(invoicePath);
                PrintWriter outputInvoiceFile = new PrintWriter(invoiceFile);

                for (Invoice invoice : invoices)
                {
                    outputInvoiceFile.println(invoice + "\n----------------------------------");
                }
                outputInvoiceFile.close();
                break;
            }
            catch (NullPointerException nex)
            {
                System.exit(1);
            }
            catch (Exception ex)
            {
                int selection = JOptionPane.showConfirmDialog(null, "Podana ścieżka nie jest prawidłowa: " + invoicePath + "\nCzy chcesz podać nazwę jeszcze raz?\nOpcja NO spowoduje wyłączenie programu.", "Wrong path", JOptionPane.YES_NO_OPTION, JOptionPane.NO_OPTION);
                if (selection == 1) System.exit(1);
            }
        }





    }
}