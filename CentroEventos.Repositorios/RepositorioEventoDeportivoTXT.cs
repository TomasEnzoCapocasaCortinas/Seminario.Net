using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades; 

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{

    // Nombre del archivo donde se guardarán los eventos.
    private readonly string _nombreArchivo = "Eventos.txt";

    // Agrega un EventoDeportivo en el archivo.
    public void Agregar(EventoDeportivo evento)
    {
        // Se asume que el evento ya posee un ID asignado previamente (quizás por la lógica de negocio o un generador de IDs).
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(evento.ID);
        sw.WriteLine(evento.Nombre);
        sw.WriteLine(evento.Descripcion);
        // Usamos el formato "o" (round-trip) para asegurar una conversión correcta de la fecha
        sw.WriteLine(evento.FechaHoraInicio.ToString("o"));
        sw.WriteLine(evento.DuracionHoras);
        sw.WriteLine(evento.CupoMaximo);
        sw.WriteLine(evento.ResponsableID);
    }

    // Devuelve una lista con todos los eventos que se hayan guardado.
    public List<EventoDeportivo> ObtenerTodos()
    {
        var resultado = new List<EventoDeportivo>();

        if (File.Exists(_nombreArchivo))
        {
            using var sr = new StreamReader(_nombreArchivo);
            while (!sr.EndOfStream)
            {
                var evento = new EventoDeportivo();
                evento.ID = int.Parse(sr.ReadLine() ?? "0");
                evento.Nombre = sr.ReadLine() ?? "";
                evento.Descripcion = sr.ReadLine() ?? "";
                evento.FechaHoraInicio = DateTime.Parse(sr.ReadLine() ?? DateTime.MinValue.ToString());
                evento.DuracionHoras = double.Parse(sr.ReadLine() ?? "0");
                evento.CupoMaximo = int.Parse(sr.ReadLine() ?? "0");
                evento.ResponsableID = int.Parse(sr.ReadLine() ?? "0");

                resultado.Add(evento);
            }
        }

        return resultado;
    }

    // Busca y devuelve un evento a partir de su ID.
    public EventoDeportivo? ObtenerPorId(int id)
    {
        var eventos = ObtenerTodos();
        foreach (var evento in eventos)
        {
            if (evento.ID == id)
            {
                return evento;
            }
        }
        return null;
    }
    // Modifica un evento existente, sobrescribiendo el archivo entero.
    public void Modificar(EventoDeportivo evento)
    {
        var eventos = ObtenerTodos();
        int i = 0;
        bool modificado = false;
        // Se recorre la lista hasta encontrar el evento con el ID buscado o hasta finalizar la lista
        while (i < eventos.Count && !modificado)
        {
            if (eventos[i].ID == evento.ID)
            {
                // Se actualiza el evento encontrado con los nuevos datos
                eventos[i] = evento;
                modificado = true;
            }
            i++;
        }
        // Si no se encontró el evento, se lanza una excepción
        if (!modificado)
        {
            throw new Exception($"Evento con ID {evento.ID} no encontrado para modificar.");
        }
        // Se sobrescribe el archivo con la lista actualizada
        GuardarTodos(eventos);
    }
    // Elimina un evento según su ID y vuelve a guardar el listado sin el evento.
    public void Eliminar(int id)
    {
        var eventos = ObtenerTodos();
        // Obtiene todos los eventos previamente guardados
        int i = 0;
        bool eliminado = false;
        // Recorre la lista mientras no se haya eliminado el evento y no se haya terminado la lista
        while (i < eventos.Count && !eliminado)
        {
            if (eventos[i].ID == id)
            {
                // Elimina el evento de la lista
                eventos.RemoveAt(i);
                eliminado = true;
            }
            else
            {
                i++;
            }
        }
        // Si no se encontró el evento, lanza una excepción indicando el error
        if (!eliminado)
        {
            throw new Exception($"Evento con ID {id} no encontrado para eliminar.");
        }
        // Guarda todos los eventos (ahora sin el que se eliminó) en el archivo
        GuardarTodos(eventos);
    }

    // Método auxiliar para sobrescribir el archivo con la lista completa de eventos.
    private void GuardarTodos(List<EventoDeportivo> lista)
    {
        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (var evento in lista)
        {
            sw.WriteLine(evento.ID);
            sw.WriteLine(evento.Nombre);
            sw.WriteLine(evento.Descripcion);
            sw.WriteLine(evento.FechaHoraInicio.ToString("o"));
            sw.WriteLine(evento.DuracionHoras);
            sw.WriteLine(evento.CupoMaximo);
            sw.WriteLine(evento.ResponsableID);
        }
    }
        //List<EventoDeportivo> eventos
        //Buscar por ID, eliminar, y modificar deben de ser llamadas con la lista obtenida de ObtenerTodos(). Esto con el fin de que no sea necesario leer el archivo en cada operacion.
}


