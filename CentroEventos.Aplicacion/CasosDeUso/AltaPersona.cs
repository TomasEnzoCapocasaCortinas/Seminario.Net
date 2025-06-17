using System;
using System.Data;
using CentroEventos.Aplicacion.Interfaces; 
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion;

public class CasoDeUsoAltaPersona
{
    private readonly IRepositorioPersona RepositorioP;

    public CasoDeUsoAltaPersona(IRepositorioPersona repositorio)
    {
        RepositorioP = repositorio;
    }
    public void Ejecutar (Persona nuevaPersona)
    {
        if (RepositorioP.ObtenerPorDNI(nuevaPersona.Dni) != null)
            throw new DuplicadoException("Ya existe una persona con ese DNI.");

        if (RepositorioP.ObtenerPorEmail(nuevaPersona.Email) != null)
            throw new DuplicadoException("Ya existe una persona con ese Email.");

        RepositorioP.Agregar(nuevaPersona);
    }
}
