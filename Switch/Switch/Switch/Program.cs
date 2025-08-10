namespace Switch;

class Program
{
    static void Main(string[] args)
    {
        
       var result = Dooperation(1, 2, 3);
       Console.WriteLine(result);
       result = Dooperation(3, 2, 3);
       Console.WriteLine(result);
       
       int numb = 1;
        switch (numb)
        {
            case 1:
                Console.WriteLine("1");
                goto case 2;
                break;
            case 2:
                Console.WriteLine("2");
                break;
            default:
                Console.WriteLine("default");
                break;
        }
        
        int Dooperation(int op, int a, int b)
        {
            int result = op switch
            {
                1 => a + b,
                2 => a - b,
                3 => a + b,
                _ => 0
            };
            return result;
        }
        
    }
}