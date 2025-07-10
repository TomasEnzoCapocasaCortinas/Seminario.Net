namespace CentroEventos.Aplicacion.Enumerativos;

public enum Permiso
{
    EventoAlta,             //Puede crear nuevos eventos deportivos en el centro 
    EventoModificacion,     //Puede modificar los detalles de los eventos deportivos
    EventoBaja,             //Puede eliminar eventos deportivos del centro 
    ReservaAlta,            //Puede registrar nuevas reservas  
    ReservaModificacion,    //Puede modificar las reservas  
    ReservaBaja,            //Puede dar de baja reservas 
    PersonaAlta,            //Puede dar de alta nuevas personas del sistema 
    PersonaModificacion,    //Puede modificar los datos de las personas
    PersonaBaja,             //Puede dar de baja personas del sistema
    UsuarioAlta,             //Puede dar de alta usuarios al sistema
    UsuarioModificacion,
    UsuarioBaja
}