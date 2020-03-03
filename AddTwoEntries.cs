using System;


namespace AgendaApp
{
    class AddTwoEntries : AddCommand
    {
        Agenda_Ayudante ayudante;
        public AddTwoEntries(Agenda_Ayudante ayudante)
        {
            this.ayudante = ayudante;
        }
        public void Add(string[] texto)
        {
            reconocerComando(texto);
        }

        private void reconocerComando(string[] comando)
        {
            if (Validators.validarFecha(comando[0])) //Es Fecha primero
                ayudante.add(comando[1], comando[0]);
            else if (Validators.validarHora(comando[0])) //Es Hora primero
                ayudante.add(comando[1], string.Empty, comando[0]);
            else Console.WriteLine("Comando invalido, intente de nuevo");
        }
        
    }
}
