using Assignment.Migration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Models
{
    public class ProductService
    {
        AssignmentEntities entities = new AssignmentEntities();
        public List<product> GetProducts()
        {
            return entities.products.Select(x=> new product { 
            id = x.id,
            product_id = x.product_id,
            product_name = x.product_name
            }).ToList();
        }

        public bool GetProductById(Guid product_id, int quantity)
        {
            return entities.products.Any(x => x.product_id == product_id && x.stock_available == quantity);
        }
    }
}