using System;
using System.Collections.Concurrent;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones; //agregue esto


namespace CentroEventos.Aplicacion;

public class PersonaValidador
{
    private IRepositorioPersona RepositorioP;
    public PersonaValidador(IRepositorioPersona repositorio)
    {
        RepositorioP = repositorio;
    }
    public void Validar(Persona persona)
    {
        if (persona == null)
            throw new ValidacionException("La persona no puede ser nula.");
        if (string.IsNullOrWhiteSpace(persona.Nombre))
            throw new ValidacionException("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(persona.Apellido))
            throw new ValidacionException("El apellido es obligatorio.");
        if (string.IsNullOrWhiteSpace(persona.Email))
            throw new ValidacionException("El email es obligatorio.");
        if (string.IsNullOrWhiteSpace(persona.Dni))
            throw new ValidacionException("El Dni es obligatorio");
        if (string.IsNullOrWhiteSpace(persona.Tel))
            throw new ValidacionException("El telefono es obligatorio");
    }
    public bool IdUnico(Persona p) {
        var pAux = RepositorioP.ObtenerPorId(p.Id);
        if (pAux != null && p.Id == pAux.Id)
        {
            return false;
        }
        else return true;
    }
    public bool DNIUnico(Persona persona)
    {
    var existente = RepositorioP.ObtenerPorDNI(persona.Dni);
    return existente == null || existente.Id == persona.Id;
    }

    public bool EmailUnico(Persona persona)
    {
    var existente = RepositorioP.ObtenerPorEmail(persona.Email);
    return existente == null || existente.Id == persona.Id;
    }

}
