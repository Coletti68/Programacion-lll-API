public class MultaResumenResponse
{
    public int MultaId { get; set; }
    public string Descripcion { get; set; }
    public decimal Monto { get; set; }
    public string Estado { get; set; }
    public DateTime Fecha { get; set; } // opcional
    public string? UsuarioNombre { get; set; } // opcional si querés contexto en un listado admin
    public DateTime? FechaVencimiento { get; set; } // 🔽 nueva propiedad

}
