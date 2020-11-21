using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Gramatica;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class MainClass
    {
        private Identifier className;
        private MethodDecl mainMethod;

        public MainClass(Identifier className, MethodDecl mainMethod)
        {
            this.className = className;
            this.mainMethod = mainMethod;
        }
    }
}
