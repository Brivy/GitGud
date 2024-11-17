using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._4;

internal class Runner : IRunner
{
    public string Identifier => "1.3.4";

    public void Run()
    {
        Console.Write("Enter parentheses expression: ");
        var expression = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(expression))
        {
            Console.WriteLine("ERROR: Entered no or empty expression");
            return;
        }

        try
        {
            var isValid = ParenthesesStackClient.ValidateParenthesesExpression(expression);
            Console.WriteLine($"The expression is {(isValid ? "VALID" : "NOT VALID")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred while evaluating the expression: {ex.Message}");
        }
    }
}
