using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Models.DTOs.Responses
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }
    }
}
