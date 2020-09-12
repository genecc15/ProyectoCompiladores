﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Lexico;

namespace ProyectoCompiladores.Gramatica
{
    public class And : Logica
    {
        public And(Expresion x1, Expresion x2) : base(Palabra.AND, x1, x2)
        { }
    }
}
