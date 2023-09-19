using System;
namespace OOP
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine((int)Month.FEB);

            var day = DAY.SATURDAY;
            if(day.HasFlag(DAY.WEEKEND))
            {
                Console.WriteLine("Enjoy your Weekend\n");
            }
        }
    }

    // Simple ENUM
    enum Month
    {
        JAN=1,
        FEB, //2
        MAR, //3
        APR, //4 
        MAY, //..
        JUN,
        JUL,
        AUG,
        SEP,
        OCT,
        NOV,
        DEC
    }

    // Flag ENUMS
    enum DAY
    {
        NONE    =0b_0000_0000, //0
        MONDAY  =0b_0000_0001, //1
        TUSEDAY =0b_0000_0001, //2
        WEDNESDAY,             //4  
        THURSDAY,              //8
        FRIDAY,
        SATURDAY,
        SUNDAY,
        WEEKEND = FRIDAY | SATURDAY

    }
}

