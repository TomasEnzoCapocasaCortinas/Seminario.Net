using System;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto
using CentroEventos.Aplicacion.Excepciones; //agregue esto
namespace CentroEventos.Aplicacion.CasosDeUso;

public class CasoDeUsoModificacionPersona
{
    private readonly IRepositorioPersona RepositorioP;

    public CasoDeUsoModificacionPersona(IRepositorioPersona repositorio)
    {
        RepositorioP = repositorio;
    }

    public void Ejecutar (Persona personaActualizada)
    {
        if (!RepositorioP.Actualizar(personaActualizada))
            throw new EntidadNotFoundException("No se encontró la persona a actualizar.");
    }
}
