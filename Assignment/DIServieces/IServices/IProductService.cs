using Assignment.Models;
using System;
using System.Collections.Generic;

namespace Assignment.DIServieces.IServices
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
        bool GetProductById(Guid product_id, int quantity);
    }
}
