using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._9;

internal class Runner : IRunner
{
    public string Identifier => "1.3.9";

    public void Run()
    {
        Console.Write("Run default expression? (y)es or (n)o: ");
        var runningDefaultExpression = Console.ReadLine();

        string expression;
        if (runningDefaultExpression == "y")
        {
            expression = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
        }
        else
        {
            Console.Write("Write your own expression here: ");
            expression = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(expression))
            {
                Console.Write("Invalid expression, please type it again: ");
                expression = Console.ReadLine() ?? string.Empty;
            }
        }

        var result = ParenthesesFixer.FixParenthesesExpression(expression);
        Console.WriteLine($"The fixed expression is: {result}");
    }
}
