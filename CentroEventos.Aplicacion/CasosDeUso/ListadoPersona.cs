using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
namespace CentroEventos.Aplicacion.CasosDeUso;

public class ListadoPersona
{
    private readonly IRepositorioPersona RepositorioP;

    public ListadoPersona(IRepositorioPersona repositorio)
    {
        RepositorioP = repositorio;
    }
    public List<Persona> Ejecutar()
        {
            return RepositorioP.ObtenerTodas();
        }
}
