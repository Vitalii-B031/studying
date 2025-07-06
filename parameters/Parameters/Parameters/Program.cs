namespace Parameters;

class Program
{
    static void Main(string[] args)
    {
        
        int number = 5;
        int number2 = 9;
        int result=0;
        
        Console.WriteLine($"Число до метода Increment: {number}");
        Increment(number);
        Console.WriteLine($"Число после Increment: {number}");
        
        Console.WriteLine($"Число до метода Increment_ref: {number}");
        Increment_ref(ref number);
        Console.WriteLine($"Число после Increment_ref: {number}");
        
        Console.WriteLine($"До вызова метода Sum: {result}");
        Sum (number,number2,out result);
        Console.WriteLine($"Результат сложения: {result}");
        Sum_mas(number,number2);
        void Increment(int n)
        {
            n++;
            Console.WriteLine(n);

        }
        void Increment_ref(ref int n) //метод ссылается на ячейку памяти и меняет значение переменной вне области метода
        {
            n++;
            Console.WriteLine($"Число в методе Increment_ref: {n}");
        }

        void Sum(int x, int y, out int result)
        {
             result = x + y;
        }

        void Sum_mas(params int[] numbers)
        {
            int result = 0;
            foreach (var number in numbers)
            {
                result += number;
            }
            Console.WriteLine(result);  
        }
    }
}