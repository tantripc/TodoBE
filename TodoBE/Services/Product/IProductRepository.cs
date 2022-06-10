using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Models;

namespace TodoBE.Services.Product
{
    public interface IProductRepository
    {
        List<ProductModel> Get(string search, int page, int pageSize);
        ProductModel Add(ProductVM model);
    }
}
