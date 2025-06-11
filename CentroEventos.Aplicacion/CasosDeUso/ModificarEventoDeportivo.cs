using System;
using CentroEventos.Aplicacion.Validadores; //agregue esto
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Entidades; //agregue esto

namespace CentroEventos.Aplicacion.CasosDeUso;

public class ModificarEventoDeportivo
{
    private readonly IRepositorioEventoDeportivo _repositorio;
    private readonly IRepositorioPersona repoP;
    private readonly ValidadorEventoDeportivo _validador;

   public ModificarEventoDeportivo(IRepositorioEventoDeportivo repositorio, IRepositorioPersona repoPersona)
    {
       _repositorio = repositorio;
        repoP = repoPersona;
       _validador = new ValidadorEventoDeportivo(repoPersona);
    }

    public void Ejecutar(EventoDeportivo evento)
    {
        _validador.ValidarModificacion(evento);
        _repositorio.Modificar(evento);
    }
}
