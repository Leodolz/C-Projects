using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    class Interprete
    {
        Agenda_Ayudante ayudante = new Agenda_Ayudante();

        public bool LocalTime { get; private set; }

        public bool comando(string entrada)
        {
            if (entrada.StartsWith("ADD"))
            {
                add(reemplazarUnaVez(entrada, "ADD ", ""));
            }
            else if (entrada.StartsWith("SHOW"))
            {
                show(reemplazarUnaVez(entrada, "SHOW ", ""));
            }
            else if (entrada.StartsWith("REMOVE "))
            {
                eliminar(reemplazarUnaVez(entrada, "REMOVE ", ""));
            }
            else if (entrada.StartsWith("ESC"))
                return true;
            else
                Console.WriteLine("Error, porfavor inserte un comando valido\nCOMANDOS:\nADD\nSHOW\nREMOVE");
            return false;
        }
        private void add(string entrada)
        {
            string[] separado = entrada.Split(" ");
            switch(separado.Length)
            {
                case 1: //texto
                    ayudante.add(separado[0]);
                    break;
                case 2: //dos entradas
                    switch(reconocerComando(separado[0]))
                    {
                        case 1:
                            ayudante.add(separado[1], separado[0]);
                            break;
                        case 2:
                            ayudante.add(separado[1], "", separado[0]);
                            break;
                        default:
                            Console.WriteLine("Comando invalido, intente de nuevo");
                            break;
                    }
                    break;
                case 3:
                    ayudante.add(separado[2], separado[0], separado[1]);
                    break;
                default:
                    Console.WriteLine("Formato invalido, vuelva a intentar");
                    break;
            }
            
        }

        private int reconocerComando(string textoIni)
        {
            ArrayList formatosFecha = new ArrayList {"/","-"};
            ArrayList formatosHora = new ArrayList { ":"};
            foreach(string formato in formatosFecha)
            {
                if (textoIni.Split(formato).Length==3)
                {
                    DateTime date;
                    if (DateTime.TryParseExact(textoIni, "dd"+formato+"MM"+formato+"yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        return 1; // Es Fecha
                    //else if (DateTime.TryParseExact(textoIni, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                      //  return 1;
                }
            }
            foreach (string formato in formatosHora)
            {
                string[] hhmmss = textoIni.Split(formato);
                if (hhmmss.Length > 1 && hhmmss.Length<4)
                {
                    foreach(string numero in hhmmss)
                    {
                        if (numero == hhmmss[0])
                            if (!revisarNumero(numero, true))
                                return -1;
                            if(!revisarNumero(numero, false))
                                return -1;
                    }
                    return 2; // Es Hora
                }
            }
            //Si no es ninguno
            return -1;
        }

        private void show(string entrada)
        {
            if (entrada.Equals("") || entrada.Equals(" "))
            {
                ayudante.show();
                return;
            }
            DateTime date;
            if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                ayudante.show(entrada);
            }

            else Console.WriteLine("Formato Erroneo, por favor intente de nuevo\nPara Fechas se usa el formato dd/MM/yyyy");
        }
        private void eliminar(string entrada)
        {
            if(revisarNumero(entrada,true))
            {
                ayudante.remove(int.Parse(entrada));
            }
        }
        private string reemplazarUnaVez(string texto,string viejoReg,string nuevoReg)
        {
            var regex = new Regex(Regex.Escape(viejoReg));
            return regex.Replace(texto, nuevoReg, 1);

        }
        private bool revisarNumero(string num, bool hora)
        {
            int intStr;
            if (int.TryParse(num, out intStr))
            {
                if (hora)
                {
                    return (intStr > 0);
                }
                else return (intStr > 0 && intStr < 60);
            }
            return false;
        }
    
    }
}
