namespace PostfixCallculatorPrj;

internal class Program
{
    static void Main()
    {
        try
        {
            double result = PostfixCalculator.Evaluate("5 3 + 2 *");
            Console.WriteLine($"Result: {result}");

            result = PostfixCalculator.Evaluate("10 5 / 2 +");
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
