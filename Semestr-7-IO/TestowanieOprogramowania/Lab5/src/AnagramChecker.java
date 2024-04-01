import java.util.Arrays;

public class AnagramChecker implements IAnagramChecker
{
    @Override
    public boolean isAnagram(String word1, String word2)
    {
        if (word1 == null || word2 == null)
        {
            return false;
        }

        String normalizedWord1 = normalize(word1);
        String normalizedWord2 = normalize(word2);

        if (normalizedWord1.length() != normalizedWord2.length())
        {
            return false;
        }

        char[] word1Chars = normalizedWord1.toCharArray();
        char[] word2Chars = normalizedWord2.toCharArray();

        Arrays.sort(word1Chars);
        Arrays.sort(word2Chars);

        return Arrays.equals(word1Chars, word2Chars);
    }

    private String normalize(String word) {
        return word.replaceAll("[^a-zA-Z0-9]", "").toLowerCase();
    }
}
