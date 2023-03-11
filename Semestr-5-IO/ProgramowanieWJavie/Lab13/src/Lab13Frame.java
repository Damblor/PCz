import javax.swing.*;
public class Lab13Frame extends JFrame
{
    public Lab13Frame()
    {
        setTitle("Lab13Frame");
        setSize(300, 200);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        MiddlePanel middlePanel = new MiddlePanel();
        add(middlePanel);
        setVisible(true);
    }
}
