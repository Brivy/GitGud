using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._15;

public class Runner : IRunner
{
    public string Identifier => "1.3.15";

    public void Run()
    {
        var stack = new StackWithIndexer<string>();
        var input = "This is the default string";

        Console.Write("Give a string as input that will be stored in a stack, or use the default string: ");
        var userInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            input = userInput;
        }

        var inputSegments = input.Split(' ');
        foreach (var inputSegment in inputSegments)
        {
            stack.Push(inputSegment);
        }

        Console.WriteLine("Stack consists out of the following strings:");
        var index = 0;
        foreach (var item in stack)
        {
            Console.WriteLine($"{index++}. {item}");
        }

        Console.Write("Please enter a index number for which string you want to return: ");
        var indexNumberString = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(indexNumberString) && int.TryParse(indexNumberString, out int indexNumber))
        {
            var result = stack[indexNumber];
            Console.WriteLine($"Your string is: {result}");
        }
    }
}
