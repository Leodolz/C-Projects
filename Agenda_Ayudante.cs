using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class Agenda_Ayudante
    {
        ArrayList agenda;
        public Agenda_Ayudante()
        {
            agenda = new ArrayList();
        }
        public void add(string texto, string fecha="", string hora="")
        {
            if (fecha.Equals(""))
                fecha = DateTime.Today.ToString("dd-MM-yyyy");
            agenda.Add(new EntradaAgenda(texto, fecha, hora));
            Console.WriteLine("Texto ingresado correctamente");
        }
        public void show(string fecha = "")
        {
            if(fecha.Equals(""))
                fecha = DateTime.Today.ToString("dd-MM-yyyy");
            ArrayList mostrarEntradas = new ArrayList();
            foreach (EntradaAgenda entrada in agenda)
            {
                if (entrada.fecha.Equals(fecha))
                    mostrarEntradas.Add(entrada);
            }
            foreach(EntradaAgenda entrada in mostrarEntradas)
            {
                string texto = " Texto: "+entrada.texto+" ";
                string hora = "";
                if (!entrada.hora.Equals(""))
                    hora = "Hora: " + entrada.hora + " ";
                Console.WriteLine("Fecha: "+entrada.fecha+texto+hora+"ID: "+(agenda.IndexOf(entrada)+1));
            }
        }
        public void remove(int id)
        {
            if (id > agenda.Count || id < agenda.Count)
            {
                Console.WriteLine("No existe dicho id");
                return;
            }
            else agenda.RemoveAt(id - 1);
            Console.WriteLine("Entrada eliminada con exito");
        }
    }
}
