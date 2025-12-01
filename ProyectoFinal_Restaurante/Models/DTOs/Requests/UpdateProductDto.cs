using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        [Range (0,1)]
        public int Discount { get; set; } = 0;
        public bool HappyHour { get; set; } = false;
        public bool Agotado { get; set; } = false;
    }
}
