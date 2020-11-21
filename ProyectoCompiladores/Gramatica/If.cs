using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCompiladores.Analisis_Lexico;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class If : Statement
    {
        Exp expr; Statement instr;
        public If(Exp x, Statement s)
        {
            expr = x; instr = s;
            if (expr.tipo != Tipo.Bool) expr.error("se requiere booleano en if");
        }
    }
}
