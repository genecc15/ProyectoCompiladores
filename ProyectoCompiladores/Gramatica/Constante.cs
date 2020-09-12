﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Tokens;
using ProyectoCompiladores.Analisis_Lexico;

namespace ProyectoCompiladores.Gramatica
{
    public class Constante:Expresion
    {
        public Constante(Token tok, Tipo p) : base(tok, p)
        { }
        public Constante(int i) : base(new Num(i), Tipo.Int)
        {
        }
        public static readonly Constante
            True = new Constante(Palabra.TRUE, Tipo.Bool),
            False = new Constante(Palabra.FALSE, Tipo.Bool);

    }
}
