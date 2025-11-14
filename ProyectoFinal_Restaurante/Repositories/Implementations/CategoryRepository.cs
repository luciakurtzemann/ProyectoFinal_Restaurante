using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Repositories.Interfaces;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category CreateCategory(Category category)
        {
            _categories.Add(category);
            return category;
        }

        public Category DeleteCategory(int id)
        {
            var categoryToDelete = _categories.FirstOrDefault(x => x.CategoryId == id);
            _categories.Remove(categoryToDelete);
            return categoryToDelete;
        }

        public Category GetCategory(int id)
        {
            var category = _categories.FirstOrDefault(x=>x.CategoryId == id);
            return category;
        }

        public List<Category> GetCategoriesByRestaurant(int restaurantId)
        {
            List<Category> listadoCategoryByRestaurant = _categories.Where(x => x.RestaurantId ==  restaurantId).ToList();
            return listadoCategoryByRestaurant;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId ==  category.CategoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = category.CategoryName;
                return categoryToUpdate;
                //save changes
            }
            return null;
        }


        public static List<Category> _categories = new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "Comidas Rápidas",
                RestaurantId = 1,
                Products = new List<Product>() // se puede llenar después si querés
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Pizzas",
                RestaurantId = 1,
                Products = new List<Product>()
            },
            new Category
            {
                CategoryId = 3,
                CategoryName = "Cafetería",
                RestaurantId = 2,
                Products = new List<Product>()
            },
            new Category
            {
                CategoryId = 4,
                CategoryName = "Bebidas Frías",
                RestaurantId = 2,
                Products = new List<Product>()
            },
            new Category
            {
                CategoryId = 5,
                CategoryName = "Mexicana",
                RestaurantId = 3,
                Products = new List<Product>()
            },
            new Category
            {
                CategoryId = 6,
                CategoryName = "Ensaladas",
                RestaurantId = 3,
                Products = new List<Product>()
            }
        };
    }
}
