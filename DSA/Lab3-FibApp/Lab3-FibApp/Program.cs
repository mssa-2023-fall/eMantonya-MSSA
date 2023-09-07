
Console.WriteLine("Begin fib");
Console.WriteLine(Fibonacci(5));

Console.WriteLine("Begin Fact");
Console.WriteLine(Factorial(6));



static int Fibonacci(int num)
{
    Console.WriteLine(num);
    if (num == 0) return 0;
    if (num == 1) return 1;
    return Fibonacci(num - 1) + Fibonacci(num - 2);
}

static int Factorial(int num)
{
    Console.WriteLine(num);
    if (num == 0) return 1;
    return num * Factorial(num - 1);
}


