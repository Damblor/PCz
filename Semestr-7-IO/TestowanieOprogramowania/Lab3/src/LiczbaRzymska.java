public class LiczbaRzymska
{
    private final int[] arabicTable = {1000, 500, 100, 50, 10, 5, 1};
    private final String[] romanianTable = {"M", "D", "C", "L", "X", "V", "I"};
    private int value;
    private String roman;

    public void initialize(int value)
    {
        if (value < 1 || value > 3999)
            throw new IllegalArgumentException("Liczba rzymska musi być z zakresu 1-3999");
        this.value = value;
        this.roman = ToRoman(value);
    }

    public void initialize(String roman)
    {
        if (!roman.matches("[MDCLXVI]+"))
            throw new IllegalArgumentException("Liczba rzymska musi składać się z liter M, D, C, L, X, V, I");
        int temp = ToArabic(roman);
        if (temp < 1 || temp > 3999)
            throw new IllegalArgumentException("Liczba rzymska musi być z zakresu 1-3999 tz. I-MMMCMXCIX");
        this.value = temp;
        this.roman = roman;
    }

    public LiczbaRzymska Add(LiczbaRzymska other)
    {
        LiczbaRzymska result = new LiczbaRzymska();
        result.initialize(this.value + other.value);
        return result;
    }

    public LiczbaRzymska Subtract(LiczbaRzymska other)
    {
        LiczbaRzymska result = new LiczbaRzymska();
        result.initialize(this.value - other.value);
        return result;
    }

    private String ToRoman(int value) {
        StringBuilder roman = new StringBuilder();
        int i = 0;
        while (value > 0) {
            if (value >= arabicTable[i]) {
                roman.append(romanianTable[i]);
                value -= arabicTable[i];
            } else if (i % 2 == 0 && i < 6 && value >= arabicTable[i] - arabicTable[i + 2]) {
                roman.append(romanianTable[i + 2]).append(romanianTable[i]);
                value -= arabicTable[i] - arabicTable[i + 2];
            } else if (i % 2 == 1 && value >= arabicTable[i] - arabicTable[i + 1]) {
                roman.append(romanianTable[i + 1]).append(romanianTable[i]);
                value -= arabicTable[i] - arabicTable[i + 1];
            } else {
                i++;
            }
        }
        return roman.toString();
    }

    private int ToArabic(String value) {
        int arabic = 0;
        int i = 0;
        while (i < value.length()) {
            int j = 0;
            while (j < romanianTable.length) {
                if (value.substring(i).startsWith(romanianTable[j])) {
                    arabic += arabicTable[j];
                    i += romanianTable[j].length();
                    break;
                } else if (j % 2 == 0 && j < 6 && value.substring(i).startsWith(romanianTable[j + 2] + romanianTable[j])) {
                    arabic += arabicTable[j] - arabicTable[j + 2];
                    i += romanianTable[j + 2].length() + romanianTable[j].length();
                    break;
                } else if (j % 2 == 1 && value.substring(i).startsWith(romanianTable[j + 1] + romanianTable[j])) {
                    arabic += arabicTable[j] - arabicTable[j + 1];
                    i += romanianTable[j + 1].length() + romanianTable[j].length();
                    break;
                } else {
                    j++;
                }
            }
        }
        return arabic;
    }

    public String ToFullValue()
    {
        return value + " = " + roman;
    }

    @Override
    public String toString()
    {
        return roman;
    }
}
