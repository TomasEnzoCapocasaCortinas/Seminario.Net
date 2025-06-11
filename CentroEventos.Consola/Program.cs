using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Servicio;
using CentroEventos.Aplicacion;

// Configurar repositorios y servicios
var repositorioPersona = new PersonaRepositorio();
var repositorioEvento = new RepositorioEventoDeportivoTXT();
var repositorioReserva = new RepositorioReserva();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

// Simulación de usuario administrador (ID = 1)
int idUsuarioAdmin = 1;

// 📌 Crear una persona
var personaAltaUseCase = new CasoDeUsoAltaPersona(repositorioPersona);
personaAltaUseCase.Ejecutar(new Persona(idUsuarioAdmin, "13345679", "Juan",
                                        "Pérez", "juan@example.com", "123456789"));

// 📌 Listar todas las personas
Console.WriteLine("\n🧑 Lista de Personas:");
foreach (var persona in repositorioPersona.ObtenerTodas())
{
    Console.WriteLine(persona);
}

// 📌 Crear un evento deportivo
var eventoAltaUseCase = new AltaEventoDeportivo(repositorioEvento, repositorioPersona);
eventoAltaUseCase.Ejecutar(new EventoDeportivo
{
    Nombre = "Torneo de Fútbol",
    Descripcion = "Competencia Interuniversitaria",
    FechaHoraInicio = DateTime.Now.AddDays(5),
    DuracionHoras = 2,
    CupoMaximo = 10,
    ResponsableID = 1
}, idUsuarioAdmin);

// 📌 Listar eventos deportivos
Console.WriteLine("\n⚽ Lista de Eventos Deportivos:");
foreach (var evento in repositorioEvento.ObtenerTodos())
{
    Console.WriteLine(evento);
}

// 📌 Crear una reserva
var reservaAltaUseCase = new ReservaAlta(repositorioReserva, repositorioEvento, repositorioPersona,
                                            servicioAutorizacion);
reservaAltaUseCase.Ejecutar(new Reserva
{
    PersonaId = 1,
    EventoDeportivoId = 1,
    FechaAltaReserva = DateTime.Now,
    EstadoAsistencia = EstadoAsistencia.Pendiente
}, idUsuarioAdmin);

// 📌 Listar reservas
Console.WriteLine("\n📌 Lista de Reservas:");
foreach (var reserva in repositorioReserva.ObtenerTodos())
{
    Console.WriteLine(reserva);
}
