using System;
using System.Data;
using CentroEventos.Aplicacion.Interfaces; // agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto
using CentroEventos.Aplicacion.Excepciones; // agregue esto

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
