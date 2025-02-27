using GitGud.Ex.Fundamentals._1._3._19;
using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._20;

public class Runner : IRunner
{
    public string Identifier => "1.3.20";

    public void Run()
    {
        Console.WriteLine("The following linked list is available: ");
        var linkedList = new LinkedListIndexDeleter<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Print(linkedList);

        Console.Write("Which index do you want to delete: ");
        var indexNumberString = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(indexNumberString) && int.TryParse(indexNumberString, out int indexNumber))
        {
            linkedList.RemoveAtIndex(indexNumber);
        }

        Console.WriteLine("Oh wow, you now have the following linked list: ");
        Print(linkedList);
    }

    private static void Print(LinkedListIndexDeleter<int> linkedList)
    {
        var index = 0;
        foreach (var item in linkedList)
        {
            Console.WriteLine($"{index++}. {item}");
        }
    }
}
