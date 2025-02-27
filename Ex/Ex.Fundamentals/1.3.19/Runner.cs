using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._19;

public class Runner : IRunner
{
    public string Identifier => "1.3.19";

    public void Run()
    {
        var firstLinkedList = new LinkedListLastDeleter<int> { 1 };
        firstLinkedList.RemoveLastNode();
        Print(nameof(firstLinkedList), firstLinkedList);

        var secondLinkedList = new LinkedListLastDeleter<int> { 1, 2 };
        secondLinkedList.RemoveLastNode();
        Print(nameof(secondLinkedList), secondLinkedList);

        var thirdLinkedList = new LinkedListLastDeleter<int> { 1, 2, 3 };
        thirdLinkedList.RemoveLastNode();
        Print(nameof(thirdLinkedList), thirdLinkedList);

        var fourthLinkedList = new LinkedListLastDeleter<int> { 1, 2, 3, 4 };
        fourthLinkedList.RemoveLastNode();
        Print(nameof(fourthLinkedList), fourthLinkedList);
    }

    private static void Print(string name, LinkedListLastDeleter<int> linkedList)
    {
        Console.WriteLine($"Printing contents of {name}");

        var index = 0;
        foreach (var item in linkedList)
        {
            Console.WriteLine($"{index++}. {item}");
        }
    }
}
