using System;
using ProyectoCompiladores.Semantico;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
