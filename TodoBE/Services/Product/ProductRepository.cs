using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Data;
using TodoBE.Models;

namespace TodoBE.Services.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        public ProductModel Add(ProductVM model)
        {
            var product = new Data.Product()
            {
                Name = model.Name,
                CategoryID = model.CategoryID,
                Description = model.Description,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice
            };
            _context.Add(product);
            _context.SaveChanges();

            return new ProductModel()
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                CategoryID = product.CategoryID
            };
        }

        public List<ProductModel> Get(string search, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
