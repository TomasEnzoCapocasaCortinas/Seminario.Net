using System;
using CentroEventos.Aplicacion.Entidades; //agregue esto
using CentroEventos.Aplicacion.Interfaces; //agregue esto
using CentroEventos.Aplicacion.Excepciones; //agregue esto

namespace CentroEventos.Aplicacion.Validadores;

public class ValidadorEventoDeportivo
{
    private IRepositorioPersona _repoPersona;

    public ValidadorEventoDeportivo(IRepositorioPersona repoPersona)
    {
        _repoPersona = repoPersona;
    }


    public void ValidarAlta(EventoDeportivo evento)
    {
        if (evento == null)
            throw new ValidacionException("El evento no puede ser nulo"); //anterior: ValidacionException(nameof(evento), "El evento no puede ser nulo");
        if (string.IsNullOrWhiteSpace(evento.Nombre))
            throw new ValidacionException("El nombre del evento no puede estar vacio"); // cambiar a validacion excepition
        if (string.IsNullOrWhiteSpace(evento.Descripcion))
            throw new ValidacionException("La descripcion del evento no puede estar vacia"); // cambiar a validacion excepition
        if (evento.FechaHoraInicio < DateTime.Now)
            throw new ValidacionException("La Fecha y hora de inicio del evento debe ser posterior a la actual");// cambiar a validacion excepition
        if (evento.CupoMaximo <= 0)
            throw new ValidacionException("El cupo maximo debe ser mayor a 0"); // cambiar a validacion excepition
        if (evento.DuracionHoras <= 0)
            throw new ValidacionException("La duracion del evento no puede ser de 0 horas"); // cambiar a validacion excepition
        var responsable = _repoPersona.ObtenerPorId(evento.ResponsableID);
        if (responsable == null)
            throw new EntidadNotFoundException("El responsable indicado no existe.");
    }
    public void ValidarModificacion(EventoDeportivo evento)
    {
        if (evento.FechaHoraInicio < DateTime.Now)
            throw new ArgumentException("No se puede mofificar un evento pasado");
    }
}