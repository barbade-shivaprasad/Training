using System;
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public string Add(string a, string b)
    {
        return a + " " + b;
    }
}

public class AdvanceCalculator : Calculator
{
    public new int Add(int a, int b)
    {
        Console.Write("Added:{0}\n", a + b);
        return a + b;
    }
}

