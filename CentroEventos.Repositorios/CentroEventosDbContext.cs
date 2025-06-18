using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios
{
    public class CentroEventosDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public CentroEventosDbContext(DbContextOptions<CentroEventosDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Persona>().HasIndex(p => p.Dni).IsUnique();
            modelBuilder.Entity<Persona>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<Persona>(entidad =>
            {
                entidad.HasKey(p => p.IdUsuario);
                entidad.Property(p => p.Dni).IsRequired().HasMaxLength(20);
                entidad.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entidad.Property(p => p.Apellido).IsRequired().HasMaxLength(100);
                entidad.Property(p => p.Email).IsRequired().HasMaxLength(200);
                entidad.Property(p => p.Tel).HasMaxLength(15);
            });

            modelBuilder.Entity<Reserva>()
                .Property(r => r.EstadoAsistencia)
                .HasConversion<string>();

            
            modelBuilder.Entity<Reserva>(entidad =>
            {  
                entidad.HasKey(r => r.Id);
                entidad.Property(r => r.PersonaId).IsRequired();
                entidad.Property(r => r.EventoDeportivoId).IsRequired();
                entidad.Property(r => r.FechaAltaReserva).IsRequired();
                entidad.Property(r => r.EstadoAsistencia)
                       .HasConversion<string>()
                       .IsRequired();
            });
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Permisos)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => Enum.Parse<Permiso>(p))
                        .ToList()
                );
            modelBuilder.Entity<EventoDeportivo>(entidad =>
            {
                entidad.HasKey(e => e.ID);
                entidad.Property(e => e.Nombre).IsRequired();
                entidad.Property(e => e.Descripcion);
                entidad.Property(e => e.FechaHoraInicio).IsRequired();
                entidad.Property(e => e.DuracionHoras).IsRequired();
                entidad.Property(e => e.CupoMaximo).IsRequired();
                entidad.Property(e => e.ResponsableID).IsRequired();
            });
        }
    }
}
