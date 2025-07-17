using System;
using CentroEventos.Aplicacion.Validadores; 
using CentroEventos.Aplicacion.Interfaces; 
using CentroEventos.Aplicacion.Entidades; 
using CentroEventos.Aplicacion.Excepciones; 

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
