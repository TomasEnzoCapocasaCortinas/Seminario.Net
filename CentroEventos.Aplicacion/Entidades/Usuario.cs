using System;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Email { get; set; } = "";
    public string Contrasenia { get; set; } = "";
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    //protected Usuario() {} //Constructor para EF Code
}
