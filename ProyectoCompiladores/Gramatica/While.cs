using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Analisis_Lexico;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class While : Statement
    {
        private Exp expr;
        private Statement stm;

        public While(Exp condExp, Statement stm)
        {
            this.expr = condExp;
            this.stm = stm;
            if (expr.tipo != Tipo.Bool) expr.error("se requiere booleano en while");
        }
    }
}
