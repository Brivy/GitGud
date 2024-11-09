using GitGud.DS.Queue.Implementations;

namespace GitGud.DS.Queue;

internal static class Program
{
    static void Main(string[] args)
    {
        var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var queue = new LinkedListQueue<int>();
        foreach (var number in numbers)
            queue.Enqueue(number);

        foreach (var item in queue)
            Console.WriteLine(item);

        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
    }
}
