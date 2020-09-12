using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Sintactico;

namespace ProyectoCompiladores.Gramatica
{
    public class Nodo
    {
        public void error(string s)
        {
            Parser.error(s);
        }
    }
}
