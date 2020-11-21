using System;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Semantico;
using ProyectoCompiladores.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class Exp : Nodo
    {
        public Token op;
        public Tipo tipo;
        public Exp(Token tok, Tipo p)
        {
            op = tok; tipo = p;
        }

        public void error(string v)
        {
            Parser.error(v);
        }

        public virtual Exp gen()
        {
            return this;
        }
        public virtual Exp reducir()
        {
            return this;
        }
    }
}
