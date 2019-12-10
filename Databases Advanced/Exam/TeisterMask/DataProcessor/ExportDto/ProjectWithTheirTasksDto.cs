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

        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        public string ProjectName { get; set; }

        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TaskExportDto[] Tasks { get; set; }

    }

    [XmlType("Task")]
    public class TaskExportDto
    {
        public string Name { get; set; }

        public string Label { get; set; }
    }
}
