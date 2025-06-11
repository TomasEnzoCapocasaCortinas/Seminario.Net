using System;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Excepciones;

using System;

namespace CentroEventos.Aplicacion.CasosDeUso;

public class EliminarEventoDeportivo
{
    private readonly IRepositorioEventoDeportivo _repositorioEvento;
    private readonly IRepositorioReserva _repositorioReserva;

        public EliminarEventoDeportivo(IRepositorioEventoDeportivo repositorioEvento, IRepositorioReserva repositorioReserva)
        {
            _repositorioEvento = repositorioEvento;
            _repositorioReserva = repositorioReserva;
        }


        public void Ejecutar(int id)
        {
            var reservasAsociadas = _repositorioReserva.ObtenerReservasPorEvento(id); //cambie el nombre a ObtenerReservasPorEvento
            if (reservasAsociadas.Any())
                throw new OperacionInvalidaException("No se puede eliminar el evento, existen reservas asociadas.");

            // Si no hay reservas, se procede a eliminar el evento.
            _repositorioEvento.Eliminar(id);
        }
}
