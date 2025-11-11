using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Entities
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Phone {  get; set; }
        public string? Address { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
