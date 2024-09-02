using System;
using System.Globalization;
public class CustomConverter
{
    public void _Convert(string input, out int result)
    {
        result = Convert.ToInt32(input);
    }

    public void _Convert(string input, out float result)
    {
        result = float.Parse(input, CultureInfo.InvariantCulture);
    }

    public void _Convert(string input, out double result)
    {
        result = double.Parse(input, CultureInfo.InvariantCulture);
    }

    public void _Convert(string input, out bool result)
    {
        result = Convert.ToBoolean(input);
    }
}

class Program
{
    static void Main()
    {
        CustomConverter converter = new CustomConverter();

        converter._Convert("123", out int intValue);
        Console.WriteLine($"Converted to int: {intValue}");

        converter._Convert("123.45", out float floatValue);
        Console.WriteLine($"Converted to float: {floatValue}");

        converter._Convert("123.456", out double doubleValue);
        Console.WriteLine($"Converted to double: {doubleValue}");

        converter._Convert("true", out bool boolValue);
        Console.WriteLine($"Converted to bool: {boolValue}");
    }
}
