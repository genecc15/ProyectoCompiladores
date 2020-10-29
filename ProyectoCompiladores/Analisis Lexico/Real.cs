using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Tokens;

namespace ProyectoCompiladores.Analisis_Lexico
{
    public class Real : Token
    {
        private float valorField;
        public float Valor { get { return valorField; } }
        public Real(float v) : base(((double)v).ToString("0.0#####"), TokenType.doubleConstant)
        {
            valorField = v;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
