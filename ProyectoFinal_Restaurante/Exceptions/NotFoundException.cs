namespace ProyectoFinal_Restaurante.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message) : base(message)
        {
            // No se necesita nada más aquí.
            // Hereda todo de la clase 'Exception'
        }
    }
}
