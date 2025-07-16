using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListarEventosConCupoDisponible
{
    private readonly IRepositorioEventoDeportivo repositorioEvento;
    private readonly IRepositorioReserva repositorioReserva;

    public ListarEventosConCupoDisponible(IRepositorioEventoDeportivo repoE, IRepositorioReserva repoR)
    {
        repositorioEvento = repoE;
        repositorioReserva = repoR;
    }
    public List<EventoDeportivo> Ejecutar()
{
    var eventos = repositorioEvento.ObtenerTodos();
    var eventosConCupo = new List<EventoDeportivo>();

    foreach (var evento in eventos)
    {
        var reservas = repositorioReserva.ObtenerReservasPorEvento(evento.ID);
        var cantidadReservas = reservas.Count;

        if (cantidadReservas < evento.CupoMaximo)
        {
            eventosConCupo.Add(evento);
        }
    }

    return eventosConCupo;
}
}
