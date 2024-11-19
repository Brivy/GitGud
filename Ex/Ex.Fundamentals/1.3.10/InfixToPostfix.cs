using GitGud.DS.Stack.Implementations;
using System.Text;

namespace GitGud.Ex.Fundamentals._1._3._10;

internal static class InfixToPostfix
{
    public static string Parse(string expression)
    {
        var operators = new LinkedListStack<char>();
        var digits = new LinkedListStack<char>();
        foreach (var character in expression)
        {
            if (character is '+' or '-' or '*' or '/') operators.Push(character);
            else if (char.IsDigit(character)) digits.Push(character);
        }

        var postfixStack = new LinkedListStack<string>();
        while (!operators.IsEmpty())
        {
            var primaryOperator = operators.Pop();
            if (primaryOperator is '*' or '/' && operators.Size() >= 1)
            {
                var secondaryOperator = operators.Pop();
                var rightDigit = digits.Pop();
                var leftDigit = digits.Pop();
                postfixStack.Push($"{leftDigit} {rightDigit} {primaryOperator} {secondaryOperator}");
            }
            else
            {
                var digit = digits.Pop();
                postfixStack.Push($"{digit} {primaryOperator}");
            }
        }

        var postfix = new StringBuilder($"{digits.Pop()}");
        while (!postfixStack.IsEmpty())
        {
            var postfixPart = postfixStack.Pop();
            postfix.Append($" {postfixPart}");
        }

        return postfix.ToString();
    }
}
