using System;
namespace Delegate_LamdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            var emps = new Employee[]
            {
                new Employee {Id=1,Name="Ziad",Gender="M",TotalSales=60000 },
                new Employee {Id=2,Name="Mohamed",Gender="M",TotalSales=75000},
                new Employee {Id=3,Name="Osama",Gender="M",TotalSales=25000},
                new Employee {Id=4,Name="Mona",Gender="F",TotalSales=95000},
                new Employee {Id=5,Name="Morwan",Gender="M",TotalSales=35000},
                new Employee {Id=6,Name="Hoda",Gender="F",TotalSales=45000},
                new Employee {Id=7,Name="Mariam",Gender="F",TotalSales=50000}
            };

            var report = new Report();
            /* report.proccessEmployeeWith60000PlusSales(emps);
             report.proccessEmployeeWithSalesBetween30000And59999(emps);
             report.proccessEmployeeWithSalesLessTahne30000(emps);*/


            /* report.ProccessEmployee(emps, "sales >= 60000", IsGreaterThanOrEqual60000);
             report.ProccessEmployee(emps, "30000 > sales < 60000", IsBetween30000And59999);
             report.ProccessEmployee(emps, "sales < 30000", IsLessThan30000);*/


            // ************      Lambda Expression      ******************
                                                            // first shape
            report.ProccessEmployee(emps, "sales >= 60000", delegate (Employee e) { return e.TotalSales > 60000; });
                                                            // Simple shape
            report.ProccessEmployee(emps, "30000 > sales < 60000", (Employee e) => (e.TotalSales >= 30000 && e.TotalSales < 60000) );
                                                            // Simplest shape
            report.ProccessEmployee(emps, "sales < 30000",   e => (e.TotalSales < 30000));

            // Another example
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

        }

       /* static bool IsGreaterThanOrEqual60000(Employee e) => e.TotalSales > 60000;
        static bool IsBetween30000And59999(Employee e) => e.TotalSales >= 30000 && e.TotalSales < 60000;
        static bool IsLessThan30000(Employee e) => e.TotalSales < 30000;*/
    }
}