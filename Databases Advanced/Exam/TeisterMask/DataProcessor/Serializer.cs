namespace TeisterMask.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var output = context
                .Projects
                .Select(p => new ProjectWithTheirTasksDto
                {
                    ProjectName = p.Name,
                    HasEndDate = IsHasEndDate(context),
                    Tasks = p.Tasks
                    .OrderBy(t=>t.Name)
                    .Select(t => new TaskExportDto
                    {
                     Name = t.Name, 

                     })
                    .ToArray()
                })
                .OrderByDescending(p=>p.Tasks.Count())
                .ThenBy(p=>p.ProjectName)
                .Take(10)
                .ToArray();


        StringBuilder sb = new StringBuilder();
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        XmlSerializer serializer = new XmlSerializer(typeof(ProjectWithTheirTasksDto[]), new XmlRootAttribute("Projects"));
        serializer.Serialize(new StringWriter(sb), output, namespaces);

            return sb.ToString().TrimEnd();
    }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var output = context
                .Employees
                .Where(e=>e.EmployeesTasks.Any(t=>t.Task.Name.Count()>0)
                 && e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e=> new 
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(em =>em.Task.OpenDate>=date)
                    .OrderByDescending(em=>em.Task.DueDate)
                    .ThenBy(em=>em.Task.Name)
                    .Select(em=>new 
                    {
                        TaskName = em.Task.Name,
                        OpenDate = em.Task.OpenDate,
                        DueDate = em.Task.DueDate,
                        LabelType = em.Task.LabelType,
                        ExecutionType = em.Task.ExecutionType
                    })
                })
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(output, Formatting.Indented);
            return jsonString;

        }
        private static string IsHasEndDate(TeisterMaskContext context)
        {
            var output = "Yes";

            if (context.Tasks.Where(t=>t.DueDate!=null).Any())
            {
                output = "No";
            }
            return  output;
        }
    }
}