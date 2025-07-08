using System;
using CentroEventos.Aplicacion.Validadores; //agregue esto
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto
using CentroEventos.Aplicacion.Excepciones; //agregue esto

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarEventoDeportivo
{
    private readonly IRepositorioEventoDeportivo _repositorio;
    private readonly IRepositorioPersona repoP;
    private readonly ValidadorEventoDeportivo _validador;

   public ModificarEventoDeportivo(IRepositorioEventoDeportivo repositorio, IRepositorioPersona repoPersona)
    {
       _repositorio = repositorio;
        repoP = repoPersona;
       _validador = new ValidadorEventoDeportivo(repoPersona);
    }

    public void Ejecutar(EventoDeportivo eventoActualizado)
    {
        var evento = _repositorio.ObtenerPorId(eventoActualizado.ID)
            ?? throw new EntidadNotFoundException("No se encontró el evento");
            
        _repositorio.Modificar(eventoActualizado);
    }
}
