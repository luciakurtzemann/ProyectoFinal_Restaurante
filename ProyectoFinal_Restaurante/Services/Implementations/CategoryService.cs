using ProyectoFinal_Restaurante.Entities;
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
        public CategoryDto CreateCategory(CreateCategoryDto category, int loggedRestaurantId)
        {
            Category categoryToCreate = new Category()
            {
                CategoryName = category.CategoryName,
                RestaurantId = loggedRestaurantId
            };
            Category createdCategory = _categoryRepository.CreateCategory(categoryToCreate);

            CategoryDto categoryResponse = new CategoryDto()
            {
                CategoryName = createdCategory.CategoryName,
                RestaurantId = createdCategory.RestaurantId
            };
            return categoryResponse;
        }

        public bool DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }

        public List<CategoryDto> GetCategoriesByRestaurant(int restaurantId)
        {
            List<CategoryDto> listadoCategoryPorRestaurantDto = _categoryRepository.GetCategoriesByRestaurant(restaurantId)
                .Select(category => new CategoryDto()
                {
                    CategoryName = category.CategoryName,
                    RestaurantId = category.RestaurantId
                }).ToList();
            return listadoCategoryPorRestaurantDto;
        }

        public CategoryDto GetCategory(int id)
        {
            Category categoria = _categoryRepository.GetCategory(id);
            CategoryDto categoriaResponse = new CategoryDto()
            {
                CategoryName = categoria.CategoryName,
                RestaurantId = categoria.RestaurantId
            };
            return categoriaResponse;
        }

        public CategoryDto UpdateCategory(UpdateCategoryDto category)       //CHEQUEAR
        {
            Category categoryToUpdate = new Category()
            {
                CategoryName= category.CategoryName,
            };
            Category categoryUpdated = _categoryRepository.UpdateCategory(categoryToUpdate);

            CategoryDto categoryResponse = new CategoryDto()
            {
                CategoryName=categoryUpdated.CategoryName,
                RestaurantId=categoryUpdated.RestaurantId,
            };
            return categoryResponse;
        }
    }
}
