using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class CategoryProductsDto
    {
        //     <CategoryProduct>
        // <CategoryId>6</CategoryId>
        // <ProductId>3</ProductId>
        //     </CategoryProduct>

        [XmlElement("CategoryId")]
        public int categoryId { get; set; }

        [XmlElement("ProductId")]
        public int productId { get; set; }

    }
}
