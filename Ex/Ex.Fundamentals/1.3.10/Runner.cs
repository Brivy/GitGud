using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._10;

internal class Runner : IRunner
{
    public string Identifier => "1.3.10";

    public void Run()
    {
        Console.Write("Type your expression here: ");
        var expression = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(expression))
        {
            Console.Write("Invalid expression, please type it again: ");
            expression = Console.ReadLine() ?? string.Empty;
        }

        var postfixExpression = InfixToPostfix.Parse(expression);
        Console.WriteLine($"Your new postfix expression: {postfixExpression}");
    }
}
