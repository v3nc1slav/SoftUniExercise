using SoftUni.Data;
using SoftUni.Models;
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
                // var result = GetEmployeesFullInformation(context);//3 Employees Full Information
                // var result = GetEmployeesWithSalaryOver50000(context);//4 Employees with Salary Over 50 000
                // var result = GetEmployeesFromResearchAndDevelopment(context);//5 Employees from Research and Development
                //var result = AddNewAddressToEmployee(context);//6 Adding a New Address and Updating Employee
                //var result = GetEmployeesInPeriod(context);//7 Employees and Projects
                //var result = GetAddressesByTown(context);//8 Addresses by Town
                //var result = GetEmployee147(context);//9 Employee 147
                //var result = GetDepartmentsWithMoreThan5Employees(context);//10 Departments with More Than 5 Employees
                //var result = GetLatestProjects(context);//11  Find Latest 10 Projects
                //var result = IncreaseSalaries(context);//12 Increase Salaries
                //var result = GetEmployeesByFirstNameStartingWithSa(context);//13 Find Employees by First Name Starting With "Sa"
                //var result = DeleteProjectById(context);//14 Delete Project by Id
                var result = RemoveTown(context);//15 Remove Town

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

            var emp = context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName);

            foreach (var item in emp)
            {
                sb.AppendLine($"{item.FirstName} - {item.Salary:F2}");
            }
            return sb.ToString().TrimEnd();

        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emp = context.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new { e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary })
                    .ToList();

            foreach (var item in emp)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} from Research and Development - ${item.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Employees
                    .Single(e => e.LastName == "Nakov")
                    .Address = address;

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            var emp = context.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            foreach (var item in emp)
            {
                sb.AppendLine(item);
            }
            return sb.ToString().TrimEnd();

        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var selectedAddresses = context.Addresses
              .OrderByDescending(a => a.Employees.Count)
              .ThenBy(a => a.Town.Name)
              .ThenBy(a => a.AddressText)
              .Take(10)
              .Select(a => new
              {
                  Text = a.AddressText,
                  Town = a.Town.Name,
                  EmployeesCount = a.Employees.Count
              })
              .ToList();

            foreach (var address in selectedAddresses)
            {
                sb.AppendLine($"{address.Text}, {address.Town} - {address.EmployeesCount} employees");
            }

            return sb.ToString().Trim();

        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate,
                        ProjectEndDate = ep.Project.EndDate
                    })
                }).Take(10);

            StringBuilder employeeManagerResult = new StringBuilder();

            foreach (var employee in employees)
            {
                employeeManagerResult.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = project.ProjectEndDate.HasValue ? project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    employeeManagerResult.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return employeeManagerResult.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10).Select(s => new
            {
                ProjectName = s.Name,
                ProjectDescription = s.Description,
                ProjectStartDate = s.StartDate
            }).OrderBy(n => n.ProjectName).ToArray();

            foreach (var p in projects)
            {
                var startDate = p.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                result.AppendLine($"{p.ProjectName}");
                result.AppendLine($"{p.ProjectDescription}");
                result.AppendLine($"{startDate}");
            }
            return result.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                    .Where(e => e.Department.Name == "Engineering" ||
                                 e.Department.Name == "Tool Design" ||
                                  e.Department.Name == "Marketing" ||
                                   e.Department.Name == "Information Services")
                    .OrderBy(e => e.FirstName).ThenBy(e => e.LastName)
                    .ToList();
            foreach (var e in employees)
            {
                e.Salary *= 1.12M;
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {

            StringBuilder result = new StringBuilder();

            var employee147 = context.Employees
                    .Where(n => n.EmployeeId == 147)
                    .Select(x => new
                    {
                        Name = $"{x.FirstName} {x.LastName}",
                        JobTitle = x.JobTitle,
                        Projects = x.EmployeesProjects.Select(p => p.Project.Name)
                    })
                    .FirstOrDefault();

            result.AppendLine($"{employee147.Name} - {employee147.JobTitle}");

            foreach (var proj in employee147.Projects.OrderBy(x => x))
            {
                result.AppendLine(proj);
            }
            return result.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var departTest = context.Departments
        .Where(d => d.Employees.Count > 5)
        .OrderBy(d => d.Employees.Count);

            foreach (var depart in departTest)
            {
                result.AppendLine($"{depart.Name} {depart.Manager.FirstName}");
                foreach (var emp in depart.Employees)
                {
                    result.AppendLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return result.ToString().TrimEnd(); 

        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var project = context.Projects
                .Where(p => p.ProjectId == 2)
                .FirstOrDefault();

            var employees = context.EmployeesProjects
                .Where(p => p.ProjectId == 2);

            foreach (var empl in employees)
            {
                context.EmployeesProjects
                    .Remove(empl);
            }
            context.Projects
                .Remove(project);

            context.SaveChanges();

            context.Projects
                .Take(10)
                .Select(n => n.Name)
                .ToList()
                .ForEach(x => result.AppendLine(x));

            return result.ToString().TrimEnd();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

             string townName = "Seattle";

            context.Employees
                .Where(e => e.Address.Town.Name == townName)
                .ToList()
                .ForEach(e => e.AddressId = null);

            int addressesCount = context.Addresses
                .Where(a => a.Town.Name == townName)
                .Count();

            context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList()
                .ForEach(a => context.Addresses.Remove(a));

            context.Towns
                .Remove(context.Towns
                    .SingleOrDefault(t => t.Name == townName));

            context.SaveChanges();

            result.AppendLine($"{addressesCount} {(addressesCount == 1 ? "address" : "addresses")} in {townName} {(addressesCount == 1 ? "was" : "were")} deleted");

            return result.ToString().TrimEnd();
        }
    }
}

