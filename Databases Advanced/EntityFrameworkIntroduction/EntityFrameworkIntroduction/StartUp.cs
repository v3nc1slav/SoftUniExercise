using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
               // var result = GetEmployeesFullInformation(context);
                var result = GetEmployeesWithSalaryOver50000(context);
                Console.WriteLine(result);
            }

        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emp = context.Employees.OrderBy(x => x.EmployeeId);

            foreach (var item in emp)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.JobTitle} {item.Salary:F2}");
            }
            return sb.ToString().TrimEnd();

        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emp = context.Employees.Where(e=>e.Salary> 50000).OrderBy(e=>e.FirstName);

            foreach (var item in emp)
            {
                sb.AppendLine($"{item.FirstName} - {item.Salary:F2}");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
