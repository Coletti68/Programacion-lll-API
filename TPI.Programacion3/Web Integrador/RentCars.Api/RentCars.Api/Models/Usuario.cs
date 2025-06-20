public class Usuario
{
    public int Id { get; set; } // cambio aquí
    public string Nombre_Completo { get; set; }
    public string TipoDocumento { get; set; }
    public string DNI { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Pais { get; set; }
    public string Direccion { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Password { get; internal set; }
}
