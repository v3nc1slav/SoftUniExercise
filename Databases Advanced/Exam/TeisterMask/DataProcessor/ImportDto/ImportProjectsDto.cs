using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
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
        //

        [XmlType("Project")]
        public class ImportProjectionDto
        {
            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("Tasks")]
            public ICollection<TaskDto> Tasks { get; set; }
        }

        public class TaskDto
        {
            [MinLength(2), MaxLength(40)]
            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("OpenDate")]
            public string OpenDate { get; set; }

            [XmlElement("DueDate")]
            public string DueDate { get; set; }

            [XmlElement("ExecutionType")]
            public string ExecutionType { get; set; }

            [XmlElement("LabelType")]
            public string LabelType { get; set; }
        }
    }
}
