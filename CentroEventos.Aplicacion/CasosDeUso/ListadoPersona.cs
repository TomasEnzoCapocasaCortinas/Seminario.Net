using System;
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto
namespace CentroEventos.Aplicacion.CasosDeUso;

public class CasoDeUsoListadoPersona
{
    private readonly IRepositorioPersona RepositorioP;

    public CasoDeUsoListadoPersona(IRepositorioPersona repositorio)
    {
        RepositorioP = repositorio;
    }
    public List<Persona> Ejecutar()
        {
            return RepositorioP.ObtenerTodas();
        }
}
