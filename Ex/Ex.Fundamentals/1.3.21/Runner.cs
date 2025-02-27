using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._21;

public class Runner : IRunner
{
    public string Identifier => "1.3.21";

    public void Run()
    {
        var linkedList = new LinkedListFinder() { "a", "b", "ccc", "d", "e" };
        string? input;
        do
        {
            Console.Write("What do you want to search: ");
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));

        var found = linkedList.Find(input);
        Console.WriteLine($"Was '{input}' found: {(found ? "YES" : "NO")}");
    }
}
