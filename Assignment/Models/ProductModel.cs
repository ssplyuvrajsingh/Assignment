using System;

namespace Assignment.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public Guid? product_id { get; set; }
        public string product_name { get; set; }
    }
}