using System;
using System.Collections.Concurrent;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto


namespace CentroEventos.Aplicacion;

public class PersonaValidador
{
    private IRepositorioPersona RepositorioP;
    public PersonaValidador(IRepositorioPersona repositorio)
    {
        RepositorioP = repositorio;
    }
    public bool Validar(Persona p)
    {
        if ((string.IsNullOrWhiteSpace(p.Nombre)) ||(string.IsNullOrWhiteSpace(p.Apellido)) || (string.IsNullOrWhiteSpace(p.Email)))
        {
            return false;
        }
        else return true;
    }
    public bool IdUnico(Persona p) {
        var pAux = RepositorioP.ObtenerPorId(p.IdUsuario);
        if (pAux != null && p.IdUsuario == pAux.IdUsuario)
        {
            return false;
        }
        else return true;
    }
    public bool DNIUnico(Persona p) {
        var pAux = RepositorioP.ObtenerPorDNI(p.Dni);
        if (pAux != null && p.Dni.Equals(pAux.Dni))
        {
            return false;
        }
        else return true;
    }
    public bool EmailUnico(Persona p) {
        var pAux = RepositorioP.ObtenerPorEmail(p.Email);
        if (pAux != null && p.Email.Equals(pAux.Email))
        {
            return false;
        }
        else return true;
    }
}
