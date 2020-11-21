using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Analisis_Lexico;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class And : Logica
    {
        public And(Exp x1, Exp x2) : base(Palabra.AND, x1, x2)
        { }
    }
}
