using System;
using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    //[Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    //[Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellido { get; set; }
    //[Required(ErrorMessage = "El Email es obligatorio")]
    public string Email { get; set; }
    //[Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Contrasenia { get; set; } 
    public List<Permiso> Permisos { get; set; }
    public DateTime FechaCreacion { get; set; }
    public Usuario()
    {
        this.Id = 0;
        this.Nombre = string.Empty;
        this.Apellido = string.Empty;
        this.Email = string.Empty;
        this.Contrasenia = string.Empty;
        this.Permisos = new List<Permiso>();
        this.FechaCreacion = DateTime.Now;
    }
}
