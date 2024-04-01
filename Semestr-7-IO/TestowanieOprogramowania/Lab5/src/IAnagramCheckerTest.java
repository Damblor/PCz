import org.junit.Test;

import static org.junit.jupiter.api.Assertions.*;

public class IAnagramCheckerTest
{
    public IAnagramChecker anagramChecker = new AnagramChecker();

    @Test
    public void testIsAnagramNormal()
    {
        assertAll(
                () -> assertTrue(anagramChecker.isAnagram("arbuz", "burza")),
                () -> assertTrue(anagramChecker.isAnagram("Evil", "lIve")),
                () -> assertTrue(anagramChecker.isAnagram("Sł0ma", "masŁ0")),
                () -> assertTrue(anagramChecker.isAnagram("kr$a", "rAk"))
        );
    }

    @Test
    public void testIsNotAnagramNormal()
    {
        assertAll(
                () -> assertFalse(anagramChecker.isAnagram("arbuz", "buza")),
                () -> assertFalse(anagramChecker.isAnagram("Evil", "lIfe")),
                () -> assertFalse(anagramChecker.isAnagram("Sł0ma", "masŁo")),
                () -> assertFalse(anagramChecker.isAnagram("kr$a", "rAk%i"))
        );
    }

    @Test
    public void testIsNotAnagramEmpty()
    {
        assertAll(
                () -> assertTrue(anagramChecker.isAnagram("", "")),
                () -> assertTrue(anagramChecker.isAnagram(" ", " "))
        );
    }

    @Test
    public void testIsNotAnagramNull()
    {
        assertAll(
                () -> assertFalse(anagramChecker.isAnagram(null, "null")),
                () -> assertFalse(anagramChecker.isAnagram("null", null)),
                () -> assertFalse(anagramChecker.isAnagram(null, null))
        );
    }
}