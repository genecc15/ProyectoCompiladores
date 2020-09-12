using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Analisis_Sintactico;
using ProyectoCompiladores.Tokens;

namespace ProyectoCompiladores.Gramatica
{
    //  Elimine la otra porque me daba problema
    public class Expresion
    {
        public Token op;
        public Tipo tipo;
        public Expresion(Token tok, Tipo p)
        {
            op = tok; tipo = p;
        }

        public void error(string v)
        {
            Parser.error(v);
        }

        public virtual Expresion gen()
        {
            return this;
        }
        public virtual Expresion reducir()
        {
            return this;
        }
    }
}
