using System;
using P0_Library.Interfaces;

namespace P0_Library;

public class Calculator : Icalculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Divide(int a, int b)
    {
        return a / b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Sub(int a, int b)
    {
        return a - b;
    }
}
