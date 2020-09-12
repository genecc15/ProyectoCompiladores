using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Sintactico;

namespace ProyectoCompiladores.Gramatica
{
    class Block:Statement
    { //Arreglado
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
