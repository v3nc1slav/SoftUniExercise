using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class CarsDtoExport
    {

        [XmlElement("make")]
        public string make { get; set; }

        [XmlElement("model")]
        public string model { get; set; }

        [XmlElement("travelled-distance")]
        public long travelledDistance { get; set; }

    }
}
