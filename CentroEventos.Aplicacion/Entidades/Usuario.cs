using System;
using System.ComponentModel.DataAnnotations;
using CentroEventos.Aplicacion.Enumerativos;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroEventos.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    //[Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;
    //[Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellido { get; set; }= string.Empty;
    //[Required(ErrorMessage = "El Email es obligatorio")]
    public string Email { get; set; }= string.Empty;
    //[Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Contrasenia { get; set; } = string.Empty;
    public string PermisosL { get; set; } = "";
    [NotMapped]
    public List<Permiso> Permisos
    {
        get => PermisosL
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => Enum.Parse<Permiso>(p)).ToList();

        set => PermisosL = string.Join(",", value.Select(p => p.ToString()));
    }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}
