using ProyectoFinal_Restaurante.Entities;

namespace ProyectoFinal_Restaurante.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Category CreateCategory (Category category);
        public Category UpdateCategory (Category category);
        public Category GetCategory (int id);
        public Category DeleteCategory (int id);
        public Category GetCategoryByRestaurant (int  restaurantId);
    }
}
