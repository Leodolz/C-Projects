using System;


namespace AgendaApp
{
    class AddTwoEntries : AgendaAdd
    {
        AgendaHelper ayudante;
        public AddTwoEntries(AgendaHelper ayudante)
        {
            this.ayudante = ayudante;
        }
        public void execute(string[] texto)
        {
            reconocerComando(texto);
        }

        private void reconocerComando(string[] comando)
        {
            if (Validators.isValidDate(comando[0])) //Es Fecha primero
                ayudante.add(comando[1], comando[0]);
            else if (Validators.isValidTime(comando[0])) //Es Hora primero
                ayudante.add(comando[1], string.Empty, comando[0]);
            else Console.WriteLine("Comando invalido, intente de nuevo");
        }
        
    }
}
