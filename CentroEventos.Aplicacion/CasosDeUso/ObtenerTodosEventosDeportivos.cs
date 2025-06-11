using System;
using CentroEventos.Aplicacion.Interfaces;  //agregue esto
using CentroEventos.Aplicacion.Entidades;   //agregue esto
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ObtenerTodosEventosDeportivos
{
    private readonly IRepositorioEventoDeportivo _repositorio;

        public ObtenerTodosEventosDeportivos(IRepositorioEventoDeportivo repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<EventoDeportivo> Ejecutar()
        {
            return _repositorio.ObtenerTodos();
        }
}
