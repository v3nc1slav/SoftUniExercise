using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsDto
    {
        //  <Project>
        // <Name>S</Name>
        // <OpenDate>25/01/2018</OpenDate>
        // <DueDate>16/08/2019</DueDate>
        // <Tasks>
        //   <Task>
        //     <Name>Australian</Name>
        //     <OpenDate>19/08/2018</OpenDate>
        //     <DueDate>13/07/2019</DueDate>
        //     <ExecutionType>2</ExecutionType>
        //     <LabelType>0</LabelType>
        //   </Task>

        [Required]
        [MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaskDto[] Tasks { get; set; }

    }

    [XmlType("Task")]
    public class TaskDto
    {
        [Required]
        [MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        [Required]
        public string ExecutionType { get; set; }

        [Required]
        public string LabelType { get; set; }
    }
}
