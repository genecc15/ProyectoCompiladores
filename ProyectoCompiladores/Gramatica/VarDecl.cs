using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Lexico;

namespace ProyectoCompiladores.Gramatica
{
    public class VarDecl:Statement
    {//Daba error porque no tenia la otra clase hahaha
        private Tipo type;
        private Identifier id;

        public VarDecl(Tipo type, Identifier id)
        {
            this.type = type;
            this.id = id;
        }
    }
}
