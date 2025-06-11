using System;
using CentroEventos.Aplicacion.Interfaces;//agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto
using CentroEventos.Aplicacion.Excepciones; //agregue esto
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerEventoDeportivoPorId
{
    private readonly IRepositorioEventoDeportivo _repositorio;

        public ObtenerEventoDeportivoPorId(IRepositorioEventoDeportivo repositorio)
        {
            _repositorio = repositorio;
        }

        public EventoDeportivo Ejecutar(int id)
        {
            var evento = _repositorio.ObtenerPorId(id);
            if (evento == null)
                throw new EntidadNotFoundException("Evento no encontrado.");

            return evento;
        }
}
