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
    using static TeisterMask.DataProcessor.ImportDto.ImportProjectsDto;
    using TeisterMask.DataProcessor.ExportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Project>();
            var sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                //var validEnum = Enum.TryParse<LabelType>(projectionDto.Tasks.Select(t => new {  dad = t.LabelType.ToString() }), out LabelType label);

                var projection = new Project
                {

                Name = projectionDto.Name,
                  Tasks = projectionDto.Tasks
                  .Select(t => new TaskDto
                  {
                      Name = t.Name,
                      OpenDate = t.OpenDate,
                      DueDate = t.DueDate,
                      LabelType = t.LabelType.ToString(),
                      ExecutionType = t.ExecutionType.ToString()
                  })
                  .ToArray()
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

        var employees = new List<Employee>();

        var sb = new StringBuilder();

        foreach (var employeeDtos in employeesDtos)
        {
            if (IsValid(employeeDtos))
            {
                var employee = new Employee
                {
                    Username = employeeDtos.Username,
                    Email = employeeDtos.Email,
                    Phone = employeeDtos.Phone,
                    EmployeesTasks = employeeDtos.EmployeesTasks
                };

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employeeDtos.Username, employeeDtos.EmployeesTasks.Count()));
            }
            else
            {
                sb.AppendLine(ErrorMessage);
            }
        }

        context.Employees.AddRange(employees);
        context.SaveChanges();

        var result = sb.ToString();

        return result;
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
}