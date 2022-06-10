using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBE.Models;

namespace TodoBE.Services
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetAll();
        CategoryModel Get(int id);
        CategoryModel Add(CategoryModel category);
        void Update(CategoryModel category);
        void Delete(int id);
    }
}
