/*var x = 2;
var name = "Essam";
*//*Console.WriteLine(name.ToUpper());*//*
var total = 150;*/

/*Console.WriteLine(x++);
Console.WriteLine(x++);
Console.WriteLine(x++);
*/

/*var mark = 90;
if (mark >= 85)
{
    Console.WriteLine("Excellent");
}
else
    Console.WriteLine("Fail");

var counter=0;
while (counter <=5)
{
    Console.WriteLine(counter);
    counter++;
}

foreach(char c in "Full Stack developer")
{
    Console.WriteLine(c +" ");

}

var arr = new int[] { 1, 2, 3, 4 };

foreach (var n in arr)
{
    Console.WriteLine(n);
}
*/
namespace Expressions
{
    class Program
    {
        static void Main(string[] args) 
        {

            int x = 10;//value type
            object obj;//ref type
            obj = x;  //Boxing (value->ref)
            int y = (int)obj;//Unboxing (ref->value)

            string s = "120";
            int n = int.Parse(s);
            //        type.parse()  / int.parse()

        }
    }
}