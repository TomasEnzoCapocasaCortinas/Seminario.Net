using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace CentroEventos.Repositorios;

public class CentroEventosDbContextFactory : IDesignTimeDbContextFactory<CentroEventosDbContext>
{   public CentroEventosDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CentroEventosDbContext>();
        optionsBuilder.UseSqlite("Data Source=centroeventos.db");

        return new CentroEventosDbContext(optionsBuilder.Options);
    }
}
