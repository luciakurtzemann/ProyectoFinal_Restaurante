using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; } = 0;
        public bool HappyHour { get; set; } = false;
        public bool IsFavorite { get; set; } = false;
        public bool Agotado { get; set; } = false;

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
