using System;

namespace AgendaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralUserInterpreter userInterpreter = new GeneralUserInterpreter();
            Console.WriteLine("Agenda App:\nValid Commands:\nADD\nSHOW\nREMOVE\nESC");
            while (true)
            {
                string userCommandEntry = Console.ReadLine();
                userInterpreter.ParseUserCommand(userCommandEntry);
            }
        }
    }
}
