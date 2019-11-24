using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Category")]
    public class CategoryDto
    {
       //    <Category>
       // <name>Adult</name>
       //    </Category>
      
        [XmlElement("name")]
        public string name { get; set; }
    }   
}
