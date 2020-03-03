using System;
using System.Collections;
using System.Collections.Generic;

namespace AgendaApp
{
    class Agenda_Ayudante
    {
        Dictionary<int, EntradaAgenda> agenda;
        private const string EMPTY = "";
        int ID = 1;
        public Agenda_Ayudante()
        {
            agenda = new Dictionary<int, EntradaAgenda>();
        }
        public void add(string texto, string fecha=EMPTY, string hora=EMPTY)
        {
            if (fecha.Equals(EMPTY))
                fecha = DateTime.Today.ToString("dd-MM-yyyy");
            agenda.Add(ID,new EntradaAgenda(texto, fecha, hora,ID));
            ID++;
            Console.WriteLine("Texto ingresado correctamente");
        }
        public void show(string fecha = EMPTY)
        {
            if(fecha.Equals(EMPTY))
                fecha = DateTime.Today.ToString("dd-MM-yyyy");
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
            string hora = EMPTY;
            if (!entrada.hora.Equals(EMPTY))
                hora = "Hora: " + entrada.hora + " ";
            return "Fecha: " + entrada.fecha + texto + hora + "ID: " + (entrada.ID);
        }
    }
}
