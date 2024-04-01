public class Calculator
{
    public double Add(double d1, double d2) {
        return d1 + d2;
    }

    public double Subtract(double d1, double d2) {
        return d1 - d2;
    }

    public double Multiply(double d1, double d2) {
        return d1 * d2;
    }

    public double Divide(double d1, double d2) {
        if (d2 != 0) return d1 / d2;
        else throw new ArithmeticException("Dzielenie przez 0!");
    }

    public double Calculate(double d1, double d2, char op) {
        return switch (op)
        {
            case '+' -> Add(d1, d2);
            case '-' -> Subtract(d1, d2);
            case '*' -> Multiply(d1, d2);
            case '/' -> Divide(d1, d2);
            default -> throw new IllegalArgumentException("Nieprawidłowy operator!");
        };
    }
}
