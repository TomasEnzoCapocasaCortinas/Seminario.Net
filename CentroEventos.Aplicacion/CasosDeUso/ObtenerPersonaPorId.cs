using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerPersonaPorId
{
    private readonly IRepositorioPersona repositorioPersona;
    public ObtenerPersonaPorId(IRepositorioPersona repo)
    {
        repositorioPersona = repo;
    }
    public Persona Ejecutar(int id)
    {
        var persona = repositorioPersona.ObtenerPorId(id);
        if (persona == null)
        {
            throw new EntidadNotFoundException("Persona no encontrada");
        }
        return persona;
    }
}
