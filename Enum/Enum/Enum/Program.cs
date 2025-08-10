namespace Enum;

class Program
{
    static void Main()
    {
        DayTime dayTime = DayTime.Morning;
        
        PrintDayTime(dayTime);
        PrintDayTime(DayTime.Afternum);
        PrintDayTime(DayTime.Evening);
        
        void PrintDayTime(DayTime dayTime)
        {
            switch(dayTime)
            {
                case DayTime.Morning:
                    Console.WriteLine("Morning");
                    break;
                case DayTime.Afternum:
                    Console.WriteLine("Afternum");
                    break;
                case DayTime.Night:
                    Console.WriteLine("Night");
                    break;
                case DayTime.Evening:
                    Console.WriteLine("Evening");
                    break;
                    
            }
        }
        
        

    }
    enum DayTime
    {
        Morning,
        Afternum,
        Evening,
        Night
    }
}