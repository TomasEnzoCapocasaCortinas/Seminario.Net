using CentroEventos.UI.Components;
//Agregamos usings casos de uso
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Agregamos servicios al contenedor DI
//Trabsient: se crea una nueva instancia cada vez que se inyecta
builder.Services.AddTransient<AltaEventoDeportivo>();
builder.Services.AddTransient<AltaUsusario>();
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
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioPersona, PersonaRepositorio>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
