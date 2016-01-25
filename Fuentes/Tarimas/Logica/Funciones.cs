using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaTarima
{
    public static class Funciones
    {

        public static int ValidarNumero(string valor)
        {

            int resultado = 0;
            if (int.TryParse(valor, out resultado))
            {
                return resultado;
            }
            else
            {
                return 0;
            }
            
        
        }

        public static double ValidarDouble(string valor)
        {

            double resultado = 0;
            if (double.TryParse(valor, out resultado))
            {
                return resultado;
            }
            else
            {
                return 0;
            }


        }

        public static bool ValidarFecha(string valor)
        {

            DateTime temporal; 
            if (DateTime.TryParse(valor, out temporal))
                return true;
            else
                return false;

        }

        public static bool ValidarString(string valor)
        {
            
            if (string.IsNullOrEmpty(valor))
                return true;
            else
                return false;

        }

    }
}
