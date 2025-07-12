using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerTodosEventosDeportivos
{
    private readonly IRepositorioEventoDeportivo _repositorio;

        public ObtenerTodosEventosDeportivos(IRepositorioEventoDeportivo repositorio)
        {
            _repositorio = repositorio;
        }

        public List<EventoDeportivo> Ejecutar()
        {
            return _repositorio.ObtenerTodos();
        }
}
