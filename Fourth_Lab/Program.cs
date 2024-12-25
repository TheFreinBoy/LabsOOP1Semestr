using System;
using System.Numerics;
using System.Text;

class Program
{
    static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b); // ab
        curr = curr.Add(curr); // ab + ab = 2ab

        // I'm not sure how to create constant factor "2" in more elegant way,
        // without knowing how IMyNumber is implemented
        Console.WriteLine("2*a*b = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }

    static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a-b)=(a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");
        T aSubtractB = a.Subtract(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a - b) = " + aSubtractB);
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholePart = curr;
        curr = b.Multiply(b); 
        Console.WriteLine("b^2 = " + curr);
        wholePart = wholePart.Subtract(curr);
        Console.WriteLine("(a^2-b^2) = " + wholePart); 

        curr = a.Add(b); 
        Console.WriteLine("(a+b) = " + curr);
        curr = wholePart.Divide(curr);
        Console.WriteLine("(a^2-b^2)/(a+b) = " + curr);
        T difference = aSubtractB.Subtract(curr);
        Console.WriteLine("(a-b) - (a^2-b^2)/(a+b) = " + difference);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }
    static void Main(string[] args)
    {
    TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
    TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
    TestAPlusBSquare(new MyString("Привіт"), new MyString("Пока"));
    TestSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
    TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));
    TestSquaresDifference(new MyString("Мама"), new MyString("ма"));
    var str1 = new MyString("ДваСлова");
    var str2 = new MyString("Слова");
    var result = str1.Subtract(str2);
    Console.WriteLine($"Result: '{result}'"); // "Два"

    str1 = new MyString("Два");
    str2 = new MyString("Два");
    result = str1.Subtract(str2);
    Console.WriteLine($"Результат: '{result}'"); //  ""

    Console.WriteLine("Відсортовані ф-ї:");
    List<MyFrac> fractions = new List<MyFrac> { new MyFrac(1, 2), new MyFrac(1, 3), new MyFrac(3, 4) };
    fractions.Sort();
    foreach (var frac in fractions)
        Console.WriteLine(frac);

    Console.ReadKey();
    }
}
