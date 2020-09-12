using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Tokens;

namespace ProyectoCompiladores.Gramatica
{
    public class Op:Expresion
    {
        public Op(Token tok, Tipo p) : base(tok, p) { }

    }
}
