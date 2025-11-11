using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Models.DTOs.Responses
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double Price { get; set; }
        public bool IsFavorite { get; set; } = false;
        public int RestaurantId { get; set; }
    }
}
