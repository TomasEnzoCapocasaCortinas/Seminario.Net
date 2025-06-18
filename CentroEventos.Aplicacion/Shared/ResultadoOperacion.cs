using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;

public class ResultadoOperacion
{
    public bool Exito { get; set; }
    public string? Mensaje { get; set; }
    
    // Métodos factory para crear resultados
    public static ResultadoOperacion Exitoso(string mensaje = "") 
        => new ResultadoOperacion { Exito = true, Mensaje = mensaje };
    
    public static ResultadoOperacion Fallido(string mensaje) 
        => new ResultadoOperacion { Exito = false, Mensaje = mensaje };
}