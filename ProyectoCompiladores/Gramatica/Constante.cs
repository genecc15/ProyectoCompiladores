using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Tokens;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
   public class Constante : Exp
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
