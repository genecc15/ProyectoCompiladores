using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Tokens;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class Arit : Op
    {
        public Exp expr1, expr2;
        public Arit(Token tok, Exp x1, Exp x2) : base(tok, null)
        {
            expr1 = x1; expr2 = x2;
            tipo = Tipo.max(expr1.tipo, expr2.tipo);
            if (tipo == null) error("error de tipo " + x1.tipo.Lexeme + " no es compatible con " + x2.tipo.Lexeme);
        }
        public override Exp gen()
        {
            return new Arit(op, expr1.reducir(), expr2.reducir());
        }
        public override string ToString()
        {
            return expr1.ToString() + " " + op.ToString() + " " + expr2.ToString();
        }
    }
}
