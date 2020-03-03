﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AgendaApp
{
    public class Agenda_Ayudante
    {
        Dictionary<int, EntradaAgenda> agenda;
        int ID = 1;
        public Agenda_Ayudante()
        {
            agenda = new Dictionary<int, EntradaAgenda>();
        }
        public void add(string texto, string fecha="", string hora="")
        {
            if (fecha.Equals(string.Empty))
                fecha = DateTime.Today.ToString("dd-MM-yyyy");
            agenda.Add(ID,new EntradaAgenda(texto, fecha, hora,ID));
            ID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public void show(string fecha)
        {
            foreach (EntradaAgenda entrada in filtrar(fecha))
            {
                Console.WriteLine(construirMensaje(entrada));
            }
        }
        public void remove(int id)
        {
            if (agenda.Remove(id))
                Console.WriteLine("Entrada eliminada con exito");
            else Console.WriteLine("No existe entrada con dicho ID");
        }
        private ArrayList filtrar(string fecha)
        {
            ArrayList filtrado = new ArrayList();
            foreach (KeyValuePair<int, EntradaAgenda> entrada in agenda)
            {
                if (entrada.Value.fecha.Equals(fecha))
                    filtrado.Add(entrada.Value);
            }
            return filtrado;
        }
        private string construirMensaje(EntradaAgenda entrada)
        {
            string texto = " Texto: " + entrada.texto + " ";
            string hora = string.Empty;
            if (!entrada.hora.Equals(string.Empty))
                hora = "Hora: " + entrada.hora + " ";
            return "Fecha: " + entrada.fecha + texto + hora + "ID: " + (entrada.ID);
        }
    }
}
