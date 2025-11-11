using ProyectoFinal_Restaurante.Entities;
using ProyectoFinal_Restaurante.Repositories.Interfaces;

namespace ProyectoFinal_Restaurante.Repositories.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public void DeleteRestaurant(int restaurantId)
        {
            var restaurantToDelete = _restaurants.FirstOrDefault(x => x.RestaurantId == restaurantId);
            if (restaurantToDelete != null)
            {
                _restaurants.Remove(restaurantToDelete);
                return;
            }
            throw new Exception("Restaurante no encontrado");
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var restaurantToUpdate = _restaurants.FirstOrDefault(x => x.RestaurantId == restaurant.RestaurantId);
            if (restaurantToUpdate != null)
            {
                restaurantToUpdate.Name = restaurant.Name;
                restaurantToUpdate.Email = restaurant.Email;
                restaurantToUpdate.Address = restaurant.Address;
                restaurantToUpdate.Phone = restaurant.Phone;
                return restaurantToUpdate;
            }
            throw new Exception("Restaurante no encontrado");
        }

        public string ChangePassword(int restaurantId, string newPassword)
        {
            var restaurantToChangePassword = _restaurants.FirstOrDefault(x => x.RestaurantId == restaurantId);

            if(restaurantToChangePassword != null)
            {
                restaurantToChangePassword.Password = newPassword;
                //savechanges
                return restaurantToChangePassword.Password;
            }
            throw new Exception("Restaurante no encontrado");
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
