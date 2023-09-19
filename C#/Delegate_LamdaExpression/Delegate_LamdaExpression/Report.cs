using System;


namespace Delegate_LamdaExpression
{
    public class Report
    {
        public delegate bool IllegibleSales(Employee e);   // Delegate (No body)
        public void ProccessEmployee(Employee[] employees , string title, IllegibleSales illegibleSales)
        {
            Console.WriteLine(title);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            foreach (var e in employees)
            {
                if (illegibleSales(e))
                {
                    Console.WriteLine($"{e.Id} | {e.Name} | {e.Gender} | {e.TotalSales}");
                }
            }
            Console.WriteLine("\n\n");
        }



/*
        public void proccessEmployeeWith60000PlusSales(Employee[] employees)
        {
            Console.WriteLine("Employee with $60,000 + sales");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            foreach (var e in employees)
            {
                if (e.TotalSales >= 60000)
                {
                    Console.WriteLine($"{e.Id} | {e.Name} | {e.Gender} | {e.TotalSales}");
                }
            }
            Console.WriteLine("\n\n");

        }

        public void proccessEmployeeWithSalesBetween30000And59999(Employee[] employees)
        {
            Console.WriteLine("Employee with sales between 30,000 and 59,999");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            foreach (var e in employees)
            {
                if (e.TotalSales >= 30000 && e.TotalSales < 60000)
                {
                    Console.WriteLine($"{e.Id} | {e.Name} | {e.Gender} | {e.TotalSales}");
                }
            }
            Console.WriteLine("\n\n");

        }

        public void proccessEmployeeWithSalesLessTahne30000(Employee[] employees)
        {
            Console.WriteLine("Employee with sales less than 30000");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            foreach (var e in employees)
            {
                if (e.TotalSales < 30000)
                {
                    Console.WriteLine($"{e.Id} | {e.Name} | {e.Gender} | {e.TotalSales}");
                }
            }
            Console.WriteLine("\n\n");

           }*/
    }
    
}
