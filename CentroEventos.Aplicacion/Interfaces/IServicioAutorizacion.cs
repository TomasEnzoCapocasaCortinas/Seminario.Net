/*
Se requiere desarrollar un servicio que valide si un usuario tiene los permisos necesarios para realizar 
una operación sobre el sistema.
*/

using CentroEventos.Aplicacion.Enumerativos;

namespace CentroEventos.Aplicacion.Interfaces;

public interface IServicioAutorizacion
{
    void PoseeElPermiso(int IdUsuario, Permiso permiso);

} 