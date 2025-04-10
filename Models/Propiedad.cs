using System.ComponentModel.DataAnnotations;


public class Propiedad
{
    public int Id { get; set; }
    public int ClienteId { get; set; } // Clave foránea
    [Required]
    public string Direccion { get; set; }
    public string Tipo { get; set; } // Piso, casa, local...
    public double Superficie { get; set; }
    public int Habitaciones { get; set; }
    public int Banos { get; set; }
    public decimal Precio { get; set; }
    public string Estado { get; set; } // en venta, vendido, etc.

    // Relaciones
    public Cliente Cliente { get; set; }
    public ICollection<Documento> Documentos { get; set; }
}
