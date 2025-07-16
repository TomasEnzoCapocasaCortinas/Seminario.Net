using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using System.Collections.Generic;

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ReservaListadoPorUsuario
    {
        private readonly IRepositorioReserva _repoReserva;

        public ReservaListadoPorUsuario(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public List<Reserva> Ejecutar(int usuarioId)
        {
            return _repoReserva.ObtenerReservasPorUsuario(usuarioId);
        }
    }
}