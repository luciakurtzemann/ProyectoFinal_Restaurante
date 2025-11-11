using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;
using ProyectoFinal_Restaurante.Repositories.Interfaces;
using ProyectoFinal_Restaurante.Services.Interfaces;

namespace ProyectoFinal_Restaurante.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        //INYECCIÓN DE DEPENDENCIAS
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        //MÉTODOS
        public CategoryDto CreateCategory(CreateCategoryDto category)
        {
            throw new NotImplementedException();
        }

        public CategoryDto DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetCategoriesByRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto UpdateCategory(UpdateCategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}
