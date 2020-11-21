using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCompiladores.Analisis_Lexico;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class VarDecl : Statement
    {
        private Tipo type;
        private Identifier id;

        public VarDecl(Tipo type, Identifier id)
        {
            this.type = type;
            this.id = id;
        }
    }
}
