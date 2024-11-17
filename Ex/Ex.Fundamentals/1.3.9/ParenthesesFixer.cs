using GitGud.DS.Stack.Implementations;
using System.Text;

namespace GitGud.Ex.Fundamentals._1._3._9;

internal static class ParenthesesFixer
{
    public static string FixParenthesesExpression(string expression)
    {
        var characterStack = new LinkedListStack<char>();
        foreach (var character in expression)
        {
            if (!char.IsWhiteSpace(character)) characterStack.Push(character);
        }

        var fixedStack = new LinkedListStack<char>();
        var expressionStarted = false;
        var expressionWithParentheses = false;
        var expressionWithExcessParentheses = false;
        var excessParentheses = 0;

        while (characterStack.Size() > 0)
        {
            var currentCharacter = characterStack.Pop();
            if (char.IsNumber(currentCharacter) && !expressionStarted)
            {
                expressionStarted = true;
                fixedStack.Push(currentCharacter);
            }
            else if (char.IsNumber(currentCharacter) && expressionStarted)
            {
                expressionStarted = false;
                fixedStack.Push(currentCharacter);

                if (expressionWithParentheses)
                {
                    fixedStack.Push('(');
                    expressionWithParentheses = false;
                }

                if (!expressionWithExcessParentheses && excessParentheses > 0)
                {
                    fixedStack.Push('(');
                    excessParentheses--;
                }

                expressionWithExcessParentheses = false;
            }
            else if (currentCharacter == ')')
            {
                if (!expressionWithParentheses) expressionWithParentheses = true;
                else
                {
                    expressionWithExcessParentheses = true;
                    excessParentheses++;
                }

                fixedStack.Push(currentCharacter);
            }
            else
            {
                fixedStack.Push(currentCharacter);
            }
        }

        var result = new StringBuilder();
        foreach (var fixedCharacter in fixedStack)
        {
            result.Append(fixedCharacter);

            result.Append(' ');
        }
        result.Length--;

        return result.ToString();
    }
}
