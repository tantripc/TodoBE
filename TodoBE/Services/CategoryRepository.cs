using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Data;
using TodoBE.Models;

namespace TodoBE.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }
        public CategoryModel Add(CategoryModel category)
        {
            var loai = new Category()
            {
                Name = category.Name
            };
            _context.Add(loai);
            _context.SaveChanges();
            return new CategoryModel
            {
                Id = loai.CategoryID,
                Name = loai.Name
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Categories
                .SingleOrDefault(c => c.CategoryID == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public CategoryModel Get(int id)
        {
            var loai = _context.Categories
                .SingleOrDefault(c => c.CategoryID == id);
            if (loai != null)
                return new CategoryModel()
                {
                    Id = loai.CategoryID,
                    Name = loai.Name
                };
            return null;
        }

        public List<CategoryModel> GetAll()
        {
            var loais = _context.Categories
                .Select(c => new CategoryModel()
                {
                    Id = c.CategoryID,
                    Name = c.Name
                });
            return loais.ToList();
        }

        public void Update(CategoryModel category)
        {
            var loai = _context.Categories
                .SingleOrDefault(c => c.CategoryID == category.Id);
            if (loai != null)
            {
                loai.Name = category.Name;
                _context.SaveChanges();
            }
        }
    }
}
