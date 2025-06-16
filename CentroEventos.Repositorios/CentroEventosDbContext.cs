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
            modelBuilder.Entity<Persona>().HasIndex(p => p.Dni).IsUnique();
            modelBuilder.Entity<Persona>().HasIndex(p => p.Email).IsUnique();

            modelBuilder.Entity<Reserva>()
                .Property(r => r.EstadoAsistencia)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Permisos)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => Enum.Parse<Permiso>(p))
                        .ToList()
                );
        }
    }
}
