using ProyectoFinal_Restaurante.Data;
using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Repositories.Interfaces;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ProyectoFinal_RestauranteContext _context;
        public RestaurantRepository (ProyectoFinal_RestauranteContext context)
        {
            _context = context;
        }
        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int restaurantId)
        {
            var restaurantToDelete = _context.Restaurants.FirstOrDefault(x => x.RestaurantId == restaurantId);
            _context.Restaurants.Remove(restaurantToDelete);
            _context.SaveChanges();
            return restaurantToDelete;
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var restaurantToUpdate = _context.Restaurants.FirstOrDefault(x => x.RestaurantId == restaurant.RestaurantId);
            if (restaurantToUpdate != null)
            {
                restaurantToUpdate.Name = restaurant.Name;
                restaurantToUpdate.Email = restaurant.Email;
                restaurantToUpdate.Address = restaurant.Address;
                restaurantToUpdate.Phone = restaurant.Phone;
                _context.SaveChanges();
                return restaurantToUpdate;
            }
            return null;
        }

        public string ChangePassword(int restaurantId, string oldPassword, string newPassword)
        {
            var restaurantToChangePassword = _context.Restaurants.FirstOrDefault(x => x.RestaurantId == restaurantId);

            if(restaurantToChangePassword != null)
            {
                if (restaurantToChangePassword.Password == oldPassword)
                {
                    restaurantToChangePassword.Password = newPassword;
                }
                _context.SaveChanges();
                return restaurantToChangePassword.Password;
            }
            return null;
        }


        public static List<Restaurant> _restaurants = new List<Restaurant>
        {
            new Restaurant
            {
                RestaurantId = 1,
                Name = "Burger House",
                Email = "contacto@burgerhouse.com",
                Password = "burger123", // solo testing
                Phone = 1122334455,
                Address = "Av. Libertador 1234",
                Categories = new List<Category>(),
                Products = new List<Product>()
            },
            new Restaurant
            {
                RestaurantId = 2,
                Name = "Café Central",
                Email = "info@cafecentral.com",
                Password = "cafe2024", // solo testing
                Phone = 1144556677,
                Address = "Calle Belgrano 789",
                Categories = new List<Category>(),
                Products = new List<Product>()
            },
            new Restaurant
            {
                RestaurantId = 3,
                Name = "Mexicana Viva",
                Email = "hola@mexicanaviva.com",
                Password = "mexico99", // solo testing
                Phone = 1133221100,
                Address = "San Martín 456",
                Categories = new List<Category>(),
                Products = new List<Product>()
            }
        };


    }
}
