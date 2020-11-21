using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class Print : Statement
    {
        private Exp exp;

        public Print(Exp exp)
        {
            this.exp = exp;
        }
    }
}
