using System;

namespace AgendaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Interprete cliente = new Interprete();
            Console.WriteLine("Agenda Software:\nComandos:\nADD\nSHOW\nREMOVE\nESC");
            while (true)
            {
                string entrada = Console.ReadLine();
                if (cliente.comando(entrada))
                    break;
            }
        }
    }
}
