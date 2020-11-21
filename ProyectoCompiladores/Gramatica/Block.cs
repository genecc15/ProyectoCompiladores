using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Semantico;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    class Block : Statement
    {
        private StatementList stms;
        private VarDeclList decls;
        private Entorno entorno;

        public Block(StatementList stms, Entorno entorno)
        {
            this.stms = stms;
            this.entorno = entorno;
        }


        public StatementList getStms()
        {
            return stms;
        }
    }
}
