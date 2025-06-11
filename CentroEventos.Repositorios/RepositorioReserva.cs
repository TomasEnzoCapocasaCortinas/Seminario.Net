using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
using System.Globalization;

namespace CentroEventos.Repositorios
{
    public class RepositorioReserva : IRepositorioReserva
    {
        private readonly string _rutaArchivo = "Data/reservas.txt";
        private readonly string _rutaUltimoId = "Data/ultima_reserva_id.txt";

        public RepositorioReserva()
        {
            Directory.CreateDirectory("Data");

            if (!File.Exists(_rutaArchivo))
                File.Create(_rutaArchivo).Close();

            if (!File.Exists(_rutaUltimoId))
                File.WriteAllText(_rutaUltimoId, "0");
        }

        private int ObtenerNuevoId()
        {
            int ultimoId = int.Parse(File.ReadAllText(_rutaUltimoId));
            int nuevoId = ultimoId + 1;
            File.WriteAllText(_rutaUltimoId, nuevoId.ToString());
            return nuevoId;
        }

        public void Agregar(Reserva reserva)
        {
            reserva.Id = ObtenerNuevoId();
            var linea = $"{reserva.Id},{reserva.PersonaId},{reserva.EventoDeportivoId},{reserva.FechaAltaReserva:o},{reserva.EstadoAsistencia}";
            File.AppendAllLines(_rutaArchivo, new[] { linea });
        }

        public void Eliminar(int id)
        {
            var reservas = ObtenerTodos().Where(r => r.Id != id).ToList();
            SobrescribirArchivo(reservas);
        }

        public void Modificar(Reserva reserva)
        {
            var reservas = ObtenerTodos().Select(r => r.Id == reserva.Id ? reserva : r).ToList();
            SobrescribirArchivo(reservas);
        }

        public Reserva? ObtenerPorId(int id)
        {
            return ObtenerTodos().FirstOrDefault(r => r.Id == id);
        }

        public List<Reserva> ObtenerTodos()
        {
            var lineas = File.ReadAllLines(_rutaArchivo);
            var lista = new List<Reserva>();

            foreach (var linea in lineas)
            {
                var partes = linea.Split(',');

                if (partes.Length < 5)
                    continue;

                lista.Add(new Reserva
                {
                    Id = int.Parse(partes[0]),
                    PersonaId = int.Parse(partes[1]),
                    EventoDeportivoId = int.Parse(partes[2]),
                    FechaAltaReserva = DateTime.Parse(partes[3], null, DateTimeStyles.RoundtripKind),
                    EstadoAsistencia = Enum.Parse<EstadoAsistencia>(partes[4])
                });
            }

            return lista;
        }

        private void SobrescribirArchivo(List<Reserva> reservas)
        {
            var lineas = reservas.Select(r =>
                $"{r.Id},{r.PersonaId},{r.EventoDeportivoId},{r.FechaAltaReserva:o},{r.EstadoAsistencia}");
            File.WriteAllLines(_rutaArchivo, lineas);
        }

        public bool ExisteReservaParaPersonaYEvento(int personaId, int eventoId)
        {
            return ObtenerTodos().Any(r => r.PersonaId == personaId && r.EventoDeportivoId == eventoId);
        }

        public int ContarReservasPorEvento(int eventoId)
        {
            return ObtenerTodos().Count(r => r.EventoDeportivoId == eventoId);
        }

        public List<Reserva> ObtenerReservasPorEvento(int eventoId)
        {
            return ObtenerTodos().Where(r => r.EventoDeportivoId == eventoId).ToList();
        }

        public List<Reserva> ObtenerReservasPorPersona(int personaId)
        {
            return ObtenerTodos().Where(r => r.PersonaId == personaId).ToList();
        }
    }
}
