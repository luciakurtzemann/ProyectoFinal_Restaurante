namespace ProyectoFinal_Restaurante.Models.DTOs.Responses
{
    public class DashboardDto
    {
        public int totalProductos {  get; set; }
        public int totalCategorias { get; set; }
        public int productosEnHappyHour { get; set; }
        public int productosConDescuento { get; set; }
        public string productoMasCaro { get; set; }
        public string productoMasBarato { get; set; }
    }
}
