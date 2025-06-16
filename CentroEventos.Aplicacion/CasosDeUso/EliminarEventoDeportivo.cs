using System;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Excepciones;

using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarEventoDeportivo
{
    private readonly IRepositorioEventoDeportivo RepositorioEvento;
    private readonly IRepositorioReserva RepositorioReserva;

        public EliminarEventoDeportivo(IRepositorioEventoDeportivo repositorioEvento, IRepositorioReserva repositorioReserva)
        {
            RepositorioEvento = repositorioEvento;
            RepositorioReserva = repositorioReserva;
        }


        public void Ejecutar(int id)
        {
            var reservasAsociadas = RepositorioReserva.ObtenerReservasPorEvento(id);
            if (reservasAsociadas.Any())
                throw new OperacionInvalidaException("No se puede eliminar el evento, existen reservas asociadas.");

            // Si no hay reservas, se procede a eliminar el evento.
            RepositorioEvento.Eliminar(id);
        }
}
