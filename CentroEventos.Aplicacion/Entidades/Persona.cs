using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CentroEventos.Aplicacion.Entidades;

public class Persona
{
    public int IdUsuario{set;get;}
    public string Dni{set;get;} //consulta repo
    public string Nombre{set;get;}
    public string Apellido{set;get;}
    public string Email{set;get;} //consulta repo
    public string? Tel{set;get;}

    public Persona()
    {
        this.IdUsuario = 0;
        this.Dni = string.Empty;
        this.Nombre = string.Empty;
        this.Apellido = string.Empty;
        this.Email = string.Empty;
        this.Tel = null;
    }
    public Persona(int id, string nom, string apellido, string dni, string email, string tel)
    {
        this.IdUsuario = id;
        this.Nombre = nom;
        this.Apellido = apellido;
        this.Dni = dni;
        this.Email = email;
        this.Tel = tel;
    }
    public override string ToString()
    {
        return $"{Nombre} {Apellido} - DNI: {Dni}, Email: {Email}, Tel: {Tel}";
    }

}
