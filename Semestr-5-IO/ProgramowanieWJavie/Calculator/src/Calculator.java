
 import java.awt.*; import javax.swing.*;
 public class Calculator
 { public static void main(String[] args)
   { EventQueue.invokeLater(new Runnable()
     { public void run()
       { CalculatorFrame frame = new CalculatorFrame();
         frame.setTitle("Calculator");               
         frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
         frame.setVisible(true);
       }
     });
   }
 }
 
 
 
 
 