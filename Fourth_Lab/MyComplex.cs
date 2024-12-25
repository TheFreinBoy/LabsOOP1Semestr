
class MyComplex : IMyNumber<MyComplex>
{
    private double re;
    private double im;

    public MyComplex(double re, double im)
    {
        this.re = re;
        this.im = im;
    }

    public MyComplex(int re, int im) : this((double)re, (double)im) { }

    public MyComplex Add(MyComplex b)
    {
        return new MyComplex(re + b.re, im + b.im);
    }

    public MyComplex Subtract(MyComplex b)
    {
        return new MyComplex(re - b.re, im - b.im);
    }

    public MyComplex Multiply(MyComplex b)
    {
        double real = re * b.re - im * b.im;
        double imaginary = re * b.im + im * b.re;
        return new MyComplex(real, imaginary);
    }

    public MyComplex Divide(MyComplex b)
    {
        double denominator = b.re * b.re + b.im * b.im;
        if (denominator == 0)
            throw new DivideByZeroException("Нолік!");
        double real = (re * b.re + im * b.im) / denominator;
        double imaginary = (im * b.re - re * b.im) / denominator;
        return new MyComplex(real, imaginary);
    }

    public override string ToString()
    {
        if (im == 0)
        {
            return $"{re}";
        }
        else if (re == 0)
        {   
            return $"{im}";
        }
        return $"{re}+{im}i";
    }
}