using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using System.Collections.Generic;

namespace CentroEventos.Aplicacion.CasosDeUso
{
    public class ReservaListado
    {
        private readonly IRepositorioReserva _repoReserva;

        public ReservaListado(IRepositorioReserva repoReserva)
        {
            _repoReserva = repoReserva;
        }

        public List<Reserva> Ejecutar()
        {
            return _repoReserva.ObtenerTodos();
        }
    }
}
