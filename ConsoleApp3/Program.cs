namespace ConsoleApp3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите штрину матрицы");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите длинну матрицы");
        int b = Convert.ToInt32(Console.ReadLine());
        int[,] matrix = new int[a, b];
        Random rand = new Random();

        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                matrix[i, j] = rand.Next(1, 10);
            }
        }
        PrintMatrix(matrix, a, b);
        PrintMax(matrix, a, b);
        PrintSumDig(matrix, a, b);
        Transpose(matrix, a, b);
    }

    static void PrintMatrix(int[,] matrix, int a, int b)
    {
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void PrintMax(int[,] matrix, int a, int b)
    {
        int max = 0;
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        Console.WriteLine(max);
    }

    static void PrintSumDig(int[,] matrix, int a, int b)
    {
        int sum = 0;
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (i==j)
                {
                    sum += matrix[i, j];
                }
            }
        }
        Console.WriteLine(sum);
    }

    static void Transpose(int[,] matrix, int a, int b)
    {
        int temp = 0;
        for (int i = 0; i < a; i++)
        {
            for (int j = i+1; j < b; j++)
            {
                temp = matrix[i, j];
                matrix[i, j] = matrix[j, i];
                matrix[j, i] = temp;
            }
        }
        PrintMatrix(matrix, a, b);
    }
}