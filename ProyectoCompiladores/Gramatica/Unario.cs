using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class Unario : Op
    {
        public Exp expr;
        public Unario(Token tok, Exp x) : base(tok, null)
        {
            // maneja el menos, para ! vea Not
            expr = x;
            tipo = Tipo.max(Tipo.Int, expr.tipo);
            if (tipo == null) error("error de tipo " + Tipo.Int.Lexeme + " no es compatible con " + expr.tipo.Lexeme);
        }
        public override Exp gen()
        {
            return new Unario(op, expr.reducir());
        }
        public override string ToString()
        {
            return op.ToString() + " " + expr.ToString();
        }
    }
}
