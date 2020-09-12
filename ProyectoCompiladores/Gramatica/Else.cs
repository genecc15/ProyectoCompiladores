using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Lexico;

namespace ProyectoCompiladores.Gramatica
{
    public class Else:Statement
    {
        Expresion expr; Statement instr1, instr2;
        public Else(Expresion x, Statement s1, Statement s2)
        {
            expr = x; instr1 = s1; instr2 = s2;
            if (expr.tipo != Tipo.Bool) expr.error("se requiere booleano en if");
        }
    }
}
