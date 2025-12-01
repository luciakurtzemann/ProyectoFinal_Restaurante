using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Exceptions;
using ProyectoFinal_Restaurante.Models.DTOs.Requests;
using ProyectoFinal_Restaurante.Models.DTOs.Responses;
using ProyectoFinal_Restaurante.Repositories.Implementations;
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
                CategoryId = createdCategory.CategoryId,
                CategoryName = createdCategory.CategoryName,
                RestaurantId = createdCategory.RestaurantId
            };
            return categoryResponse;
        }

        public bool DeleteCategory(int id)
        {
            var categoryToDelete = _categoryRepository.DeleteCategory(id);
            if (categoryToDelete != null)
            {
                return true;
            }
            return false;
        }

        public List<CategoryDto> GetCategoriesByRestaurant(int restaurantId)
        {
            List<CategoryDto> listadoCategoryPorRestaurantDto = _categoryRepository.GetCategoriesByRestaurant(restaurantId).Select(category => new CategoryDto()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    RestaurantId = category.RestaurantId
                }).ToList();
            return listadoCategoryPorRestaurantDto;
        }

        public CategoryDto GetCategory(int id)
        {
            Category categoria = _categoryRepository.GetCategory(id);
            if (categoria != null)
            {
                CategoryDto categoriaResponse = new CategoryDto()
                {
                    CategoryId = categoria.CategoryId,
                    CategoryName = categoria.CategoryName,
                    RestaurantId = categoria.RestaurantId
                };
                return categoriaResponse;
            }
            throw new NotFoundException("La categoría buscada no existe.");
 
        }

        public CategoryDto UpdateCategory(UpdateCategoryDto category, int restaurantId)
        {
            var categoryRepo = _categoryRepository.GetCategory(category.categoryId);
            if(categoryRepo != null && categoryRepo.RestaurantId == restaurantId)
            {
                Category categoryToUpdate = new Category()
                {
                    CategoryId = category.categoryId,
                    CategoryName = category.CategoryName,
                    RestaurantId = restaurantId
                };
                Category categoryUpdated = _categoryRepository.UpdateCategory(categoryToUpdate);

                if (categoryUpdated != null)
                {
                    CategoryDto categoryResponse = new CategoryDto()
                    {
                        CategoryId = categoryUpdated.CategoryId,
                        CategoryName = categoryUpdated.CategoryName,
                        RestaurantId = categoryUpdated.RestaurantId,
                    };
                    return categoryResponse;
                }
                throw new NotFoundException("La categoría que se quiere actualizar no existe");
            }
            throw new Exception("No se puede modificar una categoria de otro restaurante");
        }

        public int GetRestaurantId(int idProducto)
        {
            var restaurantId = _categoryRepository.GetRestaurantId(idProducto);
            if (restaurantId != 0)
            {
                return restaurantId;
            }
            throw new Exception("Restaurante o categoria incorrecta");
        }
    }
}
