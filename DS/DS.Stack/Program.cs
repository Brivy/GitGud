using GitGud.DS.Stack.Implementations;

namespace GitGud.DS.Stack;

public static class Program
{
    static void Main(string[] args)
    {
        var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var stack = new LinkedListStack<int>();
        foreach (var number in numbers)
            stack.Push(number);

        foreach (var item in stack)
            Console.WriteLine(item);

        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
    }
}
