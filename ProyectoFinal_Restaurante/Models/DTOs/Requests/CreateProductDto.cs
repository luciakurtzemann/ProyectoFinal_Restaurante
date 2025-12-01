using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class CreateProductDto
    {
        [Required]
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        [Range (0, 100000)]
        public double Price { get; set; } = 0;
        [Range(0, 1)]
        public double Discount { get; set; } = 0;
        public bool HappyHour { get; set; }
        public bool Agotado { get; set; } = false;
        public int CategoryId { get; set; }
        //public int RestaurantId { get; set; }
    }
}
