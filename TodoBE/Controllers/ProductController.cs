using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Models;
using TodoBE.Services.Product;

namespace TodoBE.Controllers
{
    [Route("v1/api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll(string search, int page, int pageSize)
        {
            return Ok(_repository.Get(search, page, pageSize));
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    try
        //    {
        //        var product = ProductList.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
        //        if (product == null)
        //            return NotFound();
        //        return Ok(product);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = _repository.Add(productVM);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(string id, ProductModel product)
        //{
        //    try
        //    {
        //        if (id != product.ProductID.ToString())
        //            return BadRequest();
        //        var searchProduct = ProductList.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
        //        if (searchProduct == null)
        //            return NotFound();

        //        // Update
        //        searchProduct.Name = product.Name;
        //        searchProduct.Price = product.Price;

        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        var searchProduct = ProductList.SingleOrDefault(p => p.ProductID == Guid.Parse(id));
        //        if (searchProduct == null)
        //            return NotFound();

        //        ProductList.Remove(searchProduct);
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
