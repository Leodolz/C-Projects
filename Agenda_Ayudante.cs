using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class Agenda_Ayudante
    {
        Dictionary<int, EntradaAgenda> agenda;
        int ID = 1;
        public Agenda_Ayudante()
        {
            agenda = new Dictionary<int, EntradaAgenda>();
        }
        public void add(string texto, string fecha="", string hora="")
        {
            if (fecha.Equals(""))
                fecha = DateTime.Today.ToString("dd-MM-yyyy");
            agenda.Add(ID,new EntradaAgenda(texto, fecha, hora,ID));
            ID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public void show(string fecha = "")
        {
            if(fecha.Equals(""))
                fecha = DateTime.Today.ToString("dd/MM/yyyy");
            ArrayList mostrarEntradas = new ArrayList();
            foreach (KeyValuePair<int,EntradaAgenda> entrada in agenda)
            {
                if (entrada.Value.fecha.Equals(fecha))
                    mostrarEntradas.Add(entrada.Value);
            }
            foreach(EntradaAgenda entrada in mostrarEntradas)
            {
                string texto = " Texto: "+entrada.texto+" ";
                string hora = "";
                if (!entrada.hora.Equals(""))
                    hora = "Hora: " + entrada.hora + " ";
                Console.WriteLine("Fecha: "+entrada.fecha+texto+hora+"ID: "+(entrada.ID));
            }
        }
        public void remove(int id)
        {
            if (agenda.Remove(id))
                Console.WriteLine("Entrada eliminada con exito");
            else Console.WriteLine("No existe entrada con dicho ID");
        }
    }
}
