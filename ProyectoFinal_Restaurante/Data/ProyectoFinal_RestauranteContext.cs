using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using ProyectoFinal_Restaurante.Entities;

namespace ProyectoFinal_Restaurante.Data
{
    public class ProyectoFinal_RestauranteContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // Esto le va a decir a Entity Framework que va a tener una tabla que guarda registros de esa entidad
        public DbSet<Category> Categories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public ProyectoFinal_RestauranteContext (DbContextOptions <ProyectoFinal_RestauranteContext> options): base(options)
        {

        }//Acá estamos llamando al constructor de DbContext que es el que acepta las opciones


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Restaurant admin = new Restaurant()
            {
                RestaurantId = 1,
                Name = "Administrador",
                Email = "admin@gmail.com",
                Password = "vickysereluly",
                Phone = 123456,
                Address = "Juan B Justo 9200"
            };

            modelBuilder.Entity<Restaurant>().HasData(
                admin);

            base.OnModelCreating(modelBuilder);
        }

    }
}
