using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
        //      <Product>
        //  <name>Care One Hemorrhoidal</name>
        //  <price>932.18</price>
        //  <sellerId>25</sellerId>
        //  <buyerId>24</buyerId>
        //      </Product>

        [XmlType("Product")]
        public class ProductsDto
        {
            [XmlElement("name")]
            public string name { get; set; }

            [XmlElement("price")]
            public decimal price { get; set; }

            [XmlElement("sellerId")]
            public int sellerId { get; set; }

            [XmlElement("buyerId")]
            public int? buyerId { get; set; }
        }
}
