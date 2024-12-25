using System;

class MyString : IMyNumber<MyString>
{
    private string value;

    public MyString(string value)
    {
        this.value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public MyString Add(MyString b)
    {
        return new MyString(value + b.value);
    }

  public MyString Subtract(MyString b)
    {
        if (string.IsNullOrEmpty(b.value))
            return new MyString(value); 

        int index = value.IndexOf(b.value, StringComparison.Ordinal);
        if (index >= 0)
        {
            string result = value.Remove(index, b.value.Length);
            return new MyString(result);
        }
        return new MyString(value);
    }
   public MyString Multiply(MyString b)
    {
        if (int.TryParse(b.value, out int repeat) && repeat >= 0)
        {
            return new MyString(string.Concat(Enumerable.Repeat(value, repeat)));
        }
        else
        {
            return new MyString(value + b.value);
        }
    }


    public MyString Divide(MyString b)
    {
        if (string.IsNullOrEmpty(b.value))
            return new MyString(value);

        var parts = value.Split(new[] { b.value }, StringSplitOptions.None);
        return new MyString(string.Join(",", parts));
    }

    public override string ToString()
    {
        return value;
    }
}
