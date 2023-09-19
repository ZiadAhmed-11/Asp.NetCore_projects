/*//Old school
using OOP_1;

Console.Write("First Name: ");
var Fname=Console.ReadLine();
Console.Write("Last Name: ");
var Lname = Console.ReadLine();

Console.Write("Wage: ");
var wage=Convert.ToDouble(Console.ReadLine()); 

// OOP
Employee e1 = new Employee();
e1.fname = "Ziad";
e1.lname = "Ziad";
e1.wage = 21;

Console.Write("Tax: ");
Employee.Tax = Convert.ToDouble(Console.ReadLine());
*/
Demo d1 = new Demo();
d1.DoSomething();
Console.WriteLine(d1.DoSomething());

public class Demo
{
    //Method syntax
    public int DoSomething()
    {
        return 10;
    }


 
}