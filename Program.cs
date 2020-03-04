using System;

namespace AgendaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterpreter userInterpreter = new UserInterpreterDecorator(new BaseUserInterpreter());
            Console.WriteLine("Agenda App:\nValid Commands:\nADD\nSHOW\nREMOVE\nESC");
            while (true)
            {
                string userCommandEntry = Console.ReadLine();
                userInterpreter.ParseUserCommand(userCommandEntry);
            }
        }
    }
}
