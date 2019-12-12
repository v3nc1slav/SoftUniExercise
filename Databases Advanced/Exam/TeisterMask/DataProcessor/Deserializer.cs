namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectsDto[]), new XmlRootAttribute("Projections"));
            var projectionsDto = (ImportProjectsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Project>();
            var sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                var projection = new Project
                {

                //Name = projectionDto.Name,

                };

            projections.Add(projection);

            sb.AppendLine(string.Format(SuccessfullyImportedProject, projectionDto.Name, projectionDto.Tasks.Count()));
        }

        context.Projects.AddRange(projections);
            context.SaveChanges();
            return sb.ToString();

        }

    public static string ImportEmployees(TeisterMaskContext context, string jsonString)
    {

        var employeesDtos = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in employeesDtos)
            {

                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                var employeeTasks = new List<EmployeeTask>();

                foreach (var taskId in employeeDto.EmployeesTasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employeeTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        TaskId = task.Id
                    });
                }

                employee.EmployeesTasks = employeeTasks;

                context.Employees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee,
                    employee.Username,
                    employee.EmployeesTasks.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
}