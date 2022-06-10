using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Data;
using TodoBE.Models;

namespace TodoBE.Controllers
{
    [Route("v1/api/categoryOld")]
    [ApiController]
    public class CategoryOldController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryOldController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID == id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            try
            {
                var category = new Category()
                {
                    Name = model.Name
                };
                _context.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryModel model)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(c => c.CategoryID.Equals(id));
                if (category == null)
                    return NotFound();

                category.Name = model.Name;
                _context.SaveChanges();

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID == id);
            if (category == null)
                return NotFound();

            _context.Remove(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}
