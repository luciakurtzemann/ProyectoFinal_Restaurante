using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class CreateCategory
    {
        [Required]
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }
    }
}
