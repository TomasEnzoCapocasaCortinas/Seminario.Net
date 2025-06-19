using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroEventosDbContext : DbContext
{
    public CentroEventosDbContext(DbContextOptions<CentroEventosDbContext> options)
        : base(options) { }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- Persona ---
        modelBuilder.Entity<Persona>(entidad =>
        {
            entidad.ToTable("Personas");
            entidad.HasKey(p => p.Id); // ← Corregido
            entidad.HasIndex(p => p.Dni).IsUnique();
            entidad.HasIndex(p => p.Email).IsUnique();
            entidad.Property(p => p.Dni).IsRequired().HasMaxLength(20);
            entidad.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            entidad.Property(p => p.Apellido).IsRequired().HasMaxLength(100);
            entidad.Property(p => p.Email).IsRequired().HasMaxLength(200);
            entidad.Property(p => p.Tel).HasMaxLength(15);
        });

        // --- Usuario ---
        modelBuilder.Entity<Usuario>(entidad =>
        {
            entidad.ToTable("Usuarios");
            entidad.HasKey(u => u.Id);
            entidad.HasIndex(u => u.Email).IsUnique();
            entidad.Property(u => u.Nombre).IsRequired();
            entidad.Property(u => u.Apellido).IsRequired();
            entidad.Property(u => u.Email).IsRequired();
            entidad.Property(u => u.Contrasenia).IsRequired();
            entidad.Property(u => u.Permisos)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(p => Enum.Parse<Permiso>(p))
                          .ToList()
                );
        });

        // --- Evento Deportivo ---
        modelBuilder.Entity<EventoDeportivo>(entidad =>
        {
            entidad.ToTable("EventosDeportivos");
            entidad.HasKey(e => e.ID);
            entidad.Property(e => e.Nombre).IsRequired();
            entidad.Property(e => e.Descripcion);
            entidad.Property(e => e.FechaHoraInicio).IsRequired();
            entidad.Property(e => e.DuracionHoras).IsRequired();
            entidad.Property(e => e.CupoMaximo).IsRequired();
            entidad.Property(e => e.ResponsableID).IsRequired();
        });

        // --- Reserva ---
        modelBuilder.Entity<Reserva>(entidad =>
        {
            entidad.ToTable("Reservas");
            entidad.HasKey(r => r.Id);
            entidad.Property(r => r.PersonaId).IsRequired();
            entidad.Property(r => r.EventoDeportivoId).IsRequired();
            entidad.Property(r => r.FechaAltaReserva).IsRequired();
            entidad.Property(r => r.EstadoAsistencia)
                   .HasConversion<string>()
                   .IsRequired();
        });
    }
}
