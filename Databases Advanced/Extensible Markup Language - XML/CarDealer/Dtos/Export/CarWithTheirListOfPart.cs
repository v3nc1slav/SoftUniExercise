using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    //  <cars>
    //<car make = "Opel" model="Astra" travelled-distance="516628215">
    //  <parts>
    //    <part name = "Master cylinder" price="130.99" />
    //    <part name = "Water tank" price="100.99" />
    //    <part name = "Front Right Side Inner door handle" price="100.99" />
    //  </parts>
    //</car>

    [XmlType("car")]
    public class CarWithTheirListOfPart
    {
        [XmlAttribute("make")]
        public string make { get; set; }

        [XmlAttribute("model")]
        public string model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long travelledDistance { get; set; }

        [XmlArray("parts")]
        public PartDto[] Parts { get; set; }
    }

    [XmlType("part")]
    public class PartDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
