using Assignment.DIServieces.IServices;
using Assignment.Migration;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.DIServieces.Services
{
    public class ProductService : IProductService
    {
        AssignmentEntities entities = new AssignmentEntities();
        public List<ProductModel> GetProducts()
        {
            return entities.products.Select(x => new ProductModel
            {
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