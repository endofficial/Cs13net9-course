using System.Diagnostics;

WriteLine("Press ENTER to start. ");
ReadLine();
Stopwatch watch = Stopwatch.StartNew();

watch.Start();
int max = 45;
IEnumerable<int> numbers = Enumerable.Range(start: 1, count: max); // 1, 2, 3, ..., 45

WriteLine($"Calculating Fibonacci sequence up to term {max}. Please wait...");

int[] fibonacciNumbers = numbers.AsParallel()
    .Select(number => Fibonacci(number))
    .OrderBy(number => number)
    .ToArray();

watch.Stop();
WriteLine("{0:#,##0} elapsed milliseconds.",
    watch.ElapsedMilliseconds);

static int Fibonacci(int term) =>
    term switch
    {
        1 => 0,
        2 => 1,
        _ => Fibonacci(term - 1) + Fibonacci(term - 2)
    };