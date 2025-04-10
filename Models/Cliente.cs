public class Cliente
{
    public int Id { get; set; } // Clave primaria
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }

    // Relación: un cliente tiene muchas propiedades
    public ICollection<Propiedad> Propiedades { get; set; }
}
