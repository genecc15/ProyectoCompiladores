using System;
using ProyectoCompiladores.Analisis_Lexico;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class For : Statement
    {
        private Statement declaration;
        private Exp expression;
        private Asignacion incExpression;
        private Statement stm;

        public For(Statement declaration, Exp loopExpresion, Asignacion incExp, Statement stm)
        {
            this.declaration = declaration;
            this.expression = loopExpresion;
            this.incExpression = incExp;
            this.stm = stm;
            if (loopExpresion.tipo != Tipo.Bool) loopExpresion.error("se requiere booleano en for");
        }
    }
}
