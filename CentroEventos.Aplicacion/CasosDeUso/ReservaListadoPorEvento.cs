using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using System.Collections.Generic;

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ReservaListadoPorEvento
    {
        private readonly IRepositorioReserva _repoReserva;

        public ReservaListadoPorEvento(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public List<Reserva> Ejecutar(int eventoId)
        {
            return _repoReserva.ObtenerReservasPorEvento(eventoId);
        }
    }
}
