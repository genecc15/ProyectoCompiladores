using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Tokens;

namespace ProyectoCompiladores.Gramatica
{
    public class Not:Logica
    {
        public Not(Token tok, Expresion x2) : base(tok, x2, x2)
        { }

        public override string ToString()
        {
            return op.ToString() + " " + expr2.ToString();
        }
    }
}
