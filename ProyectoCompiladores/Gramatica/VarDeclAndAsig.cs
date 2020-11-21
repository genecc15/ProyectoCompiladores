using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Analisis_Lexico;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class VarDeclAndAsig : VarDecl
    {
        private Asignacion asignacion;
        public VarDeclAndAsig(Tipo type, Identifier id, Asignacion asignacion) : base(type, id)
        {
            this.asignacion = asignacion;
        }
    }
}
