using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Tokens;

namespace ProyectoCompiladores.Analisis_Lexico
{
    public class Num : Token
    {
        private int valorField;
        public int valor { get { return valorField; } }
        public Num(int v) : base(v.ToString(), TokenType.IDENT)
        {
            valorField = v;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
