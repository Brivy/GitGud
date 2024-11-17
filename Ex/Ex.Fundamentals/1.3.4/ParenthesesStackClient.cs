using GitGud.DS.Stack.Implementations;

namespace GitGud.Ex.Fundamentals._1._3._4;

internal static class ParenthesesStackClient
{
    public static bool ValidateParenthesesExpression(string expression)
    {
        var openings = new LinkedListStack<char>();
        foreach (var character in expression)
        {
            switch (character)
            {
                case '[' or '(' or '{':
                    openings.Push(character);
                    break;
                case ']' or ')' or '}':
                    var opening = openings.Pop();
                    switch (opening)
                    {
                        case '[':
                            if (character != ']') return false;
                            break;
                        case '(':
                            if (character != ')') return false;
                            break;
                        case '{':
                            if (character != '}') return false;
                            break;
                        default:
                            return false;
                    }
                    break;
                default:
                    return false;
            }
        }

        return true;
    }
}