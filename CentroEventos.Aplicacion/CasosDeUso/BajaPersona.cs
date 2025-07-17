using System;
using CentroEventos.Aplicacion.Interfaces; 
using CentroEventos.Aplicacion.Excepciones; 
using CentroEventos.Aplicacion.Enumerativos; 
namespace CentroEventos.Aplicacion.CasosDeUso; 

public class BajaPersona
{
    private IRepositorioPersona RepositorioP;
    private IServicioAutorizacion Autorizacion;

    public BajaPersona(IRepositorioPersona repositorio, IServicioAutorizacion autorizacion)
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
            throw new FalloAutorizacionException("No posee el permiso para realizar esta accion.");
        }
    }
}
