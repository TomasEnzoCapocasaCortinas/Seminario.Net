using System;  //actualizado con base de datos
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades; 

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{

    private readonly CentroEventosDbContext dataBase;

    public RepositorioEventoDeportivo(CentroEventosDbContext db)
    {
        dataBase = db;
    }

    public void Agregar(EventoDeportivo evento)
    {
        dataBase.EventosDeportivos.Add(evento);
        dataBase.SaveChanges();
    }

    public void Modificar(EventoDeportivo evento)
    {
        dataBase.EventosDeportivos.Update(evento);
        dataBase.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var evento = dataBase.EventosDeportivos.Find(id);
        if (evento != null)
        {
            dataBase.EventosDeportivos.Remove(evento);
            dataBase.SaveChanges();
        }
    }

    public EventoDeportivo? ObtenerPorId(int id)
    {
        return dataBase.EventosDeportivos.Find(id);
    }

    public List<EventoDeportivo> ObtenerTodos()
    {
        return dataBase.EventosDeportivos.ToList();
    }

}


