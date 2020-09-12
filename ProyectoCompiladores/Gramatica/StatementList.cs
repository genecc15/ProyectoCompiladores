using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCompiladores.Gramatica
{
    public class StatementList
    {
        private List<Statement> list;
        public StatementList()
        {
            list = new List<Statement>();
        }
        public void addElement(Statement statement)
        {
            list.Add(statement);
        }
    }
}
