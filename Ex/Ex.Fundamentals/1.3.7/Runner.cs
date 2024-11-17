using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._7;

internal class Runner : IRunner
{
    public string Identifier => "1.3.7";

    public void Run()
    {
        var stack = new StackWithPeek<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        var stackSize = stack.Size();
        Console.WriteLine($"Stack is now size: {stackSize}");

        var peekedValue = stack.Peek();
        Console.WriteLine($"Peeking on the stack: {peekedValue}");

        stackSize = stack.Size();
        Console.WriteLine($"Stack is now size: {stackSize}");
    }
}
