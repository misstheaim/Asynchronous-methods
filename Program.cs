using System.Diagnostics;

namespace Asynchronous_methods;

internal class Program
{
    static async Task Main(string[] args)
    {
        (int num1, int num2, int num3) = (75, 100, 130);

        Stopwatch sw = Stopwatch.StartNew();

        Console.WriteLine(new Fib(num1).Result);
        Console.WriteLine(new Fib(num2).Result);
        Console.WriteLine(new Fib(num3).Result);

        sw.Stop();
        Console.WriteLine($"Elapsed time: {sw.Elapsed}\n");

        sw.Restart();

        var task1 = FibAsync(num1);
        var task2 = FibAsync(num2);
        var task3 = FibAsync(num3);

        var results = await Task.WhenAll(task1, task2, task3);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }

        sw.Stop();
        Console.WriteLine($"Elapsed time: {sw.Elapsed}\n");

        sw.Restart();

        await Parallel.ForEachAsync<int>(new int[] { num1, num2, num3 }, async (int num, CancellationToken cancellation = default) => Console.WriteLine(await FibAsync(num)));

        sw.Stop();
        Console.WriteLine($"Elapsed time: {sw.Elapsed}\n");

        Console.ReadLine();
    }

    static Task<decimal> FibAsync(int number)
    {
        return Task.Run(() => new Fib(number).Result);
    }
}
