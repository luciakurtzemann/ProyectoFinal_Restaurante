using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;

namespace ProyectoFinal_Restaurante.Services.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDto CreateCategory(CreateCategoryDto category, int loggedRestaurantId);
        public CategoryDto UpdateCategory(UpdateCategoryDto category);
        public CategoryDto GetCategory(int id);
        public bool DeleteCategory(int id);
        public List<CategoryDto> GetCategoriesByRestaurant(int restaurantId);
    }
}
