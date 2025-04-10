public class Documento
{
    public int Id { get; set; }
    public int PropiedadId { get; set; }

    public string TipoDocumento { get; set; } // Imagen, mandato, etc.
    public string NombreArchivo { get; set; }
    public string UrlArchivo { get; set; }
    public DateTime FechaSubida { get; set; }

    public Propiedad Propiedad { get; set; }
}
