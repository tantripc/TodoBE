using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Models;

namespace TodoBE.Controllers
{
    [Route("v1/api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> ProductList = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ProductList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var product = ProductList.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product()
            {
                ProductID = Guid.NewGuid(),
                Name = productVM.Name,
                Price = productVM.Price
            };
            ProductList.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Product product)
        {
            try
            {
                if (id != product.ProductID.ToString())
                    return BadRequest();
                var searchProduct = ProductList.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
                if (searchProduct == null)
                    return NotFound();

                // Update
                searchProduct.Name = product.Name;
                searchProduct.Price = product.Price;

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var searchProduct = ProductList.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
                if (searchProduct == null)
                    return NotFound();

                ProductList.Remove(searchProduct);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
