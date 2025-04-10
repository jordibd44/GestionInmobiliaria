using Microsoft.EntityFrameworkCore;
using GestionInmobiliaria.Models; // Cambia esto por el namespace correcto de tus modelos

namespace GestionInmobiliaria.Data
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Propiedad>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)"); // Especifica tipo de columna y precisión

            // Configuración de la relación entre Propiedad y Cliente
            modelBuilder.Entity<Propiedad>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Propiedades)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade on delete para Propiedades y Clientes

            // No necesitas configurar la relación de EnvioDocumento si no se va a crear la tabla
        }
    }
}
// Compare this snippet from Models/Cliente.cs:
// public class Cliente
// {
//     public int Id { get; set; }          //     public string Nombre { get; set; }
//     public string Nombre { get; set; }                   //     public string Apellido { get; set; }
//     public string Apellido { get; set; }                //     public string Email { get; set; }
//     public string Email { get; set; }                  //     public string Telefono { get; set; }
//     public string Telefono { get; set; }               //     public string Direccion { get; set; }
//     public string Direccion { get; set; }             //     public string Ciudad { get; set; }
//     public string Ciudad { get; set; }                //     public string Provincia { get; set; }
//     public string Provincia { get; set; }             //     public string CodigoPostal { get; set; }
//     public string CodigoPostal { get; set; }          //     public string Pais { get; set; }
//     public string Pais { get; set; }                 //     public string TipoCliente { get; set; }
//     public string TipoCliente { get; set; }          //     public string Observaciones { get; set; }
//     public string Observaciones { get; set; }       //     public ICollection<Propiedad> Propiedades { get; set; }
//     public ICollection<Propiedad> Propiedades { get; set; } // Relación con Propiedades
//     public ICollection<EnvioDocumento> EnviosDocumentos { get; set; } // Relación con EnvioDocumento

// }
// Compare this snippet from Models/Documento.cs: