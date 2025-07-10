using System;
using CentroEventos.Aplicacion.Interfaces; //puse esto
using CentroEventos.Aplicacion.Excepciones; //puse esto
using CentroEventos.Aplicacion.Enumerativos; //puse esto
namespace CentroEventos.Aplicacion.CasosDeUso; // cambie CentroDeportivo por CentroEventos

public class CasoDeUsoBajaPersona
{
    private IRepositorioPersona RepositorioP;
    private IServicioAutorizacion Autorizacion;

    public CasoDeUsoBajaPersona(IRepositorioPersona repositorio, IServicioAutorizacion autorizacion)
    {
        RepositorioP = repositorio;
        Autorizacion = autorizacion;
    }

    public void Ejecutar(int id, int usuario)
    {
        if (Autorizacion.PoseeElPermiso(usuario, Permiso.PersonaBaja)) {
            if (!RepositorioP.Eliminar(id))
                throw new EntidadNotFoundException("No se encontró la persona con el ID especificado.");
        }
        else {
            throw new FalloAutorizacionException("No posee el permiso para realizar esta accion."); // un ;
        }
    }
}
