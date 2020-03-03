using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AgendaApp
{
    public static class Validators
    {
        private static string[] formatosFecha = new[] { "MM/dd/yyyy", "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "MM-dd-yyyy", "dd-MM-yyyy" };
        public static bool validarFecha(string entrada)
        {
            DateTime date;
            return DateTime.TryParseExact(entrada, formatosFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
        public static bool validarHora(string entrada)
        {
            Regex revisarTiempo = new Regex(@"^(?i)(0?[1-9]|1[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?( AM| PM)?$");
            return revisarTiempo.IsMatch(entrada);
        }
    }
}
