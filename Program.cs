using System;

namespace AgendaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            General_Interpreter client = new General_Interpreter();
            Console.WriteLine("Agenda Software:\nComandos:\nADD\nSHOW\nREMOVE\nESC");
            while (true)
            {
                string entry = Console.ReadLine();
                client.InterpretCommand(entry);
            }
        }
    }
}
