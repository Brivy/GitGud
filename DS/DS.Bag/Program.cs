using GitGud.DS.Bag.Implementations;

namespace GitGud.DS.Bag;

internal static class Program
{
    static void Main(string[] args)
    {
        var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var bag = new LinkedListBag<int>();
        foreach (var number in numbers)
            bag.Add(number);

        foreach (var item in bag)
            Console.WriteLine(item);
    }
}
