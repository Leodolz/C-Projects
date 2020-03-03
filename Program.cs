using System;

namespace AgendaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Interpreter client = new Interpreter();
            Console.WriteLine("Agenda Software:\nComandos:\nADD\nSHOW\nREMOVE\nESC");
            while (true)
            {
                string entry = Console.ReadLine();
                if (client.command(entry))
                    break;
            }
        }
    }
}
