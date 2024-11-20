using System.Text;

namespace GitGud.Ex.Fundamentals._1._3._10;

internal static class InfixToPostfix
{
    public static string Parse(string expression)
    {
        var operators = new Stack<char>();
        var output = new StringBuilder();

        foreach (var character in expression)
        {
            if (char.IsDigit(character))
            {
                output.Append(character).Append(' ');
            }
            else if (character is '+' or '-' or '*' or '/')
            {
                while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(character))
                {
                    output.Append(operators.Pop()).Append(' ');
                }
                operators.Push(character);
            }
        }

        while (operators.Count > 0)
        {
            output.Append(operators.Pop()).Append(' ');
        }

        return output.ToString().TrimEnd();
    }

    private static int Precedence(char op)
    {
        return op switch
        {
            '+' or '-' => 1,
            '*' or '/' => 2,
            _ => 0
        };
    }


    //public static string Parse(string expression)
    //{
    //    var operators = new LinkedListStack<char>();
    //    var digits = new LinkedListStack<char>();
    //    foreach (var character in expression)
    //    {
    //        if (character is '+' or '-' or '*' or '/') operators.Push(character);
    //        else if (char.IsDigit(character)) digits.Push(character);
    //    }

    //    var postfixStack = new LinkedListStack<string>();
    //    while (!operators.IsEmpty())
    //    {
    //        var primaryOperator = operators.Pop();
    //        if (primaryOperator is '*' or '/' && operators.Size() >= 1)
    //        {
    //            var secondaryOperator = operators.Pop();
    //            if (secondaryOperator is '*' or '/')
    //            {
    //                var digit = digits.Pop();
    //                postfixStack.Push($"{digit} {primaryOperator}");
    //                while (secondaryOperator is '*' or '/')
    //                {
    //                    digit = digits.Pop();
    //                    postfixStack.Push($"{digit} {secondaryOperator}");
    //                    secondaryOperator = operators.Pop();
    //                }
    //                var leftDigit = digits.Pop();
    //                var finalPostfix = postfixStack.Pop();
    //                postfixStack.Push($"{leftDigit} {finalPostfix} {secondaryOperator}");
    //            }
    //            else
    //            {
    //                var rightDigit = digits.Pop();
    //                var leftDigit = digits.Pop();
    //                postfixStack.Push($"{leftDigit} {rightDigit} {primaryOperator} {secondaryOperator}");
    //            }
    //        }
    //        else
    //        {
    //            var digit = digits.Pop();
    //            postfixStack.Push($"{digit} {primaryOperator}");
    //        }
    //    }

    //    var postfix = new StringBuilder($"{digits.Pop()}");
    //    while (!postfixStack.IsEmpty())
    //    {
    //        var postfixPart = postfixStack.Pop();
    //        postfix.Append($" {postfixPart}");
    //    }

    //    return postfix.ToString();
    //}
}
