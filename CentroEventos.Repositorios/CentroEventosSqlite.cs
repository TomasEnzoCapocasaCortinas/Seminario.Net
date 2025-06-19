namespace CentroEventos.Repositorios;

public class CentroEventosSqlite
{
    private readonly CentroEventosDbContext _context;

    public CentroEventosSqlite(CentroEventosDbContext context)
    {
        _context = context;
    }

    public void Inicializar()
    {
        _context.Database.EnsureCreated();
    }
}