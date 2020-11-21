﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Tokens;
using ProyectoCompiladores.Semantico;
using ProyectoCompiladores.Gramatica;

namespace ProyectoCompiladores.Semantico
{
    public class Entorno
    {
        private Dictionary<Token, Identifier> tabla;
        private Entorno anterior;
        public Entorno Anterior { get { return anterior; } }
        public Entorno(Entorno anterior)
        {
            tabla = new Dictionary<Token, Identifier>();
            this.anterior = anterior;
        }
        public void Put(Token token, Identifier id)
        {
            tabla.Add(token, id);
        }

        public Identifier Get(Token w)
        {
            for (Entorno e = this; e != null; e = e.anterior)
            {
                if (e.tabla.ContainsKey(w))
                {
                    return e.tabla[w];
                }
            }
            return null;
        }
    }
}
