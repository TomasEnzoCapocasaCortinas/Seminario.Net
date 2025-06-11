using System;
using CentroEventos.Aplicacion.Entidades; // agregue esto
namespace CentroEventos.Aplicacion.Interfaces;


public interface IRepositorioEventoDeportivo
{
    void Agregar(EventoDeportivo evento);
    void Modificar(EventoDeportivo evento);
    void Eliminar(int id);
    EventoDeportivo? ObtenerPorId(int id);
    List<EventoDeportivo> ObtenerTodos();
}
