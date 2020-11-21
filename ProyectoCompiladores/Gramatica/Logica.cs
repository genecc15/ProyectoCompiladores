﻿using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class Logica : Exp
    {
        public Exp expr1, expr2;
        public Logica(Token tok, Exp x1, Exp x2) : base(tok, null)
        {
            expr1 = x1; expr2 = x2;
            tipo = comprobar(expr1.tipo, expr2.tipo);
            if (tipo == null) error("error de tipo " + x1.tipo.Lexeme + " no es compatible con " + x2.tipo.Lexeme);
        }

        public virtual Tipo comprobar(Tipo p1, Tipo p2)
        {
            if (p1 == Tipo.Bool && p2 == Tipo.Bool) return Tipo.Bool;
            else return null;
        }

        public override string ToString()
        {
            return expr1.ToString() + " " + op.ToString() + " " + expr2.ToString();
        }
    }
}
