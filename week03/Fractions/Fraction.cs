using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public string GetString()
    {
        string fractionString = $"{_numerator}/{_denominator}";
        return fractionString;
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / (double)_denominator;
    }
}
