using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCompiladores.Analisis_Lexico;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    class Do : Statement
    {
        private Exp expr;
        Statement instr;
        public Do(Statement s, Exp x)
        {
            expr = x; instr = s;
            if (expr.tipo != Tipo.Bool) expr.error("se requiere booleano en do");
        }
    }
}
