using GitGud.Algos.ExpressionEvaluation.Implementations;

namespace GitGud.Algos.ExpressionEvaluation;

internal static class Program
{
    static void Main(string[] args)
    {
        var expression = "(1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )";
        var result = ExpressionEvaluator.Run(expression);
        Console.WriteLine(result);
    }
}
