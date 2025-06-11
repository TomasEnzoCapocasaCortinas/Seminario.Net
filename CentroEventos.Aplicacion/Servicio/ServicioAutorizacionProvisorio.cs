//Si IdUsuario == 1, devuelve true para cualquier permiso solicitado. 
//Si el IdUsuario es distinto de 1, devuelve false para todos los permisos. 
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Servicio;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario, Permiso permiso)
    {
        return idUsuario == 1;
    }

}