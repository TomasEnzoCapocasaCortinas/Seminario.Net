using System;
using CentroEventos.Aplicacion.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios
{
    public class CentroEventosDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        public CentroEventosDbContext(DbContextOptions<CentroEventosDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasIndex(p => p.Dni).IsUnique();
            modelBuilder.Entity<Persona>().HasIndex(p => p.Email).IsUnique();

            modelBuilder.Entity<Reserva>()
                .Property(r => r.EstadoAsistencia)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
