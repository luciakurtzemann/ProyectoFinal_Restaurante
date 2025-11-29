using ProyectoFinal_Restaurante.Data;
using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Repositories.Interfaces;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProyectoFinal_RestauranteContext _context;

        public CategoryRepository (ProyectoFinal_RestauranteContext context)
        {
            _context = context;
        }
        public Category CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category DeleteCategory(int id)
        {
            var categoryToDelete = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                _context.SaveChanges();
                return categoryToDelete;
            }
            return null;    
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.CategoryId == id);
            return category;
        }

        public List<Category> GetCategoriesByRestaurant(int restaurantId)
        {
            List<Category> listadoCategoryByRestaurant = _context.Categories.Where(x => x.RestaurantId ==  restaurantId).ToList();
            return listadoCategoryByRestaurant;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryToUpdate = _context.Categories.FirstOrDefault(x => x.CategoryId ==  category.CategoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = category.CategoryName;
                _context.SaveChanges();
                return categoryToUpdate;
            }
            return null;
        }

        public int GetRestaurantId(int idCategoria)
        {
            var categoria = _context.Categories.FirstOrDefault(x => x.CategoryId == idCategoria);
            if (categoria != null)
            {
                return categoria.RestaurantId;
            }
            return 0;
        }
    }
}
