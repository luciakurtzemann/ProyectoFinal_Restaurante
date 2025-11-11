using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_Restaurante.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; } 
        public int RestaurantId { get; set; }  
    }
}
