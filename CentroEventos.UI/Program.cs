using CentroEventos.UI.Components;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicio;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var dbPath = Path.Combine("..", "CentroEventos.Repositorios", "centroeventos.db");
var fullPath = Path.GetFullPath(dbPath);

builder.Services.AddDbContext<CentroEventosDbContext>(options =>
    options.UseSqlite($"Data Source={fullPath}"));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ServicioSesionUsuario>();

//Agregamos servicios al contenedor DI
//Trabsient: se crea una nueva instancia cada vez que se inyecta
builder.Services.AddTransient<AltaEventoDeportivo>();
builder.Services.AddTransient<AltaUsuario>();
builder.Services.AddTransient<AltaPersona>();
builder.Services.AddTransient<ReservaAlta>();
builder.Services.AddTransient<EliminarEventoDeportivo>();
builder.Services.AddTransient<BajaUsuario>();
builder.Services.AddTransient<BajaPersona>();
builder.Services.AddTransient<ReservaBaja>();
builder.Services.AddTransient<ObtenerTodosEventosDeportivos>();
builder.Services.AddTransient<ObtenerEventoDeportivoPorId>();
builder.Services.AddTransient<ObtenerUsuarioPorId>();
builder.Services.AddTransient<ObtenerPersonaPorId>();
builder.Services.AddTransient<ListarUsuarios>();
builder.Services.AddTransient<ListadoPersona>();
builder.Services.AddTransient<ListarEventosConCupoDisponible>();
builder.Services.AddTransient<ListarAsistenciaAEvento>();
builder.Services.AddTransient<ReservaListado>();
builder.Services.AddTransient<ModificarEventoDeportivo>();
builder.Services.AddTransient<ModificarUsuario>();
builder.Services.AddTransient<ModificarPersona>();
builder.Services.AddTransient<ReservaModificacion>();
builder.Services.AddTransient<ReservaListadoPorEvento>();
builder.Services.AddTransient<ReservaListadoPorUsuario>();


//Scoped: se crea una nueva instancia por cada solicitud
builder.Services.AddScoped<CentroEventosSqlite>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioPersona, PersonaRepositorio>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();

builder.Services.AddScoped<ValidadorUsuario>();
builder.Services.AddScoped<PersonaValidador>();
builder.Services.AddScoped<ValidadorReserva>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ServicioSesionUsuario, ServicioSesionUsuario>();
builder.Services.AddScoped<ServicioUsuario, ServicioUsuario>();
builder.Services.AddScoped<ServicioUsuario, ServicioUsuario>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CentroEventosDbContext>();
    db.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
