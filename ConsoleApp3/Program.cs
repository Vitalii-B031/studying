namespace ConsoleApp3;

class Program
{
    static void Main(string[] args)
    {
        int num1; 
        Console.WriteLine("Введите размер масива:"); 
        num1 = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[num1];
        Random rnd = new Random();
        for (int i = 0; i < num1; i++)
        {
            array[i] = rnd.Next(1, 101);
            
        }
        PrintArray(array); 
        for (int i = 0; i < num1-1; i++)
        {
            for (int j = 0; j < num1 - i-1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
               
        }
       PrintArray(array);
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}