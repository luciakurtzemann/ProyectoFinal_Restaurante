using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;

namespace ProyectoFinal_Restaurante.Services.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDto CreateCategory(CreateCategoryDto category, int loggedRestaurantId);
        public CategoryDto UpdateCategory(UpdateCategoryDto category, int restaurantId);
        public CategoryDto GetCategory(int id);
        public bool DeleteCategory(int id, int loggedRestaurantId);
        public List<CategoryDto> GetCategoriesByRestaurant(int restaurantId);
        public int GetRestaurantId(int idProducto);
    }
}
