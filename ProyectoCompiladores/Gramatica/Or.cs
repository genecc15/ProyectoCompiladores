using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Tokens;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class Or : Logica
    {
        public Or(Exp x1, Exp x2) : base(Palabra.OR, x1, x2)
        {
        }
    }
}
