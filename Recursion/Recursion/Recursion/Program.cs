namespace Recursion;

class Program
{
    static void Main(string[] args)
    {
        int Factorial(int n)
        {
            if (n==1) return 1;
            return n*Factorial(n-1);
        }

        int Fibonacci(int n)
        {
            if (n==0||n==1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        Console.WriteLine(Factorial(4));
        Console.WriteLine(Fibonacci(10));
    }
} 