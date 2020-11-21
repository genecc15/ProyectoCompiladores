using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class Identifier : Exp
    {
        private string name;

        public Identifier(Token token, Tipo type) : base(token, type)
        {
            this.name = token.Lexeme;
        }

        public String getName()
        {
            return name;
        }
    }
}
