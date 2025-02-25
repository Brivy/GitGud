using GitGud.Ex.Fundamentals.Interfaces;

namespace GitGud.Ex.Fundamentals._1._3._14;

internal class Runner : IRunner
{
    public string Identifier => "1.3.14";

    public void Run()
    {
        var queue = new ResizingArrayQueueOfStrings<string>(2);
        queue.Enqueue("q");
        queue.Enqueue("u");
        queue.Enqueue("e");
        queue.Enqueue("u");
        queue.Enqueue("e");

        Console.WriteLine("Here is the 'queue' in the queue:");
        foreach (var item in queue)
        {
            if (item == null)
                Console.WriteLine("-");
            else
                Console.WriteLine(item);
        }

        Console.WriteLine($"Starting to dequeue: {queue.Dequeue()}");
        Console.WriteLine($"Starting to dequeue again: {queue.Dequeue()}");
        Console.WriteLine($"Queueing the letter 'T'");
        queue.Enqueue("T");

        Console.WriteLine("Here is the new queue:");
        foreach (var item in queue)
        {
            if (item == null)
                Console.WriteLine("-");
            else
                Console.WriteLine(item);
        }
    }
}
