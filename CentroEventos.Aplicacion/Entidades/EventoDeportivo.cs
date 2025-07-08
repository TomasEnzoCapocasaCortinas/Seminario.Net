using System;

namespace CentroEventos.Aplicacion.Entidades;

public class EventoDeportivo
{
    public int ID { get; set; } //unico autoIncremental
    public String? Nombre { get; set; }
    public String? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; } // fecha y hora exacta de inicio del evento
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableID { get; set; } // ID del responsable del evento

    public EventoDeportivo()
    {
        this.ID = 0;
        this.Nombre = string.Empty;
        this.Descripcion = string.Empty;
        this.FechaHoraInicio = DateTime.MinValue;
        this.DuracionHoras = 0.0;
        this.CupoMaximo = 0;
        this.ResponsableID = 0;
    }

    public override String ToString()
    {
        return $"Evento {Nombre} ID {ID} Descripcion: {Descripcion} fecha y hora de inicio {FechaHoraInicio:g}. duracion del evento: {DuracionHoras}. cupo maximo de persona:{CupoMaximo} ID del encargado:{ResponsableID}";
    }

    
}
