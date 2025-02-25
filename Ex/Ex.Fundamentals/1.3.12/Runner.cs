using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._12;

internal class Runner : IRunner
{
    public string Identifier => "1.3.12";

    public void Run()
    {
        var stack = new StackWithCopy<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Original stack:");
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

        var copiedStack = StackWithCopy<int>.Copy(stack);

        Console.WriteLine("Copied stack:");
        foreach (var item in copiedStack)
        {
            Console.WriteLine(item);
        }
    }
}
