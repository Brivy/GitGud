using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._1;

internal class Runner : IRunner
{
    public string Identifier => "1.3.1";

    public void Run()
    {
        var stack = new ArrayStackWithIsFull<int>(3);
        stack.Push(1);
        stack.Push(2);

        Console.WriteLine($"Is stack full: {stack.IsFull()}");
        stack.Push(3);
        Console.WriteLine($"Is stack now full: {stack.IsFull()}");
    }
}
