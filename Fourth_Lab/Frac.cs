using System.Numerics;

class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
{
    private BigInteger numerator;
    private BigInteger denominator;

    public MyFrac(BigInteger nom, BigInteger denom)
    {
        if (denom == 0)
            throw new DivideByZeroException("Знаменник не може бути нуликом!");
        numerator = nom;
        denominator = denom;
        Normalize();
    }

    public MyFrac(int nom, int denom) : this(new BigInteger(nom), new BigInteger(denom)) { }

    private void Normalize()
    {
        BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

    public MyFrac Add(MyFrac b)
    {
        return new MyFrac(numerator * b.denominator + b.numerator * denominator, denominator * b.denominator);
    }

    public MyFrac Subtract(MyFrac b)
    {
        return new MyFrac(numerator * b.denominator - b.numerator * denominator, denominator * b.denominator);
    }

    public MyFrac Multiply(MyFrac b)
    {
        return new MyFrac(numerator * b.numerator, denominator * b.denominator);
    }

    public MyFrac Divide(MyFrac b)
    {
        if (b.numerator == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return new MyFrac(numerator * b.denominator, denominator * b.numerator);
    }

    public int CompareTo(MyFrac other)
    {
        return (numerator * other.denominator).CompareTo(denominator * other.numerator);
    }

    public override string ToString()
    {
        if (numerator == 0)
        {
            return "0";
        }
        else
        {
            return $"{numerator}/{denominator}";
        }
        
    }
}
