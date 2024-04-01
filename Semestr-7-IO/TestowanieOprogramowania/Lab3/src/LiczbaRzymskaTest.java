import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class LiczbaRzymskaTest
{
    @Test
    public void testInitializeArabic()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        assertAll(
                () -> assertThrows(IllegalArgumentException.class, () -> l1.initialize(0)),
                () -> assertThrows(IllegalArgumentException.class, () -> l1.initialize(4000)),
                () -> assertDoesNotThrow(() -> l1.initialize(1)),
                () -> assertDoesNotThrow(() -> l1.initialize(3999)));
    }

    @Test
    public void testInitializeRoman()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        assertAll(
                () -> assertDoesNotThrow(() -> l1.initialize("I")),
                () -> assertDoesNotThrow(() -> l1.initialize("MMMCMXCIX")),
                () -> assertThrows(IllegalArgumentException.class, () -> l1.initialize("")),
                () -> assertThrows(IllegalArgumentException.class, () -> l1.initialize("MCHXCX")));
    }

    @Test
    public void testAddArabic()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        LiczbaRzymska l2 = new LiczbaRzymska();
        l1.initialize(27);
        l2.initialize(3);
        assertEquals("XXX", l1.Add(l2).toString());
    }

    @Test
    public void testAddRoman()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        LiczbaRzymska l2 = new LiczbaRzymska();
        l1.initialize("MXCIX");
        l2.initialize("XXVII");
        assertEquals("MCXXVI", l1.Add(l2).toString());
    }

    @Test
    public void testAddOverflow()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        LiczbaRzymska l2 = new LiczbaRzymska();
        l1.initialize("MMMCMXCIX");
        l2.initialize(2);
        assertThrows(IllegalArgumentException.class, () -> l1.Add(l2).toString());
    }

    @Test
    public void testSubtractArabic()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        LiczbaRzymska l2 = new LiczbaRzymska();
        l1.initialize(27);
        l2.initialize(3);
        assertEquals("XXIV", l1.Subtract(l2).toString());
    }

    @Test
    public void testSubtractRoman()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        LiczbaRzymska l2 = new LiczbaRzymska();
        l1.initialize("MXCIX");
        l2.initialize("XXVII");
        assertEquals("MLXXII", l1.Subtract(l2).toString());
    }

    @Test
    public void testSubtractUnderflow()
    {
        LiczbaRzymska l1 = new LiczbaRzymska();
        LiczbaRzymska l2 = new LiczbaRzymska();
        l1.initialize(10);
        l2.initialize("XI");
        assertThrows(IllegalArgumentException.class, () -> l1.Subtract(l2).toString());
    }
}