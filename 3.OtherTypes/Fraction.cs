using System;
struct Fraction
{
    //fields
    private Int64 numerator;
    private Int64 denominator;

    //constructors
    public Fraction(Int64 numerator, Int64 denominator)
        : this()
    {
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    //properties
    public Int64 Numerator 
    {
        get
        {
            return this.numerator;
        }
        set
        {
            this.numerator = value;
        }
    }

    public Int64 Denominator
    {
        get
        {
            return this.denominator;
        }
        set
        {
            this.denominator = value;
            try
            {
                long x = 1 / this.denominator;
            }
            catch (DivideByZeroException dx)
            {
                Console.WriteLine("Denominator {0} cannot be zero. "+dx.Message, value);
            }
        }
    }
    
    //methods
    public override string ToString()
    {
        return ((double)this.Numerator/this.Denominator).ToString();
    }

    //oveload + operator
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        Int64 newNumerator = f1.Numerator*f2.Denominator + f1.Denominator*f2.Numerator;
        Int64 newDenominator = f1.Denominator*f2.Denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        Int64 newNumerator = f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator;
        Int64 newDenominator = f1.Denominator * f2.Denominator;
        return new Fraction(newNumerator, newDenominator);
    }
}