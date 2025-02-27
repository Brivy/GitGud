using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._24;

public class Runner : IRunner
{
    public string Identifier => "1.3.24";

    public void Run()
    {
        var linkedList = new LinkedListRemoveAfter { "a", "b", "c", "d", "e", "f", "g" };
        Console.WriteLine("The following linked list exists: ");
        Print(linkedList);

        string? input;
        do
        {
            Console.Write("Which node neighbor do you want to destroy: ");
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));

        linkedList.RemoveAfter(input);

        Console.WriteLine("This list remains: ");
        Print(linkedList);
    }

    private static void Print(LinkedListRemoveAfter linkedList)
    {
        var index = 0;
        foreach (var item in linkedList)
        {
            Console.WriteLine($"{index++}. {item}");
        }
    }
}
