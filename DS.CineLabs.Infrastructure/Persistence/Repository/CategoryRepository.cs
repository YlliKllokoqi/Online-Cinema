using DS.CineLabs.Domain.Entities;
using DS.CineLabs.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.CineLabs.Infrastructure.Persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CinelabsDbContext _db;
        public CategoryRepository(CinelabsDbContext db)
        {
            _db = db;
        }
        public void CreateCategory(Category category)
        {
            category.CreatedAt = DateTime.Now;
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public void UpdateCategory(Category category)
        {
            category.UpdatetAt = DateTime.Now;
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
    }
}
