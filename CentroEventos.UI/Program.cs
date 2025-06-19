using CentroEventos.UI.Components;
//Agregamos usings casos de uso
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicio;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CentroEventosDbContext>(options =>
    options.UseSqlite("Data Source=centroeventos.db"));
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ServicioSesionUsuario>();
builder.Services.AddBlazoredLocalStorage();
//Agregamos servicios al contenedor DI
//Trabsient: se crea una nueva instancia cada vez que se inyecta
builder.Services.AddTransient<AltaEventoDeportivo>();
builder.Services.AddTransient<AltaUsuario>();
builder.Services.AddTransient<CasoDeUsoAltaPersona>();
builder.Services.AddTransient<ReservaAlta>();
builder.Services.AddTransient<EliminarEventoDeportivo>();
builder.Services.AddTransient<BajaUsuario>();
builder.Services.AddTransient<CasoDeUsoBajaPersona>();
builder.Services.AddTransient<ReservaBaja>();
builder.Services.AddTransient<ObtenerTodosEventosDeportivos>();
builder.Services.AddTransient<ObtenerEventoDeportivoPorId>();
builder.Services.AddTransient<ListarUsuarios>();
builder.Services.AddTransient<CasoDeUsoListadoPersona>();
builder.Services.AddTransient<ReservaListado>();
builder.Services.AddTransient<ModificarEventoDeportivo>();
builder.Services.AddTransient<ModificarUsuario>();
builder.Services.AddTransient<CasoDeUsoModificacionPersona>();
builder.Services.AddTransient<ReservaModificacion>();

//Scoped: se crea una nueva instancia por cada solicitud
builder.Services.AddScoped<CentroEventosSqlite>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioPersona, PersonaRepositorio>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();

builder.Services.AddScoped<ValidadorUsuario>();
builder.Services.AddScoped<PersonaValidador>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<ServicioSesionUsuario, ServicioSesionUsuario>();
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
