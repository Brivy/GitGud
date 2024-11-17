using GitGud.Ex.Fundamentals.Interfaces;
using System.Reflection;

namespace GitGud.Ex.Fundamentals;

internal static class Program
{
    static void Main(string[] args)
    {
        var runners = GetRunners();
        if (runners.Count == 0)
            throw new InvalidOperationException("No runners available");

        Console.Write("Select exercise identifier: ");
        var identifier = Console.ReadLine();
        var runner = runners.SingleOrDefault(x => x?.Identifier == identifier);
        if (runner == null)
        {
            Console.WriteLine($"No runner for identifier: {identifier}");
            return;
        }

        while (true)
        {
            runner.Run();

            Console.Write("Finished running runner: (r)edo or (e)xit? ");
            var command = Console.ReadLine();
            if (command != "R" && command != "r")
            {
                break;
            }
        }
    }

    private static List<IRunner?> GetRunners()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        var runners = types.Where(type => typeof(IRunner).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);
        return runners.Select(runner => (IRunner?)Activator.CreateInstance(runner)).ToList();
    }
}
