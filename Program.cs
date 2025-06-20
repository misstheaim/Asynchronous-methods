using System.Diagnostics;

namespace Asynchronous_methods;

internal class Program
{
    static async Task Main(string[] args)
    {
        (uint num1, uint num2, uint num3) = (75, 100, 130);

        // ----Test synchronous execution-----
        Stopwatch sw = Stopwatch.StartNew();

        Console.WriteLine(new Fib(num1).Calculate());
        Console.WriteLine(new Fib(num2).Calculate());
        Console.WriteLine(new Fib(num3).Calculate());

        sw.Stop();
        Console.WriteLine($"Test synchronous execution;\nElapsed time: {sw.Elapsed}\n");

        // ----Test asynchronous execution in sequential mode-----
        sw.Restart();
        Console.WriteLine(await FibAsync(num1));
        Console.WriteLine(await FibAsync(num2));
        Console.WriteLine(await FibAsync(num3));

        sw.Stop();
        Console.WriteLine($"Test asynchronous execution in sequential mode;\nElapsed time: {sw.Elapsed}\n");

        // ----Test asynchronous execution in parallel mode-----
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
        Console.WriteLine($"Test asynchronous execution in parallel mode;\nElapsed time: {sw.Elapsed}\n");

        // ----Test asynchronous execution in parallel mode (using Parallel class)-----
        sw.Restart();

        await Parallel.ForEachAsync<uint>(new uint[] { num1, num2, num3 }, async (uint num, CancellationToken cancellation = default) => Console.WriteLine(await FibAsync(num)));

        sw.Stop();
        Console.WriteLine($"Test asynchronous execution in parallel mode (using Parallel class);\nElapsed time: {sw.Elapsed}\n");

        Console.ReadLine();
    }

    static Task<ulong> FibAsync(uint number)
    {
        return Task.Run(() => new Fib(number).Calculate());
    }
}
