using ProyectoFinal_Restaurante.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Models.DTOs.Requests
{
    public class UpdateCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
