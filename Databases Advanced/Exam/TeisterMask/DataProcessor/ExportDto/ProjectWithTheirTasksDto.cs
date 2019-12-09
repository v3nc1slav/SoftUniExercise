using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{

    [XmlType("Project")]
    public class ProjectWithTheirTasksDto
    {
        //       <Projects>
        // <Project TasksCount = "10" >
        //   < ProjectName > Hyster - Yale </ ProjectName >
        //   < HasEndDate > No </ HasEndDate >
        //   < Tasks >
        //     < Task >
        //       < Name > Broadleaf </ Name >
        //       < Label > JavaAdvanced </ Label >
        //     </ Task >


        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlElement("Tasks")]
        public ICollection<TaskExportDto> Tasks { get; set; }

    }
    public class TaskExportDto
    {
        [MinLength(2), MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("LabelType")]
        public LabelType LabelType { get; set; }
    }
}
