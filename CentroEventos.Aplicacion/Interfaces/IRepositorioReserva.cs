using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.Interfaces
{
    public interface IRepositorioReserva
    {
        // CRUD básico
        void Agregar(Reserva reserva);
        void Eliminar(int id);
        void Modificar(Reserva reserva);
        Reserva? ObtenerPorId(int id);
        List<Reserva> ObtenerTodos();

        // Consultas para validaciones
        bool ExisteReservaParaPersonaYEvento(int usuarioId, int eventoDeportivoId);
        int ContarReservasPorEvento(int eventoDeportivoId);
        List<Reserva> ObtenerReservasPorEvento(int eventoDeportivoId);
        List<Reserva> ObtenerTodasReservasPorEvento(int eventoId);
        List<Reserva> ObtenerReservasPorUsuario(int usuarioId);
    }
}
