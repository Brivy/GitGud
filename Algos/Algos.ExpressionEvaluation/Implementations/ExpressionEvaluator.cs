using GitGud.DS.Stack.Implementations;

namespace GitGud.Algos.ExpressionEvaluation.Implementations;

internal static class ExpressionEvaluator
{
    public static double Run(string expression)
    {
        var operations = new LinkedListStack<char>();
        var values = new LinkedListStack<double>();

        foreach (var character in expression)
        {
            switch (character)
            {
                case '+' or '-' or '*' or '/':
                    operations.Push(character);
                    break;
                case ')':
                    var operation = operations.Pop();
                    var value = values.Pop();
                    value = operation switch
                    {
                        '+' => values.Pop() + value,
                        '-' => values.Pop() - value,
                        '*' => values.Pop() * value,
                        '/' => values.Pop() / value,
                        _ => throw new InvalidOperationException("Invalid operation found")
                    };

                    values.Push(value);
                    break;
                default:
                    if (char.IsDigit(character))
                        values.Push(double.Parse(character.ToString()));
                    break;
            }
        }

        return values.Pop();
    }
}
