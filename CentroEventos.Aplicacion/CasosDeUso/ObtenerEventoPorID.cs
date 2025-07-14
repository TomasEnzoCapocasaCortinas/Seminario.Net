using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
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
