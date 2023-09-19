Date d1= new Date(01,01,0001);


d1.day = 1;
d1.month = 1;
d1.year = 0001;
Console.WriteLine(d1.getDate());

public class Date
{
    private static readonly int[] daysToMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public int day;
    public int month;
    public int year;


    public Date(int Day,int Month,int Year)
    {
        day = Day;
        month = Month;
        year = Year;
    }


    public string getDate()
    {
       return($"{this.day.ToString().PadLeft(2, '0')}/{this.month.ToString().PadLeft(2, '0')}/{this.year.ToString().PadLeft(4, '0')}");

    }
}